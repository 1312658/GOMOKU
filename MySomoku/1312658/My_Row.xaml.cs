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

namespace _1312658
{
    /// <summary>
    /// Interaction logic for My_Row.xaml
    /// </summary>
    public partial class My_Row : UserControl
    {
        int m_X;
        int m_Y;

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
            
        }

        private void btn_C1_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 1;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
        }

        private void btn_C2_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 2;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
        }

        private void btn_C3_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 3;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
        }

        private void btn_C4_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 4;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
        }

        private void btn_C5_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 5;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
        }

        private void btn_C6_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 6;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
        }

        private void btn_C7_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 7;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
        }

        private void btn_C8_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 8;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
        }

        private void btn_C9_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 9;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
        }

        private void btn_C10_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 10;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
        }

        private void btn_C11_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 11;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
        }

        private void btn_C12_Y_Click(object sender, RoutedEventArgs e)
        {
            m_X = 12;
            m_Y = Y;
            MessageBox.Show(m_X.ToString() + ", " + m_Y.ToString());
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
    }
}
