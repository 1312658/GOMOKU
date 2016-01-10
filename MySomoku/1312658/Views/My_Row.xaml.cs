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
    /// Interaction logic for My_Row.xaml
    /// </summary>
    public partial class My_Row : UserControl
    {
        int m_X;
        int m_Y;
        public int TypePlay;
        static Board BanCo = new Board();
        SolidColorBrush brushes = Brushes.Black;
        static ChessBoard GiaoDienBanCo = new ChessBoard();
        bool temp;
        public int X
        {
                get { return m_X; }
                set { m_X = value; }
        }

        public int Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }

        public My_Row()
        {
            InitializeComponent();
            // Sự kiện Human đánh xong
            BanCo.HumanDanhXong += new Board.EventHumanDanhXong(HumanDanhXong);
            BanCo.ComDanhXong += new Board.EventComDanhXong(ComDanhXong);
            // Sự kiện Com đánh xong
            BanCo.HumanWinEvent += new Board.HumanWinEventHander(HumanWin);
            BanCo.ComWinEvent += new Board.ComWinEventHander(ComWin);
        }

        // Chuyển sự kiện Human win về CHessBoard
        public delegate void HaveHumanWinEventHander();
        public event HaveHumanWinEventHander HaveHumanWin;
        public void HumanWin()
        {
            if (HaveHumanWin != null)
            {
                HaveHumanWin();
            }
        }
        // Chuyển sự kiện Com win về CHessBoard
        public delegate void HaveComWinEventHander();
        public event HaveComWinEventHander HaveComWin;
        public void ComWin()
        {
            if (HaveComWin != null)
            {
                HaveComWin();
            }
        }

        // Nhận sự kiện từ Model và gọi lên ChessBoard là Hunman đánh xong
        void HumanDanhXong()
        {
            if (EventHumanDanhXong != null)
            {
                EventHumanDanhXong();
            }
        }

        // Nhận sự kiện từ Model và gọi lên ChessBoard là Com đánh xong
        void ComDanhXong()
        {
            if (EventComDanhXong != null)
            {
                EventComDanhXong();
            }
        }

        // báo cho ChessBoard biết là human đánh xong
        public delegate void HumanDanhXongEventHander();
        public event HumanDanhXongEventHander EventHumanDanhXong;
        // báo cho ChessBoard biết là Com đánh xong
        public delegate void ComDanhXongEventHander();
        public event ComDanhXongEventHander EventComDanhXong;


        // Khai báo các sự kiện Lick vào Row
        public delegate void Row1LickEventHander();
        public event Row1LickEventHander Row1Lick;
        public void OnRow1Lick()
        {
            if (Row1Lick != null)
            {
                Row1Lick();
            }
        }
        public delegate void Row2LickEventHander();
        public event Row2LickEventHander Row2Lick;
        public void OnRow2Lick()
        {
            if (Row2Lick != null)
            {
                Row2Lick();
            }
        }
        public delegate void Row3LickEventHander();
        public event Row3LickEventHander Row3Lick;
        public void OnRow3Lick()
        {
            if (Row3Lick != null)
            {
                Row3Lick();
            }
        }
        public delegate void Row4LickEventHander();
        public event Row4LickEventHander Row4Lick;
        public void OnRow4Lick()
        {
            if (Row4Lick != null)
            {
                Row4Lick();
            }
        }
        public delegate void Row5LickEventHander();
        public event Row5LickEventHander Row5Lick;
        public void OnRow5Lick()
        {
            if (Row5Lick != null)
            {
                Row5Lick();
            }
        }
        public delegate void Row6LickEventHander();
        public event Row6LickEventHander Row6Lick;
        public void OnRow6Lick()
        {
            if (Row6Lick != null)
            {
                Row6Lick();
            }
        }
        public delegate void Row7LickEventHander();
        public event Row7LickEventHander Row7Lick;
        public void OnRow7Lick()
        {
            if (Row7Lick != null)
            {
                Row7Lick();
            }
        }
        public delegate void Row8LickEventHander();
        public event Row8LickEventHander Row8Lick;
        public void OnRow8Lick()
        {
            if (Row8Lick != null)
            {
                Row8Lick();
            }
        }
        public delegate void Row9LickEventHander();
        public event Row9LickEventHander Row9Lick;
        public void OnRow9Lick()
        {
            if (Row9Lick != null)
            {
                Row9Lick();
            }
        }
        public delegate void Row10LickEventHander();
        public event Row10LickEventHander Row10Lick;
        public void OnRow10Lick()
        {
            if (Row10Lick != null)
            {
                Row10Lick();
            }
        }
        public delegate void Row11LickEventHander();
        public event Row11LickEventHander Row11Lick;
        public void OnRow11Lick()
        {
            if (Row11Lick != null)
            {
                Row11Lick();
            }
        }
        public delegate void Row12LickEventHander();
        public event Row12LickEventHander Row12Lick;
        public void OnRow12Lick()
        {
            if (Row12Lick != null)
            {
                Row12Lick();
            }
        }

        // Tạo sự kiện máy đánh xong để Ghi lên bàn cờ
        public delegate void WriteChessBoardEventHander();
        public event WriteChessBoardEventHander WriteChessBoard;
        public void OnWriteChessBoard()
        {
            if (WriteChessBoard != null)
            {
                WriteChessBoard();
            }
        }

        void XuLySuKienGhiLenGD()
        {
            if (m_Y == 1)
                OnRow1Lick();
            else if (m_Y == 2)
                OnRow2Lick();
            else if (m_Y == 3)
                OnRow3Lick();
            else if (m_Y == 4)
                OnRow4Lick();
            else if (m_Y == 5)
                OnRow5Lick();
            else if (m_Y == 6)
                OnRow6Lick();
            else if (m_Y == 7)
                OnRow7Lick();
            else if (m_Y == 8)
                OnRow8Lick();
            else if (m_Y == 9)
                OnRow9Lick();
            else if (m_Y == 10)
                OnRow10Lick();
            else if (m_Y == 11)
                OnRow11Lick();
            else if (m_Y == 12)
                OnRow12Lick();
        }


        private void btn_C1_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 1;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
        }

        private void btn_C2_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 2;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
           
        }

        private void btn_C3_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 3;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
            
        }

        private void btn_C4_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 4;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
        }

        private void btn_C5_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 5;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
        }

        private void btn_C6_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 6;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
        }

        private void btn_C7_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 7;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
        }

        private void btn_C8_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 8;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
        }

        private void btn_C9_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 9;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
        }

        private void btn_C10_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 10;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
        }

        private void btn_C11_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 11;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
        }

        private void btn_C12_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 12;
            m_Y = Y;
            if (TypePlay == 0)
            {
                temp = BanCo.PlayAt(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
            }
            if (TypePlay == 1)
            {
                temp = BanCo.PlayAtHuman(m_X, m_Y);
                if (temp) XuLySuKienGhiLenGD();
                BanCo.PlayAtCom();
                m_X = BanCo.c;
                m_Y = BanCo.r;
                OnWriteChessBoard();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Y % 2 == 1)
            {
                btn_C1_Y.Background = Brushes.DarkGray;
                btn_C3_Y.Background = Brushes.DarkGray;
                btn_C5_Y.Background = Brushes.DarkGray;
                btn_C7_Y.Background = Brushes.DarkGray;
                btn_C9_Y.Background = Brushes.DarkGray;
                btn_C11_Y.Background = Brushes.DarkGray;

                btn_C2_Y.Background = Brushes.White;
                btn_C4_Y.Background = Brushes.White;
                btn_C6_Y.Background = Brushes.White;
                btn_C8_Y.Background = Brushes.White;
                btn_C10_Y.Background = Brushes.White;
                btn_C12_Y.Background = Brushes.White;
            }
            if (Y % 2 == 0)
            {
                btn_C2_Y.Background = Brushes.DarkGray;
                btn_C4_Y.Background = Brushes.DarkGray;
                btn_C6_Y.Background = Brushes.DarkGray;
                btn_C8_Y.Background = Brushes.DarkGray;
                btn_C10_Y.Background = Brushes.DarkGray;
                btn_C12_Y.Background = Brushes.DarkGray;

                btn_C1_Y.Background = Brushes.White;
                btn_C3_Y.Background = Brushes.White;
                btn_C5_Y.Background = Brushes.White;
                btn_C7_Y.Background = Brushes.White;
                btn_C9_Y.Background = Brushes.White;
                btn_C11_Y.Background = Brushes.White;
            }
        }

        public void ChangeColor(Button temp)
        {
            temp.Background = brushes;
        }

        Button CheckButon(int X, int Y)
        {
            switch (X)
            {
                case 1:
                    {
                        return btn_C1_Y;
                    }
                case 2:
                    {
                        return btn_C2_Y;
                    }
                case 3:
                    {
                        return btn_C3_Y;
                    }
                case 4:
                    {
                        return btn_C4_Y;
                    }
                case 5:
                    {
                        return btn_C5_Y;
                    }
                case 6:
                    {
                        return btn_C6_Y;
                    }
                case 7:
                    {
                        return btn_C7_Y;
                    }
                case 8:
                    {
                        return btn_C8_Y;
                    }
                case 9:
                    {
                        return btn_C9_Y;
                    }
                case 10:
                    {
                        return btn_C10_Y;
                    }
                case 11:
                    {
                        return btn_C11_Y;
                    }
                case 12:
                    {
                        return btn_C12_Y;
                    }
                default:
                    {
                        return btn_C1_Y;
                    }
            }
        }
    }
}
