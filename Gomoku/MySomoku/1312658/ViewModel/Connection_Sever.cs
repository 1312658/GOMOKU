using _1312658.Properties;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1312658.ViewModel
{
    public class Connection_Sever
    {
        public Socket socket;

        public string m_Message {get; set;}
        public Point m_SteppSever;
        public bool m_isFrist = false;
        public bool m_StartGame = false;
        public string m_NameSever { get; set; }
        public string m_NameHuman { get; set; }
        public List<Point> winArray { get; set; }

        public Connection_Sever(string nameHuman)
        {
            m_NameHuman = nameHuman;
            if (m_NameHuman == null)
                m_NameHuman = "Anh Tuấn";
            socket = IO.Socket(Settings.Default.IP);
            socket.On(Socket.EVENT_CONNECT, () => {  });
            // Nhận 
            socket.On(Socket.EVENT_MESSAGE, (data) =>{  });

            // nhận lỗi khi connection từ sever
            socket.On(Socket.EVENT_CONNECT_ERROR, (data) => { });

            // nhận lỗi từ sever
            socket.On(Socket.EVENT_ERROR, (data) => { });


            // nhận thông điệp chat từ sever
            socket.On("ChatMessage", (data) =>
            {
                var jobject = data as JToken;
                string a = jobject.Last.First.ToString(); // tên người gởi
                string b = jobject.First.First.ToString(); // mesage

                // nếu người gởi là sever thì a và b bằng nhau và bằng thông điệp gởi 
                if(a == b && jobject.First.Next == null)
                {
                    m_NameSever = "SEVER";
                    if(message_changed != null)
                        message_changed(b);
                }

                else
                {
                    m_NameSever = a;
                    if (message_changed != null)
                        message_changed(b);
                }


                if (((JObject)data)["message"].ToString() == "Welcome!")
                {
                    socket.Emit("MyNameIs", m_NameHuman);
                    socket.Emit("ConnectToOtherPlayer");
                }

                if (jobject.Value<String>("message").IndexOf("first") > 0)
                {
                    m_isFrist = true;
                    m_StartGame = true;
                    if (StartPlayAuToOnline != null)
                        StartPlayAuToOnline(m_isFrist);
                }
                if (jobject.Value<String>("message").IndexOf("second") > 0)
                {
                    m_isFrist = false;
                    m_StartGame = true;
                    if (StartPlayAuToOnline != null)
                        StartPlayAuToOnline(m_isFrist);
                }
            });

            socket.On("EndGame", (data) =>
            {
                string temp = getMessageFromSever(data, "message");
                if (message_changed != null)
                {
                    message_changed(temp);
                }
                if(temp.Contains("won the game!"))
                {
                    string nameWin;
                    if (temp.Contains(m_NameHuman))
                        nameWin = m_NameHuman;
                    else nameWin = m_NameSever;

                    winArray = new List<Point>();
                    List<JToken> listJToken = ((Newtonsoft.Json.Linq.JObject)data)["highlight"].Children().ToList();

                    foreach (JToken re in listJToken)
                    {
                        Point temp1 = new Point();

                        temp1.X = (int)re["row"];
                        temp1.Y = (int)re["col"];
                        winArray.Add(temp1);
                    }
                    if (winGame != null)
                        winGame(winArray, nameWin);
                }

                if (temp.Contains("left the game!"))
                {
                    if (LeftGame != null)
                        LeftGame();
                }
              
            });

        }

        public void addOn()
        {
            socket.On("NextStepIs", (data) =>
            {
                String Player = getMessageFromSever(data, "player");
                String Row = getMessageFromSever(data, "row");
                String Column = getMessageFromSever(data, "col");
                if (Int32.Parse(Player) == 1)
                {
                    m_SteppSever = new Point(Int32.Parse(Column), Int32.Parse(Row));
                    if (SteppChange_changed != null)
                        SteppChange_changed(m_SteppSever);
                }
            });
        }

        public void SendPoint(Point step)
        {
            socket.Emit("MyStepIs", JObject.FromObject(new { row = step.Y, col = step.X }));
        }

        public void ChangeName(string name)
        {
            socket.Emit("MyNameIs", name);
        }

        public void Disconnected()
        {
            if (socket != null)
            {
                socket.Off(Socket.EVENT_CONNECT);
                socket.Off(Socket.EVENT_MESSAGE);
                socket.Off(Socket.EVENT_CONNECT_ERROR);
                socket.Off("ChatMessage");
                socket.Off("EndGame");
                socket.Off(Socket.EVENT_ERROR);
                socket.Off(Socket.EVENT_CONNECT);
                socket.Disconnect();
                socket.Close();
            }
        }

        String getMessageFromSever(object data, String eventString)
        {
            var jobject = data as JToken;
            return jobject.Value<String>(eventString);
        }

        public void chat(String message)
        {
            socket.Emit("ChatMessage", message);
        }

        public delegate void Message_ChangedHandler(String mesage);
        public event Message_ChangedHandler message_changed;

        public delegate void SteppChange_ChangedHandler(Point point);
        public event SteppChange_ChangedHandler SteppChange_changed;

        public delegate void StartPlayAuToOnline_ChangedHandler(bool m_isFirst);
        public event StartPlayAuToOnline_ChangedHandler StartPlayAuToOnline;

        public delegate void LeftGame_ChangedHandler();
        public event LeftGame_ChangedHandler LeftGame;

        public delegate void win_ChangedHandler(List<Point> winArray, string nameWin);
        public event win_ChangedHandler winGame;
    }
}
