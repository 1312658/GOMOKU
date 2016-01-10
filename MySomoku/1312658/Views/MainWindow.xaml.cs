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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String m_Message;

        public MainWindow()
        {
            InitializeComponent();
            rab_HumanHuman.IsChecked = true;
            ChessBoard.HaveWin += new ChessBoard.HaveWinEventHander(XuLyWin);
        }

        void XuLyWin()
        {
            Close();
        }

        private void btn_Chane_Click(object sender, RoutedEventArgs e)
        {
            m_Message += "\nSERVER\n Welcome ";
            m_Message += txt_Your_Name.Text.ToString() + "!!!!\n" + DateTime.Now.ToString() + "\n -------------------------------------";
            txt_Chat.Text = m_Message; 
        }

        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Input_Chat.Text != "")
            {
                m_Message += "\n" + txt_Your_Name.Text.ToString() + ": " + txt_Input_Chat.Text.ToString() + "\n" + DateTime.Now.ToString() + "\n -------------------------------------";
                txt_Input_Chat.Text = "";
                txt_Chat.Text = m_Message;
            }
        }

        private void rab_HumanHuman_Checked(object sender, RoutedEventArgs e)
        {
            ChessBoard.TypePlay = 0;
            ChessBoard.my_Row_R1.TypePlay = 0;

        }

        private void rab_HumanCom_Checked(object sender, RoutedEventArgs e)
        {
            ChessBoard.TypePlay = 1;
            ChessBoard.my_Row_R1.TypePlay = 1;
            ChessBoard.my_Row_R2.TypePlay = 1;
            ChessBoard.my_Row_R3.TypePlay = 1;
            ChessBoard.my_Row_R4.TypePlay = 1;
            ChessBoard.my_Row_R5.TypePlay = 1;
            ChessBoard.my_Row_R6.TypePlay = 1;
            ChessBoard.my_Row_R7.TypePlay = 1;
            ChessBoard.my_Row_R8.TypePlay = 1;
            ChessBoard.my_Row_R9.TypePlay = 1;
            ChessBoard.my_Row_R10.TypePlay = 1;
            ChessBoard.my_Row_R11.TypePlay = 1;
            ChessBoard.my_Row_R12.TypePlay = 1;
        }
    }
}
