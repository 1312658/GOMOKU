using _1312658.Model;
using _1312658.ViewModel;
using System;
using System.Collections.Generic;
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
        private Connection_Sever socket { get; set; }
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
        }

        public void OnLeftGame()
        {
            Connection();
        }

        public void Disconnection()
        {
            socket.Disconnected();
        }
       
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

        void CurrentBoard_OnPlayerWin(CellValues player)
        {
            MessageBox.Show(player.ToString() + "win !");
            MessageBoxResult dialogResult = MessageBox.Show("Bạn có muốn chơi lại??? ", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                if (m_TypePlay == 1 || m_TypePlay == 2)
                    ResetBoard();
                else
                {
                    socket.Disconnected();
                    ResetBoard();
                    Connection();
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
            //if (socket.m_isFrist)
            //    m_player = CellValues.Player1;
            //else m_player = CellValues.Player2;
        }

        public void ChangeName(string name)
        {
            socket.ChangeName(name);
        }

        public void Chat(string message)
        {
            socket.chat(message);
        }

        public void OnMessageChanged(string message)
        {
            string namePlayer2 = socket.m_NameSever;
            message_changed(message, namePlayer2);
        }

        public void OnSteppSever(Point step)
        {
            this.Dispatcher.Invoke((Action)(() => { CaroTable[(int)step.Y, (int)step.X].Content = setPicture("Picture/Player2.png"); }));
            if (m_TypePlay == 4)
            {
                boardViewModel.CurrentBoard.PlayAt((int)step.X, (int)step.Y, 2);
            }
            m_player = CellValues.Player1;
        }

        // thực hiện chơi online auto
        public void OnStartAutoOnline(bool is_First)
        {
            if(m_TypePlay ==4)
            {
                if (is_First)
                {
                    Point stepAuto = new Point(6, 6);
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
    }
}
