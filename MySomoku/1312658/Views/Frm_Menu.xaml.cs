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
using System.Windows.Shapes;

namespace _1312658.Views
{
    /// <summary>
    /// Interaction logic for Frm_Menu.xaml
    /// </summary>
    public partial class Frm_Menu : Window
    {
        public Frm_Menu()
        {
            InitializeComponent();
        }

        private void btn_Menu_2Player_Click(object sender, RoutedEventArgs e)
        {
            MainWindow FrmMain = new MainWindow(1);
            FrmMain.ChessBoardMain.Disconnection();
            this.Close();
            FrmMain.ShowDialog();
        }

        private void btn_Menu_PlayWComputer_Click(object sender, RoutedEventArgs e)
        {
            MainWindow FrmMain = new MainWindow(2);
            FrmMain.ChessBoardMain.Disconnection();
            this.Close();
            FrmMain.ShowDialog();
        }

        private void btn_Menu_ConectionSever_Click(object sender, RoutedEventArgs e)
        {
            MainWindow FrmMain = new MainWindow(3);
            this.Close();
            FrmMain.ShowDialog();
        }

        private void btn_Menu_OnLineAuto_Click(object sender, RoutedEventArgs e)
        {
            MainWindow FrmMain = new MainWindow(4);
            this.Close();
            FrmMain.ShowDialog();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("GOMOKU - Lê Anh Tuấn - 1312658");
        }

    }
}
