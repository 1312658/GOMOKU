using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace _1312658.Views
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string m_Message { get; set; }
        public int m_TypePlay { get; set; }

        private frmPause FrmPause = new frmPause();
        public MainWindow(int m_type)
        {
            InitializeComponent();

            ChessBoardMain.m_TypePlay = m_type;

            ChatMain.m_TypePlay = m_type;
            
            ChessBoardMain.m_NameHuman = ChatMain.m_NameHuman;
            
            m_TypePlay = m_type;

            if (StartGame != null)
                StartGame(m_TypePlay);

            ChatMain.ChatWeCome(m_TypePlay);
            ChessBoardMain.message_changed += OnShowMessage; // Sự kiện Nhận nt online
            ChatMain.ChangeName_changed += OnChangeName;  // Sự kiện thay đổi tên
            ChatMain.SenMessageSever_changed += OnSentMessage; // sự kiện gởi tn online
            ChessBoardMain.Exit_changed += OnExitGame; // Thoát khi kết thúc màn chơi

            FrmPause.exitGame += OnExitGame; // sự kiện thoát game
            FrmPause.newGame += OnNewGame; // sự kiện new game
        }

        private void OnNewGame()
        {
            ChessBoardMain.ResetBoard();
        }
        private void OnExitGame()
        {
            this.Close();

            if (FrmPause != null)
                FrmPause.Close();

            if (m_TypePlay == 3 || m_TypePlay == 4)
                ChessBoardMain.socket.Disconnected();
        }

        private void OnChangeName(string name)
        {
            ChessBoardMain.ChangeName(name);
        }

        private void OnSentMessage(string Message)
        {
            ChessBoardMain.Chat(Message);
        }

        private void OnShowMessage(string message, string namePlayer2)
        {
            ChatMain.ShowChat(message, namePlayer2);
        }

        private void btn_Pause_Click(object sender, RoutedEventArgs e)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("Picture/Start.png", UriKind.RelativeOrAbsolute));
            StackPanel stackPnl = new StackPanel();
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Margin = new Thickness(1);
            stackPnl.Children.Add(img);
            btn_Pause.Content = stackPnl;

            FrmPause.ShowDialog();

            img = new Image();
            img.Source = new BitmapImage(new Uri("Picture/Pause.png", UriKind.RelativeOrAbsolute));
            stackPnl = new StackPanel();
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Margin = new Thickness(1);
            stackPnl.Children.Add(img);
            btn_Pause.Content = stackPnl;

        }

        public delegate void StartGame_ChangedHandler(int m_type);
        public event StartGame_ChangedHandler StartGame;
    }
}
