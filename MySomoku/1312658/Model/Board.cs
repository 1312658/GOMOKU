using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _1312658.Model
{
    enum Player
    {
        None = 0,
        Human = 1,
        Com = 2,
    }

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

    public class Board
    {
        Player currPlayer = Player.Human; //lượt đi
        Player end; //lượt đi
        Player[,] board = new Player[13, 13];
        private int row =12, column = 12; //Số hàng, cột
        public int r, c; // Bước đi của máy
        private BangLuongGiacBanCo eBoard; //Bảng lượng giá bàn cờ
        public int[] PhongThu = new int[5] { 0, 1, 9, 85, 769 };
        public int[] TanCong = new int[5] { 0, 2, 28, 256, 2308 };
        public Board()
        {
            eBoard = new BangLuongGiacBanCo(this);
        }


        public int Row
        {
            get { return this.row; }
        }
        public int Column
        {
            get { return this.column; }
        }




        public delegate void EventHumanDanhXong();
        public event EventHumanDanhXong HumanDanhXong;
        private void OnHumanDanhXong()
        {
            if (HumanDanhXong != null)
            {
                HumanDanhXong();
            }
        }

        public delegate void EventComDanhXong();
        public event EventComDanhXong ComDanhXong;
        private void OnComDanhXong()
        {
            if (HumanDanhXong != null)
            {
                ComDanhXong();
            }
        }

        public delegate void HumanWinEventHander();
        public event HumanWinEventHander HumanWinEvent;
        public void HumanOnWin()
        {
            if (HumanWinEvent != null)
            {
                HumanWinEvent();
            }
        }

        public delegate void ComWinEventHander();
        public event ComWinEventHander ComWinEvent;
        public void ComOnWin()
        {
            if (ComWinEvent != null)
            {
                ComWinEvent();
            }
        }
        public bool PlayAt(int rw, int cl)
        {
            if (board[rw, cl] == Player.None)//Nếu ô bấm chưa có cờ 
            {
                if (currPlayer == Player.Human && end == Player.None)//Nếu lượt đi là người 1 và trận đấu chưa kết thúc
                {
                    board[rw, cl] = currPlayer;
                    end = CheckEnd(rw, cl);//Kiểm tra xem trận đấu kết thúc chưa
                    if (end == Player.Human)//Nếu người chơi 1 thắng
                    {
                        currPlayer = Player.Human; //Thiết lập lại lượt chơi
                        HumanOnWin();//Khai báo sư kiện Win
                        return false;
                    }
                    else
                    {
                        currPlayer = Player.Com;//Thiết lập lại lượt chơi
                        OnHumanDanhXong();// Khai báo sự kiện người chơi 1 đánh xong
                        return true;
                    }
                }
                else if (currPlayer == Player.Com && end == Player.None)
                {
                    board[rw, cl] = currPlayer;//Lưu loại cờ vừa đánh vào mảng
                    end = CheckEnd(rw, cl);//Kiểm tra xem trận đấu kết thúc chưa
                    if (end == Player.Com)//Nếu người chơi 2 thắng
                    {
                        ComOnWin();//Khai báo sư kiện Win
                        return false;
                    }
                    else
                    {
                        currPlayer = Player.Human;//Thiết lập lại lượt chơi
                        OnComDanhXong();// Khai báo sự kiện người chơi 2 đánh xong
                        return true;
                    }

                }
                else return false;
            }
            else
                return false;
        }


        public bool PlayAtHuman(int rw, int cl)
        {
            if (board[rw, cl] == Player.None)//Nếu ô bấm chưa có cờ 
            {
                if (currPlayer == Player.Human && end == Player.None)//Nếu lượt đi là người 1 và trận đấu chưa kết thúc
                {
                    board[rw, cl] = currPlayer;
                    end = CheckEnd(rw, cl);//Kiểm tra xem trận đấu kết thúc chưa
                    if (end == Player.Human)//Nếu người chơi 1 thắng
                    {
                        currPlayer = Player.Human; //Thiết lập lại lượt chơi
                        HumanOnWin();//Khai báo sư kiện Win
                        return false;
                    }
                    else
                    {
                        currPlayer = Player.Com;//Thiết lập lại lượt chơi
                        OnHumanDanhXong();// Khai báo sự kiện người chơi 1 đánh xong
                        return true;
                    }
                }
                else return false;
            }
            else return false;
        }


        public void PlayAtCom()
        {
                if (currPlayer == Player.Com && end == Player.None)//Nếu ô bấm chưa có cờ 
                {
                    Node node = new Node();
                    eBoard.ResetBoard();
                    LuongGia(Player.Com);//Lượng giá bàn cờ cho máy
                    node = eBoard.GetMaxNode();//lưu vị trí máy sẽ đánh
                    r = node.Row; c = node.Column;
                    board[r, c] = currPlayer; //Lưu loại cờ vừa đánh vào mảng
                    end = CheckEnd(r, c);//Kiểm tra xem trận đấu kết thúc chưa
                    if (end == Player.Com)//Nếu máy thắng
                    {
                        ComOnWin();//Hiển thị 5 ô Lose.
                    }
                    else if (end == Player.None)
                    {
                        currPlayer = Player.Human;//Thiết lập lại lượt chơi
                        OnComDanhXong();// Khai báo sự kiện người đánh xong
                    }
            }
        }

        private Player CheckEnd(int rw, int cl)
        {
            int rowTemp = rw;
            int colTemp = cl;
            int count1, count2, count3, count4;
            count1 = count2 = count3 = count4 = 1;
            Player cur = board[rw, cl];
            #region Kiem Tra Hang Ngang
            while (colTemp - 1 >= 0 && board[rowTemp, colTemp - 1] == cur)
            {
                count1++;
                colTemp--;
            }
            colTemp = cl;
            while (colTemp + 1 <= column - 1 && board[rowTemp, colTemp + 1] == cur)
            {
                count1++;
                colTemp++;
            }
            if (count1 == 5)
            {
                return cur;
            }
            #endregion
            #region Kiem Tra Hang Doc
            colTemp = cl;

            while (rowTemp - 1 >= 0 && board[rowTemp - 1, colTemp] == cur)
            {
                count2++;
                rowTemp--;
            }
            rowTemp = rw;
            while (rowTemp + 1 <= row - 1 && board[rowTemp + 1, colTemp] == cur)
            {
                count2++;
                rowTemp++;
            }
            if (count2 == 5)
            {
                return cur;
            }

            #endregion
            #region Kiem Tra Duong Cheo Chinh (\)
            colTemp = cl;
            rowTemp = rw;
            while (rowTemp - 1 >= 0 && colTemp - 1 >= 0 && board[rowTemp - 1, colTemp - 1] == cur)
            {
                count3++;
                rowTemp--;
                colTemp--;
            }
            rowTemp = rw;
            colTemp = cl;
            while (rowTemp + 1 <= row - 1 && colTemp + 1 <= column - 1 && board[rowTemp + 1, colTemp + 1] == cur)
            {
                count3++;
                rowTemp++;
                colTemp++;
            }
            if (count3 == 5)
            {
                return cur;
            }
            #endregion
            #region Kiem Tra Duong Cheo Phu
            rowTemp = rw;
            colTemp = cl;
            while (rowTemp + 1 <= row - 1 && colTemp - 1 >= 0 && board[rowTemp + 1, colTemp - 1] == cur)
            {
                count4++;
                rowTemp++;
                colTemp--;
            }
            rowTemp = rw;
            colTemp = cl;
            while (rowTemp - 1 >= 0 && colTemp + 1 <= column - 1 && board[rowTemp - 1, colTemp + 1] == cur)
            {
                count4++;
                rowTemp--;
                colTemp++;
            }
            if (count4 == 5)
            {
                return cur;
            }
            #endregion
            return Player.None;
        }

        private void LuongGia(Player player)
        {
            int cntHuman = 0, cntCom = 0;//Biến đếm Human,Com
            #region Luong gia cho hang
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column - 4; j++)
                {
                    //Khởi tạo biến đếm
                    cntHuman = cntCom = 0;
                    //Đếm số lượng con cờ trên 5 ô kế tiếp của 1 hàng
                    for (int k = 0; k < 5; k++)
                    {
                        if (board[i, j + k] == Player.Human) cntHuman++;
                        if (board[i, j + k] == Player.Com) cntCom++;
                    }
                    //Lượng giá
                    //Nếu 5 ô kế tiếp chỉ có 1 loại cờ (hoặc là Human,hoặc la Com)
                    if (cntHuman * cntCom == 0 && cntHuman != cntCom)
                    {
                        //Gán giá trị cho 5 ô kế tiếp của 1 hàng
                        for (int k = 0; k < 5; k++)
                        {
                            //Nếu ô đó chưa có quân đi
                            if (board[i, j + k] == Player.None)
                            {
                                //Nếu trong 5 ô đó chỉ tồn tại cờ của Human
                                if (cntCom == 0)
                                {
                                    //Nếu đối tượng lượng giá là Com
                                    if (player == Player.Com)
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
                                    if (player == Player.Human) //Nếu người chơi là Người
                                    {
                                        eBoard.GiaTri[i, j + k] += PhongThu[cntCom];
                                    }
                                    else
                                    {
                                        eBoard.GiaTri[i, j + k] += TanCong[cntCom];
                                    }
                                }
                                if ((j + k - 1 > 0) && (j + k + 1 <= column - 1) && (cntHuman == 4 || cntCom == 4)
                                   && (board[i, j + k - 1] == Player.None || board[i, j + k + 1] == Player.None))
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
                        if (board[i + k, j] == Player.Human) cntHuman++;
                        if (board[i + k, j] == Player.Com) cntCom++;
                    }
                    if (cntHuman * cntCom == 0 && cntCom != cntHuman)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (board[i + k, j] == Player.None)
                            {
                                if (cntCom == 0)
                                {
                                    if (player == Player.Com) eBoard.GiaTri[i + k, j] += PhongThu[cntHuman];
                                    else eBoard.GiaTri[i + k, j] += TanCong[cntHuman];
                                    // Truong hop bi chan 2 dau.
                                    if ((i - 1) >= 0 && (i + 5) <= row - 1 && board[i - 1, j] == Player.Com && board[i + 5, j] == Player.Com)
                                    {
                                        eBoard.GiaTri[i + k, j] = 0;
                                    }
                                }
                                if (cntHuman == 0)
                                {
                                    if (player == Player.Human) eBoard.GiaTri[i + k, j] += PhongThu[cntCom];
                                    else eBoard.GiaTri[i + k, j] += TanCong[cntCom];
                                }
                                if ((i + k - 1) >= 0 && (i + k + 1) <= row - 1 && (cntHuman == 4 || cntCom == 4)
                                    && (board[i + k - 1, j] == Player.None || board[i + k + 1, j] == Player.None))
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
                        if (board[i + k, j + k] == Player.Human) cntHuman++;
                        if (board[i + k, j + k] == Player.Com) cntCom++;
                    }
                    if (cntHuman * cntCom == 0 && cntCom != cntHuman)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (board[i + k, j + k] == Player.None)
                            {
                                if (cntCom == 0)
                                {
                                    if (player == Player.Com) eBoard.GiaTri[i + k, j + k] += PhongThu[cntHuman];
                                    else eBoard.GiaTri[i + k, j + k] += TanCong[cntHuman];
                                }
                                if (cntHuman == 0)
                                {
                                    if (player == Player.Human) eBoard.GiaTri[i + k, j + k] += PhongThu[cntCom];
                                    else eBoard.GiaTri[i + k, j + k] += TanCong[cntCom];
                                }
                                if ((i + k - 1) >= 0 && (j + k - 1) >= 0 && (i + k + 1) <= row - 1 && (j + k + 1) <= column - 1 && (cntHuman == 4 || cntCom == 4)
                                    && (board[i + k - 1, j + k - 1] == Player.None || board[i + k + 1, j + k + 1] == Player.None))
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
                        if (board[i - k, j + k] == Player.Human) cntHuman++;
                        if (board[i - k, j + k] == Player.Com) cntCom++;
                    }
                    if (cntHuman * cntCom == 0 && cntHuman != cntCom)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (board[i - k, j + k] == Player.None)
                            {
                                if (cntCom == 0)
                                {
                                    if (player == Player.Com) eBoard.GiaTri[i - k, j + k] += PhongThu[cntHuman];
                                    else eBoard.GiaTri[i - k, j + k] += TanCong[cntHuman];
                                    // Truong hop bi chan 2 dau.
                                    if (i + 1 <= row - 1 && j - 1 >= 0 && i - 5 >= 0 && j + 5 <= column - 1 && board[i + 1, j - 1] == Player.Com && board[i - 5, j + 5] == Player.Com)
                                    {
                                        eBoard.GiaTri[i - k, j + k] = 0;
                                    }
                                }
                                if (cntHuman == 0)
                                {
                                    if (player == Player.Human) eBoard.GiaTri[i - k, j + k] += PhongThu[cntCom];
                                    else eBoard.GiaTri[i - k, j + k] += TanCong[cntCom];
                                    // Truong hop bi chan 2 dau.
                                }
                                if ((i - k + 1) <= row - 1 && (j + k - 1) >= 0
                                    && (i - k - 1) >= 0 && (j + k + 1) <= column - 1
                                    && (cntHuman == 4 || cntCom == 4)
                                    && (board[i - k + 1, j + k - 1] == Player.None || board[i - k - 1, j + k + 1] == Player.None))
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

    }
}
