using _1312658.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1312658.ViewModel
{
    class BoardViewModel
    {
        public ChessBoard CurrentBoard{get; set;}

        public BoardViewModel()
        {
            CurrentBoard = new ChessBoard();
        }
    }
}
