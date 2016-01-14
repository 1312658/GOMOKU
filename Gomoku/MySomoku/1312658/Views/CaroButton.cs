using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _1312658.Views
{
    class CaroButton : Button
    {
        public int m_X;
        public int m_Y;

        public int X { get { return m_X; } set { m_X = value; } }
        public int Y { get { return m_Y; } set { m_Y = value; } }
    }
}
