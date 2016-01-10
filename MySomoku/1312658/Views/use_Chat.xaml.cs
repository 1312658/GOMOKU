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
    /// Interaction logic for use_Chat.xaml
    /// </summary>
    public partial class use_Chat : UserControl
    {
        public string m_Message { get; set; }
        public int m_TypePlay { get; set; }

        public string m_NameHuman { get; set; }

        public use_Chat()
        {
            InitializeComponent();
        }

        private void btn_Chane_Click(object sender, RoutedEventArgs e)
        {
            m_Message = "\nSERVER\n Welcome ";
            m_Message += txt_Your_Name.Text.ToString() + "!!!!\n" + DateTime.Now.ToString() + "\n -------------------------------------";

            txt_Chat.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            txt_Chat.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            txt_Chat.Items.Add(m_Message);

            if (m_TypePlay == 3 || m_TypePlay == 4)
                if (ChangeName_changed != null)
                    ChangeName_changed(txt_Your_Name.Text);
        }

        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Input_Chat.Text != "")
            {
                if (m_TypePlay == 1 || m_TypePlay == 2)
                {
                    m_Message = "\n" + txt_Your_Name.Text.ToString() + ": " + txt_Input_Chat.Text.ToString() + "\n" + DateTime.Now.ToString() + "\n -------------------------------------";
                    txt_Input_Chat.Text = "";
                    txt_Chat.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    txt_Chat.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    txt_Chat.Items.Add(m_Message);
                }
                else if (m_TypePlay == 3 || m_TypePlay == 4)
                {
                    m_Message = txt_Input_Chat.Text.ToString() + "\n";
                    txt_Input_Chat.Text = "";
                    if (SenMessageSever_changed != null)
                        SenMessageSever_changed(m_Message);
                }
            }
        }

        public void ShowChat(string message,string namePlayer2)
        {
             if (message == m_Message)
                    this.Dispatcher.Invoke((Action)(() => { txt_Chat.Items.Add("\n" + txt_Your_Name.Text + ": " + message + "\n" + DateTime.Now.ToString() + "\n -------------------------------------"); }));
              else
                 this.Dispatcher.Invoke((Action)(() => { txt_Chat.Items.Add("\n" + namePlayer2 + ": " + message + "\n\n" + DateTime.Now.ToString() + "\n -------------------------------------"); }));
        }


        public void ChatWeCome(int m_Type)
        {
            switch(m_Type)
            {
                case 1:
                    txt_Chat.Items.Add("Chào mừng bạn đến với Game: \n GOMOKU - Lê Anh Tuấn \n Bạn đang chọn chế độ chơi thủ công giữa 2 người \n Player 1 (đỏ): Đi trước \n Player 2 (xanh): Đi thứ 2");
                    break;
                case 2:
                    txt_Chat.Items.Add("Chào mừng bạn đến với Game: \n GOMOKU - Lê Anh Tuấn \n Bạn đang chọn chế độ giữa người và máy \n Bạn là người đi trước \n Player 1 (đỏ): Đi trước \n Player 2 (xanh): Đi thứ 2");
                    break;
                case 3:
                    txt_Chat.Items.Add("Chào mừng bạn đến với Game: \n GOMOKU - Lê Anh Tuấn \n Bạn đang chọn chế độ chơi online 1 người \n Player 1 (đỏ) \n Player 2 (xanh)");
                    break;
                case 4:
                    txt_Chat.Items.Add("Chào mừng bạn đến với Game: \n GOMOKU - Lê Anh Tuấn \n Bạn đang chọn chế độ chơi auto online \n Player 1 (đỏ) \n Player 2 (xanh)");
                    break;
            }
        }
        public delegate void ChangeName_ChangedHandler(string name);
        public event ChangeName_ChangedHandler ChangeName_changed;

        public delegate void SenMessageSever_ChangedHandler(string Message);
        public event SenMessageSever_ChangedHandler SenMessageSever_changed;
    }
}
