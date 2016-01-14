using _1312658.Model;
using _1312658.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1312658.Views
{
    /// <summary>
    /// Interaction logic for ChessBoard.xaml
    /// </summary>
    /// 


    public partial class ChessBoard : UserControl
    {
       // Player player;
        BoardViewModel boardViewModel;
        public Connection_Sever socket { get; set; }
        public string m_message { get; set; }
        public int m_TypePlay { get; set; }


        public string m_NameHuman { get; set; }
        CellValues m_player { get; set; }

        CaroButton[,] CaroTable = new CaroButton[12,12]; 
        public ChessBoard()
        {
            InitializeComponent();
           
            boardViewModel = new BoardViewModel();
            boardViewModel.CurrentBoard.OnPlayerWin += CurrentBoard_OnPlayerWin;
            boardViewModel.CurrentBoard.OnStepp += CurrentBoard_OnStep;

            Connection();
            // Nhận event choi online
            socket.message_changed += OnMessageChanged;
            socket.SteppChange_changed += OnSteppSever;
            socket.StartPlayAuToOnline += OnStartAutoOnline;
            socket.LeftGame += OnLeftGame;
            socket.winGame += OnWinGame;
        }

        // xử lý sự kiện khi có người đang kết nối online rồi thoát ra
        public void OnLeftGame()
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show("Người chơi đã thoát, vui lòng chọn lại!!!");
                Frm_Menu menu = new Frm_Menu();
                if (Exit_changed != null)
                    Exit_changed();
                menu.ShowDialog();
                socket.Disconnected();
            }));
        }

        public void Disconnection()
        {
            socket.Disconnected();
        }

       // xử lý sự kiện máy auto đã đánh xong
        void CurrentBoard_OnStep(int X, int Y)
        {
            if (m_TypePlay == 2)
                this.Dispatcher.Invoke((Action)(() => { CaroTable[Y, X].Content = setPicture("Picture/Player2.png"); }));
            if(m_TypePlay ==4)
            {
                this.Dispatcher.Invoke((Action)(() => { CaroTable[Y, X].Content = setPicture("Picture/Player1.png"); }));
                socket.SendPoint(new Point(X, Y));
            }
        }

        private void OnWinGame(List<Point> winArray, string nameWin)
        {
            showWinArray(winArray);
            MessageBox.Show(nameWin + " win !");
            this.Dispatcher.Invoke((Action)(() => {
                Frm_Menu menu = new Frm_Menu();
                if (Exit_changed != null)
                    Exit_changed();
                menu.ShowDialog();
                socket.Disconnected();
            }));
        }

        // xử lý sự kiện showw đường đi chiến thắng.
        private void showWinArray(List<Point> win)
        {
            foreach(Point a in win)
            {
                this.Dispatcher.Invoke((Action)(() => { CaroTable[(int)a.X, (int)a.Y].Background = Brushes.Yellow; }));
            }
        }

        // sử lý sự kiện có người win
        // type 1 và 2 -> cho chơi lại
        // type 3 và 4 -> thoát ra menu
        private void CurrentBoard_OnPlayerWin(CellValues player)
        {
            if (m_TypePlay == 1 || m_TypePlay == 2)
            {
                MessageBox.Show(player.ToString() + "win !");
                showWinArray(boardViewModel.CurrentBoard.winArray);
                try
                {
                    if (m_TypePlay == 1 || m_TypePlay == 2)
                    {
                        MessageBoxResult dialogResult = MessageBox.Show("Bạn có muốn chơi lại??? ", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (dialogResult == MessageBoxResult.Yes)
                            ResetBoard();
                        else
                        {
                            Frm_Menu menu = new Frm_Menu();
                            if (Exit_changed != null)
                                Exit_changed();
                            menu.ShowDialog();
                        }
                    }
                    else
                    {
                        Frm_Menu menu = new Frm_Menu();
                        if (Exit_changed != null)
                            Exit_changed();
                        menu.ShowDialog();
                    }
                }
                catch
                {
                    MessageBox.Show("Bạn không thể tiếp tục!");
                }
            }
        }

        private StackPanel setPicture(string picture)
        {

            Image img = new Image();
            img.Source = new BitmapImage(new Uri(picture, UriKind.RelativeOrAbsolute));
            StackPanel stackPnl = new StackPanel();
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Margin = new Thickness(1);
            stackPnl.Children.Add(img);
            return stackPnl;
        }

        // Reset bàn cờ
        public void ResetBoard()
        {
            boardViewModel.CurrentBoard.ResetBoard();
            var brush1 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("Picture/c.png", UriKind.RelativeOrAbsolute));

            for (int i = 0; i < 12; i++ )
            {
                for(int j = 0; j < 12; j++)
                    this.Dispatcher.Invoke((Action)(() => { wpnBanCo.Children.Remove(CaroTable[i, j]); }));
            }

            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                {
                    CaroTable[i, j] = new CaroButton();
                    CaroTable[i, j].m_X = i;
                    CaroTable[i, j].m_Y = j;
                    CaroTable[i, j].Background = brush1;
                    CaroTable[i, j].Width = 40;
                    CaroTable[i, j].Height = 40;
                    wpnBanCo.Children.Add(CaroTable[i, j]);
                    CaroTable[i, j].Click += CaroButtonTable_Click;
                }
        }

        // sự kiện lick
        private void CaroButtonTable_Click(object sender, RoutedEventArgs e)
        {
            CaroButton cell = (CaroButton)sender;


            if(boardViewModel.CurrentBoard.CheckNone(cell.Y, cell.X))
            {
                if (m_TypePlay == 1)
                {
                    if (boardViewModel.CurrentBoard.ActivePlayer == CellValues.Player1)
                        cell.Content = setPicture("Picture/Player1.png");

                    else
                        cell.Content = setPicture("Picture/Player2.png");
                    boardViewModel.CurrentBoard.PlayAt(cell.Y, cell.X, m_TypePlay);
                }
                else if (m_TypePlay == 2)
                {
                    cell.Content = setPicture("Picture/Player1.png");
                    boardViewModel.CurrentBoard.PlayAt(cell.Y, cell.X, m_TypePlay);
                }

                else if(m_TypePlay == 3 && m_player == CellValues.Player1)
                {
                    if(socket.m_StartGame == true)
                    {
                        cell.Content = setPicture("Picture/Player1.png");
                        boardViewModel.CurrentBoard.PlayAt(cell.Y, cell.X, 1);
                        socket.SendPoint(new Point(cell.Y, cell.X));
                        m_player = CellValues.Player2;
                    }
                }

            }
        }

        // Kết nối với sever
        public void Connection()
        {
            socket = new Connection_Sever(m_NameHuman);
            socket.addOn();
        }

        // xử lý sự kiwwnj đổi tên
        public void ChangeName(string name)
        {
            socket.ChangeName(name);
        }

        public void Chat(string message)
        {
            socket.chat(message);
        }

        // sử lý sự kiện thay đổi message
        public void OnMessageChanged(string message)
        {
            string namePlayer2 = socket.m_NameSever;
            if (message_changed != null)
                message_changed(message, namePlayer2);
        }

        // Xử lý sự kiện nhân step từ server
        public void OnSteppSever(Point step)
        {
            this.Dispatcher.Invoke((Action)(() => { CaroTable[(int)step.Y, (int)step.X].Content = setPicture("Picture/Player2.png"); }));
            
            if (m_TypePlay == 4) // choi auto -> chuyen về chơi với máy.
                boardViewModel.CurrentBoard.PlayAt((int)step.X, (int)step.Y, 2);

            if (m_TypePlay == 3) // chơi online chuyển về chơi thủ công giữa 2 người.
                boardViewModel.CurrentBoard.PlayAt((int)step.X, (int)step.Y, 1);

            m_player = CellValues.Player1;
        }

        // nhận sự kiện bắt đầu chơi online.
        public void OnStartAutoOnline(bool is_First)
        {
            if(m_TypePlay ==4)
            {
                if (is_First)
                {
                    Point stepAuto = new Point(6, 6);
                    boardViewModel.CurrentBoard.PlayAt((int)stepAuto.Y, (int)stepAuto.X, m_TypePlay);

                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        CaroTable[(int)stepAuto.Y, (int)stepAuto.X].Content = setPicture("Picture/Player1.png");
                    }));
                    socket.SendPoint(stepAuto);
                }
            }

            if (m_TypePlay == 3)
            {
                if (is_First)
                    m_player = CellValues.Player1;
                else
                    m_player = CellValues.Player2;
            }
        }


        // sự kiện thay đổi message
        public delegate void Message_ChangedHandler(String mesage, string namePlayer2);
        public event Message_ChangedHandler message_changed;

        private void wpnBanCo_Loaded(object sender, RoutedEventArgs e)
        {
            var brush1 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("Picture/c.png", UriKind.RelativeOrAbsolute));
            var brush2 = new ImageBrush();
            brush2.ImageSource = new BitmapImage(new Uri("Picture/c.png", UriKind.RelativeOrAbsolute));
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                {
                    CaroTable[i, j] = new CaroButton();
                    CaroTable[i, j].m_X = i;
                    CaroTable[i, j].m_Y = j;
                    CaroTable[i, j].Background = brush1;
                    CaroTable[i, j].Width = 40;
                    CaroTable[i, j].Height = 40;
                    wpnBanCo.Children.Add(CaroTable[i, j]);
                    CaroTable[i, j].Click += CaroButtonTable_Click;
                }
        }

        // sự kiện thoát game khi có người left hoặc 1 trong 2 win
        public delegate void Exit_ChangedHandler();
        public event Exit_ChangedHandler Exit_changed;
    }
}
