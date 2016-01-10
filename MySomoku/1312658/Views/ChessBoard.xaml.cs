using _1312658.Model;
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
    public partial class ChessBoard : UserControl
    {
        Board BanCo = new Board();
        SolidColorBrush color = Brushes.Yellow;
        int X, Y;
        public int TypePlay;
        public ChessBoard()
        {
            InitializeComponent();
            my_Row_R1.HumanWin();
            my_Row_R1.ComWin();
            // Bắt sự kiên thắng
            my_Row_R1.HaveComWin += new My_Row.HaveComWinEventHander(Win1);
            my_Row_R1.HaveHumanWin += new My_Row.HaveHumanWinEventHander(Win2);
            // Bắt sự kiện đổi lượt
            my_Row_R1.EventHumanDanhXong += new My_Row.HumanDanhXongEventHander(HumanDanhXong);
            my_Row_R1.EventComDanhXong += new My_Row.ComDanhXongEventHander(ComDanhXong);
            // Bắt sự kiện lick
            my_Row_R1.Row1Lick += new My_Row.Row1LickEventHander(HienThiGiaoDien1);
            my_Row_R2.Row2Lick += new My_Row.Row2LickEventHander(HienThiGiaoDien2);
            my_Row_R3.Row3Lick += new My_Row.Row3LickEventHander(HienThiGiaoDien3);
            my_Row_R4.Row4Lick += new My_Row.Row4LickEventHander(HienThiGiaoDien4);
            my_Row_R5.Row5Lick += new My_Row.Row5LickEventHander(HienThiGiaoDien5);
            my_Row_R6.Row6Lick += new My_Row.Row6LickEventHander(HienThiGiaoDien6);
            my_Row_R7.Row7Lick += new My_Row.Row7LickEventHander(HienThiGiaoDien7);
            my_Row_R8.Row8Lick += new My_Row.Row8LickEventHander(HienThiGiaoDien8);
            my_Row_R9.Row9Lick += new My_Row.Row9LickEventHander(HienThiGiaoDien9);
            my_Row_R10.Row10Lick += new My_Row.Row10LickEventHander(HienThiGiaoDien10);
            my_Row_R11.Row11Lick += new My_Row.Row11LickEventHander(HienThiGiaoDien11);
            my_Row_R12.Row12Lick += new My_Row.Row12LickEventHander(HienThiGiaoDien12);


            my_Row_R1.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien1);
            my_Row_R2.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien2);
            my_Row_R3.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien3);
            my_Row_R4.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien4);
            my_Row_R5.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien5);
            my_Row_R6.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien6);
            my_Row_R7.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien7);
            my_Row_R8.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien8);
            my_Row_R9.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien9);
            my_Row_R10.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien10);
            my_Row_R11.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien11);
            my_Row_R12.WriteChessBoard += new My_Row.WriteChessBoardEventHander(HienThiGiaoDien12);

        }

        void HumanDanhXong()
        {
            color = Brushes.Red;
        }

        void ComDanhXong()
        {
            color = Brushes.Black;
        }


        // Khai báo sự kiện đã có người thắng cho Main
        public delegate void HaveWinEventHander();
        public event HaveWinEventHander HaveWin;
        public void HaveOnWin()
        {
            if (HaveWin != null)
            {
                HaveWin();
            }
        }

        public void HienThiGiaoDien1()
        {
            if (my_Row_R1.X == 1)
                my_Row_R1.btn_C1_Y.Background = color;
            else if (my_Row_R1.X == 2)
                my_Row_R1.btn_C2_Y.Background = color;
            else if (my_Row_R1.X == 3)
                my_Row_R1.btn_C3_Y.Background = color;
            else if (my_Row_R1.X == 4)
                my_Row_R1.btn_C4_Y.Background = color;
            else if (my_Row_R1.X == 5)
                my_Row_R1.btn_C5_Y.Background = color;
            else if (my_Row_R1.X == 6)
                my_Row_R1.btn_C6_Y.Background = color;
            else if (my_Row_R1.X == 7)
                my_Row_R1.btn_C7_Y.Background = color;
            else if (my_Row_R1.X == 8)
                my_Row_R1.btn_C8_Y.Background = color;
            else if (my_Row_R1.X == 9)
                my_Row_R1.btn_C9_Y.Background = color;
            else if (my_Row_R1.X == 10)
                my_Row_R1.btn_C10_Y.Background = color;
            else if (my_Row_R1.X == 11)
                my_Row_R1.btn_C11_Y.Background = color;
            else if (my_Row_R1.X == 12)
                my_Row_R1.btn_C12_Y.Background = color;
        }

        public void HienThiGiaoDien2()
        {
            if (my_Row_R2.X == 1)
                my_Row_R2.btn_C1_Y.Background = color;
            else if (my_Row_R2.X == 2)
                my_Row_R2.btn_C2_Y.Background = color;
            else if (my_Row_R2.X == 3)
                my_Row_R2.btn_C3_Y.Background = color;
            else if (my_Row_R2.X == 4)
                my_Row_R2.btn_C4_Y.Background = color;
            else if (my_Row_R2.X == 5)
                my_Row_R2.btn_C5_Y.Background = color;
            else if (my_Row_R2.X == 6)
                my_Row_R2.btn_C6_Y.Background = color;
            else if (my_Row_R2.X == 7)
                my_Row_R2.btn_C7_Y.Background = color;
            else if (my_Row_R2.X == 8)
                my_Row_R2.btn_C8_Y.Background = color;
            else if (my_Row_R2.X == 9)
                my_Row_R2.btn_C9_Y.Background = color;
            else if (my_Row_R2.X == 10)
                my_Row_R2.btn_C10_Y.Background = color;
            else if (my_Row_R2.X == 11)
                my_Row_R2.btn_C11_Y.Background = color;
            else if (my_Row_R2.X == 12)
                my_Row_R2.btn_C12_Y.Background = color;
        }

        public void HienThiGiaoDien3()
        {
            if (my_Row_R3.X == 1)
                my_Row_R3.btn_C1_Y.Background = color;
            else if (my_Row_R3.X == 2)
                my_Row_R3.btn_C2_Y.Background = color;
            else if (my_Row_R3.X == 3)
                my_Row_R3.btn_C3_Y.Background = color;
            else if (my_Row_R3.X == 4)
                my_Row_R3.btn_C4_Y.Background = color;
            else if (my_Row_R3.X == 5)
                my_Row_R3.btn_C5_Y.Background = color;
            else if (my_Row_R3.X == 6)
                my_Row_R3.btn_C6_Y.Background = color;
            else if (my_Row_R3.X == 7)
                my_Row_R3.btn_C7_Y.Background = color;
            else if (my_Row_R3.X == 8)
                my_Row_R3.btn_C8_Y.Background = color;
            else if (my_Row_R3.X == 9)
                my_Row_R3.btn_C9_Y.Background = color;
            else if (my_Row_R3.X == 10)
                my_Row_R3.btn_C10_Y.Background = color;
            else if (my_Row_R3.X == 11)
                my_Row_R3.btn_C11_Y.Background = color;
            else if (my_Row_R3.X == 12)
                my_Row_R3.btn_C12_Y.Background = color;
        }

        public void HienThiGiaoDien4()
        {
            if (my_Row_R4.X == 1)
                my_Row_R4.btn_C1_Y.Background = color;
            else if (my_Row_R4.X == 2)
                my_Row_R4.btn_C2_Y.Background = color;
            else if (my_Row_R4.X == 3)
                my_Row_R4.btn_C3_Y.Background = color;
            else if (my_Row_R4.X == 4)
                my_Row_R4.btn_C4_Y.Background = color;
            else if (my_Row_R4.X == 5)
                my_Row_R4.btn_C5_Y.Background = color;
            else if (my_Row_R4.X == 6)
                my_Row_R4.btn_C6_Y.Background = color;
            else if (my_Row_R4.X == 7)
                my_Row_R4.btn_C7_Y.Background = color;
            else if (my_Row_R4.X == 8)
                my_Row_R4.btn_C8_Y.Background = color;
            else if (my_Row_R4.X == 9)
                my_Row_R4.btn_C9_Y.Background = color;
            else if (my_Row_R4.X == 10)
                my_Row_R4.btn_C10_Y.Background = color;
            else if (my_Row_R4.X == 11)
                my_Row_R4.btn_C11_Y.Background = color;
            else if (my_Row_R4.X == 12)
                my_Row_R4.btn_C12_Y.Background = color;
        }

        public void HienThiGiaoDien5()
        {
            if (my_Row_R5.X == 1)
                my_Row_R5.btn_C1_Y.Background = color;
            else if (my_Row_R5.X == 2)
                my_Row_R5.btn_C2_Y.Background = color;
            else if (my_Row_R5.X == 3)
                my_Row_R5.btn_C3_Y.Background = color;
            else if (my_Row_R5.X == 4)
                my_Row_R5.btn_C4_Y.Background = color;
            else if (my_Row_R5.X == 5)
                my_Row_R5.btn_C5_Y.Background = color;
            else if (my_Row_R5.X == 6)
                my_Row_R5.btn_C6_Y.Background = color;
            else if (my_Row_R5.X == 7)
                my_Row_R5.btn_C7_Y.Background = color;
            else if (my_Row_R5.X == 8)
                my_Row_R5.btn_C8_Y.Background = color;
            else if (my_Row_R5.X == 9)
                my_Row_R5.btn_C9_Y.Background = color;
            else if (my_Row_R5.X == 10)
                my_Row_R5.btn_C10_Y.Background = color;
            else if (my_Row_R5.X == 11)
                my_Row_R5.btn_C11_Y.Background = color;
            else if (my_Row_R5.X == 12)
                my_Row_R5.btn_C12_Y.Background = color;
        }

        public void HienThiGiaoDien6()
        {
            if (my_Row_R6.X == 1)
                my_Row_R6.btn_C1_Y.Background = color;
            else if (my_Row_R6.X == 2)
                my_Row_R6.btn_C2_Y.Background = color;
            else if (my_Row_R6.X == 3)
                my_Row_R6.btn_C3_Y.Background = color;
            else if (my_Row_R6.X == 4)
                my_Row_R6.btn_C4_Y.Background = color;
            else if (my_Row_R6.X == 5)
                my_Row_R6.btn_C5_Y.Background = color;
            else if (my_Row_R6.X == 6)
                my_Row_R6.btn_C6_Y.Background = color;
            else if (my_Row_R6.X == 7)
                my_Row_R6.btn_C7_Y.Background = color;
            else if (my_Row_R6.X == 8)
                my_Row_R6.btn_C8_Y.Background = color;
            else if (my_Row_R6.X == 9)
                my_Row_R6.btn_C9_Y.Background = color;
            else if (my_Row_R6.X == 10)
                my_Row_R6.btn_C10_Y.Background = color;
            else if (my_Row_R6.X == 11)
                my_Row_R6.btn_C11_Y.Background = color;
            else if (my_Row_R6.X == 12)
                my_Row_R6.btn_C12_Y.Background = color;
        }

        public void HienThiGiaoDien7()
        {
            if (my_Row_R7.X == 1)
                my_Row_R7.btn_C1_Y.Background = color;
            else if (my_Row_R7.X == 2)
                my_Row_R7.btn_C2_Y.Background = color;
            else if (my_Row_R7.X == 3)
                my_Row_R7.btn_C3_Y.Background = color;
            else if (my_Row_R7.X == 4)
                my_Row_R7.btn_C4_Y.Background = color;
            else if (my_Row_R7.X == 5)
                my_Row_R7.btn_C5_Y.Background = color;
            else if (my_Row_R7.X == 6)
                my_Row_R7.btn_C6_Y.Background = color;
            else if (my_Row_R7.X == 7)
                my_Row_R7.btn_C7_Y.Background = color;
            else if (my_Row_R7.X == 8)
                my_Row_R7.btn_C8_Y.Background = color;
            else if (my_Row_R7.X == 9)
                my_Row_R7.btn_C9_Y.Background = color;
            else if (my_Row_R7.X == 10)
                my_Row_R7.btn_C10_Y.Background = color;
            else if (my_Row_R7.X == 11)
                my_Row_R7.btn_C11_Y.Background = color;
            else if (my_Row_R7.X == 12)
                my_Row_R7.btn_C12_Y.Background = color;
        }

        public void HienThiGiaoDien8()
        {
            if (my_Row_R8.X == 1)
                my_Row_R8.btn_C1_Y.Background = color;
            else if (my_Row_R8.X == 2)
                my_Row_R8.btn_C2_Y.Background = color;
            else if (my_Row_R8.X == 3)
                my_Row_R8.btn_C3_Y.Background = color;
            else if (my_Row_R8.X == 4)
                my_Row_R8.btn_C4_Y.Background = color;
            else if (my_Row_R8.X == 5)
                my_Row_R8.btn_C5_Y.Background = color;
            else if (my_Row_R8.X == 6)
                my_Row_R8.btn_C6_Y.Background = color;
            else if (my_Row_R8.X == 7)
                my_Row_R8.btn_C7_Y.Background = color;
            else if (my_Row_R8.X == 8)
                my_Row_R8.btn_C8_Y.Background = color;
            else if (my_Row_R8.X == 9)
                my_Row_R8.btn_C9_Y.Background = color;
            else if (my_Row_R8.X == 10)
                my_Row_R8.btn_C10_Y.Background = color;
            else if (my_Row_R8.X == 11)
                my_Row_R8.btn_C11_Y.Background = color;
            else if (my_Row_R8.X == 12)
                my_Row_R8.btn_C12_Y.Background = color;
        }

        public void HienThiGiaoDien9()
        {
            if (my_Row_R9.X == 1)
                my_Row_R9.btn_C1_Y.Background = color;
            else if (my_Row_R9.X == 2)
                my_Row_R9.btn_C2_Y.Background = color;
            else if (my_Row_R9.X == 3)
                my_Row_R9.btn_C3_Y.Background = color;
            else if (my_Row_R9.X == 4)
                my_Row_R9.btn_C4_Y.Background = color;
            else if (my_Row_R9.X == 5)
                my_Row_R9.btn_C5_Y.Background = color;
            else if (my_Row_R9.X == 6)
                my_Row_R9.btn_C6_Y.Background = color;
            else if (my_Row_R9.X == 7)
                my_Row_R9.btn_C7_Y.Background = color;
            else if (my_Row_R9.X == 8)
                my_Row_R9.btn_C8_Y.Background = color;
            else if (my_Row_R9.X == 9)
                my_Row_R9.btn_C9_Y.Background = color;
            else if (my_Row_R9.X == 10)
                my_Row_R9.btn_C10_Y.Background = color;
            else if (my_Row_R9.X == 11)
                my_Row_R9.btn_C11_Y.Background = color;
            else if (my_Row_R9.X == 12)
                my_Row_R9.btn_C12_Y.Background = color;
        }

        public void HienThiGiaoDien10()
        {
            if (my_Row_R10.X == 1)
                my_Row_R10.btn_C1_Y.Background = color;
            else if (my_Row_R10.X == 2)
                my_Row_R10.btn_C2_Y.Background = color;
            else if (my_Row_R10.X == 3)
                my_Row_R10.btn_C3_Y.Background = color;
            else if (my_Row_R10.X == 4)
                my_Row_R10.btn_C4_Y.Background = color;
            else if (my_Row_R10.X == 5)
                my_Row_R10.btn_C5_Y.Background = color;
            else if (my_Row_R10.X == 6)
                my_Row_R10.btn_C6_Y.Background = color;
            else if (my_Row_R10.X == 7)
                my_Row_R10.btn_C7_Y.Background = color;
            else if (my_Row_R10.X == 8)
                my_Row_R10.btn_C8_Y.Background = color;
            else if (my_Row_R10.X == 9)
                my_Row_R10.btn_C9_Y.Background = color;
            else if (my_Row_R10.X == 10)
                my_Row_R10.btn_C10_Y.Background = color;
            else if (my_Row_R10.X == 11)
                my_Row_R10.btn_C11_Y.Background = color;
            else if (my_Row_R10.X == 12)
                my_Row_R10.btn_C12_Y.Background = color;
        }

        public void HienThiGiaoDien11()
        {
            if (my_Row_R11.X == 1)
                my_Row_R11.btn_C1_Y.Background = color;
            else if (my_Row_R11.X == 2)
                my_Row_R11.btn_C2_Y.Background = color;
            else if (my_Row_R11.X == 3)
                my_Row_R11.btn_C3_Y.Background = color;
            else if (my_Row_R11.X == 4)
                my_Row_R11.btn_C4_Y.Background = color;
            else if (my_Row_R11.X == 5)
                my_Row_R11.btn_C5_Y.Background = color;
            else if (my_Row_R11.X == 6)
                my_Row_R11.btn_C6_Y.Background = color;
            else if (my_Row_R11.X == 7)
                my_Row_R11.btn_C7_Y.Background = color;
            else if (my_Row_R11.X == 8)
                my_Row_R11.btn_C8_Y.Background = color;
            else if (my_Row_R11.X == 9)
                my_Row_R11.btn_C9_Y.Background = color;
            else if (my_Row_R11.X == 10)
                my_Row_R11.btn_C10_Y.Background = color;
            else if (my_Row_R11.X == 11)
                my_Row_R11.btn_C11_Y.Background = color;
            else if (my_Row_R11.X == 12)
                my_Row_R11.btn_C12_Y.Background = color;
        }

        public void HienThiGiaoDien12()
        {
            if (my_Row_R12.X == 1)
                my_Row_R12.btn_C1_Y.Background = color;
            else if (my_Row_R12.X == 2)
                my_Row_R12.btn_C2_Y.Background = color;
            else if (my_Row_R12.X == 3)
                my_Row_R12.btn_C3_Y.Background = color;
            else if (my_Row_R12.X == 4)
                my_Row_R12.btn_C4_Y.Background = color;
            else if (my_Row_R12.X == 5)
                my_Row_R12.btn_C5_Y.Background = color;
            else if (my_Row_R12.X == 6)
                my_Row_R12.btn_C6_Y.Background = color;
            else if (my_Row_R12.X == 7)
                my_Row_R12.btn_C7_Y.Background = color;
            else if (my_Row_R12.X == 8)
                my_Row_R12.btn_C8_Y.Background = color;
            else if (my_Row_R12.X == 9)
                my_Row_R12.btn_C9_Y.Background = color;
            else if (my_Row_R12.X == 10)
                my_Row_R12.btn_C10_Y.Background = color;
            else if (my_Row_R12.X == 11)
                my_Row_R12.btn_C11_Y.Background = color;
            else if (my_Row_R12.X == 12)
                my_Row_R12.btn_C12_Y.Background = color;
        }
        public void Win1()
        {
            MessageBox.Show("Đen Thắng!!!");
            HaveOnWin();
        }
        public void Win2()
        {
            MessageBox.Show("Đỏ Thắng!!!");
            HaveOnWin();
        }
    }
}
