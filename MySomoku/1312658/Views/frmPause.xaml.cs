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
    /// Interaction logic for frmPause.xaml
    /// </summary>
    public partial class frmPause : Window
    {
        public frmPause()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Frm_Menu FrmMenu = new Frm_Menu();
            if (exitGame != null)
                exitGame();
            FrmMenu.ShowDialog();
        }

        private void btn_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("GOMOKU - Lê Anh Tuấn - 1312658");
        }

        private void btn_Continue_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btn_NewGame_Click(object sender, RoutedEventArgs e)
        {
            if (newGame != null)
                newGame();
            this.Hide();
        }


        // event thoát game
        public delegate void exitGame_ChangedHandler();
        public event exitGame_ChangedHandler exitGame;

        public delegate void newGame_ChangedHandler();
        public event newGame_ChangedHandler newGame;
    }
}
