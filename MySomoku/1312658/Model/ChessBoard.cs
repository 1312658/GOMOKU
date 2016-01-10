using _1312658.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1312658.Model
{
    struct Node
    {
        public int Row;
        public int Column;
        public Node(int rw, int cl)
        {
            this.Row = rw;
            this.Column = cl;
        }
    }


    class ChessBoard
    {
        public int BoardSize { get; set; }
        public CellValues[,] Cells { get; set; }
        public CellValues ActivePlayer { get; set; }

        public event PlayerWinHandler OnPlayerWin;
        public event SteppCom OnStepp;

        public int[] PhongThu = new int[5] { 0, 1, 9, 85, 769 };
        public int[] TanCong = new int[5] { 0, 2, 28, 256, 2308 };

        private BangLuongGiacBanCo eBoard; //Bảng lượng giá bàn cờ

        public int m_TypePlay { get; set; }
        public ChessBoard()
        {
            BoardSize = Settings.Default.BOARD_SIZE;
            Cells = new CellValues[BoardSize, BoardSize];
            ActivePlayer = CellValues.Player1;
            eBoard = new BangLuongGiacBanCo(this);
            ResetBoard();
        }

        void CheckWin(int row, int col)
        {
            if (CountPlayerItem(row, col, 1, 0) >= 5
               || CountPlayerItem(row, col, 0, 1) >= 5
               || CountPlayerItem(row, col, 1, 1) >= 5
               || CountPlayerItem(row, col, 1, -1) >= 5)
            {
                if (OnPlayerWin != null)
                    OnPlayerWin(player: ActivePlayer);
                return;
            }
        }

        public bool CheckNone(int row, int col)
        {
            if (Cells[row, col] == CellValues.Player1 || Cells[row, col] == CellValues.Player2)
                return false;
            else return true;
        }

        public void PlayAt(int row, int col, int m_Type)
        {
            if(CheckNone(row, col))
            {
                m_TypePlay = m_Type;
                Cells[row, col] = ActivePlayer;
                // Check win state
                // Vertiacal check
                CheckWin(row, col);

                if (m_TypePlay == 1)
                {
                    if (ActivePlayer == CellValues.Player1)
                        ActivePlayer = CellValues.Player2;
                    else
                    {
                        ActivePlayer = CellValues.Player1;
                    }
                }

                else if (m_TypePlay == 2)
                {
                    if (ActivePlayer == CellValues.Player1)
                    {
                        ActivePlayer = CellValues.Player2;

                        Point step = AutoPlay();
                        Cells[(int)step.X, (int)step.Y] = ActivePlayer;
                        OnStepp((int)step.X, (int)step.Y);

                        // Kiem tra thang thua cho com
                        CheckWin((int)step.X, (int)step.Y);
                        ActivePlayer = CellValues.Player1;
                    }
                    else
                    {
                        ActivePlayer = CellValues.Player1;
                    }
                }
            }
        }

        private bool IsInBoard(int row, int col)
        {
            return row >= 0 && row < BoardSize && col >= 0 && col < BoardSize;
        }

        public Point AutoPlay()
        {
            Node node = new Node();
            eBoard.ResetBoard();
            LuongGia(CellValues.Player2);//Lượng giá bàn cờ cho máy
            node = eBoard.GetMaxNode();//lưu vị trí máy sẽ đánh
            int r = node.Row;
            int c = node.Column;
            Cells[r, c] = ActivePlayer; //Lưu loại cờ vừa đánh vào mảng
            return new Point(r,c);
        }

        private void LuongGia(CellValues player)
        {
            int cntHuman = 0, cntCom = 0;//Biến đếm Human,Com
            #region Luong gia cho hang
            int row = Settings.Default.BOARD_SIZE;
            int column = Settings.Default.BOARD_SIZE;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column - 4; j++)
                {
                    //Khởi tạo biến đếm
                    cntHuman = cntCom = 0;
                    //Đếm số lượng con cờ trên 5 ô kế tiếp của 1 hàng
                    for (int k = 0; k < 5; k++)
                    {
                        if (Cells[i, j + k] == CellValues.Player1) cntHuman++;
                        if (Cells[i, j + k] == CellValues.Player2) cntCom++;
                    }
                    //Lượng giá
                    //Nếu 5 ô kế tiếp chỉ có 1 loại cờ (hoặc là Human,hoặc la Com)
                    if (cntHuman * cntCom == 0 && cntHuman != cntCom)
                    {
                        //Gán giá trị cho 5 ô kế tiếp của 1 hàng
                        for (int k = 0; k < 5; k++)
                        {
                            //Nếu ô đó chưa có quân đi
                            if (Cells[i, j + k] == CellValues.None)
                            {
                                //Nếu trong 5 ô đó chỉ tồn tại cờ của Human
                                if (cntCom == 0)
                                {
                                    //Nếu đối tượng lượng giá là Com
                                    if (player == CellValues.Player2)
                                    {
                                        //Vì đối tượng người chơi là Com mà trong 5 ô này chỉ có Human
                                        //nên ta sẽ cộng thêm điểm phòng thủ cho Com
                                        eBoard.GiaTri[i, j + k] += PhongThu[cntHuman];
                                    }
                                    //Ngược lại cộng điểm phòng thủ cho Human
                                    else
                                    {
                                        eBoard.GiaTri[i, j + k] += TanCong[cntHuman];
                                    }
                                }
                                //Tương tự như trên
                                if (cntHuman == 0) //Nếu chỉ tồn tại Com
                                {
                                    if (player == CellValues.Player1) //Nếu người chơi là Người
                                    {
                                        eBoard.GiaTri[i, j + k] += PhongThu[cntCom];
                                    }
                                    else
                                    {
                                        eBoard.GiaTri[i, j + k] += TanCong[cntCom];
                                    }

                                }
                                if ((j + k - 1 > 0) && (j + k + 1 <= column - 1) && (cntHuman == 4 || cntCom == 4)
                                   && (Cells[i, j + k - 1] == CellValues.None || Cells[i, j + k + 1] == CellValues.None))
                                {
                                    eBoard.GiaTri[i, j + k] *= 3;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            //Tương tự như lượng giá cho hàng
            #region Luong gia cho cot
            for (int i = 0; i < row - 4; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    cntHuman = cntCom = 0;
                    for (int k = 0; k < 5; k++)
                    {
                        if (Cells[i + k, j] == CellValues.Player1) cntHuman++;
                        if (Cells[i + k, j] == CellValues.Player2) cntCom++;
                    }
                    if (cntHuman * cntCom == 0 && cntCom != cntHuman)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (Cells[i + k, j] == CellValues.None)
                            {
                                if (cntCom == 0)
                                {
                                    if (player == CellValues.Player1) eBoard.GiaTri[i + k, j] += PhongThu[cntHuman];
                                    else eBoard.GiaTri[i + k, j] += TanCong[cntHuman];
                                    // Truong hop bi chan 2 dau.
                                    if ((i - 1) >= 0 && (i + 5) <= row - 1 && Cells[i - 1, j] == CellValues.Player2 && Cells[i + 5, j] == CellValues.Player2)
                                    {
                                        eBoard.GiaTri[i + k, j] = 0;
                                    }
                                }
                                if (cntHuman == 0)
                                {
                                    if (player == CellValues.Player1) eBoard.GiaTri[i + k, j] += PhongThu[cntCom];
                                    else eBoard.GiaTri[i + k, j] += TanCong[cntCom];
                                }
                                if ((i + k - 1) >= 0 && (i + k + 1) <= row - 1 && (cntHuman == 4 || cntCom == 4)
                                    && (Cells[i + k - 1, j] == CellValues.None || Cells[i + k + 1, j] == CellValues.None))
                                {
                                    eBoard.GiaTri[i + k, j] *= 3;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            //Tương tự như lượng giá cho hàng
            #region  Luong gia tren duong cheo chinh (\)
            for (int i = 0; i < row - 4; i++)
            {
                for (int j = 0; j < column - 4; j++)
                {
                    cntHuman = cntCom = 0;
                    for (int k = 0; k < 5; k++)
                    {
                        if (Cells[i + k, j + k] == CellValues.Player1) cntHuman++;
                        if (Cells[i + k, j + k] == CellValues.Player2) cntCom++;
                    }
                    if (cntHuman * cntCom == 0 && cntCom != cntHuman)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (Cells[i + k, j + k] == CellValues.None)
                            {
                                if (cntCom == 0)
                                {
                                    if (player == CellValues.Player1) eBoard.GiaTri[i + k, j + k] += PhongThu[cntHuman];
                                    else eBoard.GiaTri[i + k, j + k] += TanCong[cntHuman];
                                }
                                if (cntHuman == 0)
                                {
                                    if (player == CellValues.Player1) eBoard.GiaTri[i + k, j + k] += PhongThu[cntCom];
                                    else eBoard.GiaTri[i + k, j + k] += TanCong[cntCom];
                                }
                                if ((i + k - 1) >= 0 && (j + k - 1) >= 0 && (i + k + 1) <= row - 1 && (j + k + 1) <= column - 1 && (cntHuman == 4 || cntCom == 4)
                                    && (Cells[i + k - 1, j + k - 1] == CellValues.None || Cells[i + k + 1, j + k + 1] == CellValues.None))
                                {
                                    eBoard.GiaTri[i + k, j + k] *= 3;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            //Tương tự như lượng giá cho hàng
            #region Luong gia tren duong cheo phu (/)
            for (int i = 4; i < row - 4; i++)
            {
                for (int j = 0; j < column - 4; j++)
                {
                    cntCom = 0; cntHuman = 0;
                    for (int k = 0; k < 5; k++)
                    {
                        if (Cells[i - k, j + k] == CellValues.Player1) cntHuman++;
                        if (Cells[i - k, j + k] == CellValues.Player2) cntCom++;
                    }
                    if (cntHuman * cntCom == 0 && cntHuman != cntCom)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (Cells[i - k, j + k] == CellValues.None)
                            {
                                if (cntCom == 0)
                                {
                                    if (player == CellValues.Player1) eBoard.GiaTri[i - k, j + k] += PhongThu[cntHuman];
                                    else eBoard.GiaTri[i - k, j + k] += TanCong[cntHuman];
                                    // Truong hop bi chan 2 dau.
                                    if (i + 1 <= row - 1 && j - 1 >= 0 && i - 5 >= 0 && j + 5 <= column - 1 && Cells[i + 1, j - 1] == CellValues.Player1 && Cells[i - 5, j + 5] == CellValues.Player1)
                                    {
                                        eBoard.GiaTri[i - k, j + k] = 0;
                                    }
                                }
                                if (cntHuman == 0)
                                {
                                    if (player == CellValues.Player1) eBoard.GiaTri[i - k, j + k] += PhongThu[cntCom];
                                    else eBoard.GiaTri[i - k, j + k] += TanCong[cntCom];
                                }
                                if ((i - k + 1) <= row - 1 && (j + k - 1) >= 0
                                    && (i - k - 1) >= 0 && (j + k + 1) <= column - 1
                                    && (cntHuman == 4 || cntCom == 4)
                                    && (Cells[i - k + 1, j + k - 1] == CellValues.None || Cells[i - k - 1, j + k + 1] == CellValues.None))
                                {
                                    eBoard.GiaTri[i - k, j + k] *= 3;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }

        public void ResetBoard()
        {
            for (int i = 0; i < Settings.Default.BOARD_SIZE; i++)
            {
                for (int j = 0; j < Settings.Default.BOARD_SIZE; j++)
                {
                    Cells[i, j] = CellValues.None;
                }
            }
        }
        
        private int CountPlayerItem(int row, int col, int drow, int dcol)
        {
            int crow = row + drow;
            int ccol = col + dcol;
            int count = 1;
            while (IsInBoard(crow, ccol) && Cells[crow, ccol] == ActivePlayer)
            {
                count++;
                crow = crow + drow;
                ccol = ccol + dcol;
            }
            crow = row - drow;
            ccol = col - dcol;
            while (IsInBoard(crow, ccol) && Cells[crow, ccol] == ActivePlayer)
            {
                count++;
                crow = crow - drow;
                ccol = ccol - dcol;
            }
            return count;
        }
        }

        public delegate void PlayerWinHandler(CellValues player);

    public delegate void SteppCom(int X, int Y);
    public enum CellValues { None = 0, Player1 = 1, Player2 = 2 }
}
