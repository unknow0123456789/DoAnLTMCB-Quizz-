using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace ServerQ
{
    public partial class ServerQ : Form
    {
        static class Constants
        {
            public const int MaxQVolume = 1048576;
            public const int MaxRVolume = 8192;
        }
        struct clientchoice
        {
            public int score;
            public string status;
            public string name;
            public int t;
            public string portclient;
        };
        List<clientchoice> clients = new List<clientchoice>();

        //ham add client
        clientchoice addClientChoices(int tt, string ip)
        {
            clientchoice bruh;
            bruh.t = tt;
            ip = ip.Substring(ip.IndexOf(":") + 1);
            bruh.portclient = ip;
            bruh.name = "NULL";
            bruh.status = "inactive";
            bruh.score = 0;
            return bruh;
        }
        struct Question
        {
            public int Qn;
            public string Q;
            public string[] As;
            public string A;
        }
        List<Question> Questions = new List<Question>();
        Question CreateQuestion (int Qnum,string raw)
        {
            if (raw == "") MessageBox.Show("???");
            Question nw=new Question();
            nw.As = new string[4];
            nw.Qn = Qnum;
            nw.Q = raw.Remove(raw.IndexOf("\n"));
            raw = raw.Substring(raw.IndexOf("\n") + 1);
            for(int h=0;h<4;h++)
            {
                nw.As[h] ="";
                string temp;
                if (raw.IndexOf("\n") == -1) temp = raw.Remove(raw.IndexOf("\0"));
                else temp = raw.Remove(raw.IndexOf("\n"));
                if(temp.Contains("\r"))
                {
                    temp = temp.Remove(temp.IndexOf("\r"));
                }
                nw.As[h] = temp;
                if (nw.As[h].Contains(';'))
                {
                    string bruh = nw.As[h];
                    bruh = bruh.Substring(0, bruh.Length - 1);
                    nw.As[h]=bruh;
                    nw.A = nw.As[h];
                }
                raw = raw.Substring(raw.IndexOf("\n")+1);
            }
            return nw;
        }

        void CreateListQuestion(string raw,List<Question> Qs)
        {
            int t=1;
            while(raw !=string.Empty)
            {
                string temp="";
                for (int h = 0; h < 5; h++)
                {
                    if (raw.IndexOf("\n") == -1)
                    {
                        temp += raw;
                        raw = "";
                    }
                    else
                    {
                        temp += raw.Remove(raw.IndexOf("\n") + 1);
                        raw = raw.Substring(raw.IndexOf("\n") + 1);
                    }
                }
                //MessageBox.Show(temp);
                Qs.Add(CreateQuestion(t, temp));
                //MessageBox.Show(raw);
                t++;
            }
        }
        public ServerQ()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connect();
        }

        //bien toan cuc
        List<Socket> serverSocket = new List<Socket>();
        TcpListener serverListener;
        IPEndPoint serverIPE;
        IPAddress IPtemp;
        int checking = 1;
        int i = -1;
        int ENDCLIcheck = 0;
        void connect()
        {
            serverIPE = new IPEndPoint(IPAddress.Any, 11000);
            serverListener = new TcpListener(serverIPE);
            Thread receiving1 = new Thread(() =>
            {
                while (true)
                {
                    checking = 1;
                    serverListener.Start();                                                 //i tuong trung cho client dang duoc chon hoac da duoc them vao
                    serverSocket.Add(serverListener.AcceptSocket());
                    i++;
                    //IPBOX.Items.Add("Client " + (i + 1));                                                //add option client cho combobox
                    clients.Add(addClientChoices(i, serverSocket[i].RemoteEndPoint.ToString()));    //ADD client vao list 
                    //chat.Text = "welcome to my server,Client " + (i + 1) + ". \n ******************************************** \nDefault mode is chat ALL when port=11000 , but u can change to private mode by changing port value to the port value of the client you wished to talk to. \nAt chat section, type ' */* ' and press Enter or Send button to show ur IP Adress and port. ";
                    //send(serverSocket[i]);
                    Thread receiving2 = new Thread(receiving);
                    receiving2.IsBackground = true;
                    receiving2.Start(serverSocket[i]);
                }
            });
            receiving1.IsBackground = true;
            receiving1.Start();
        }
        void receiving(object obj)
        {
            try
            {
                while (checking==1)
                {
                    Socket resock = obj as Socket;
                    byte[] recv = new byte[Constants.MaxRVolume];
                    resock.Receive(recv);
                    newReceive(Encoding.UTF8.GetString(recv));
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "\n");
                checking = 0;
            }
        }
        void newReceive(string recv)
        {
            try
            {
                //MessageBox.Show(recv);
                checkingView.Text += recv + "\n";
                checkingView.Text += "\n";
                if (recv.Contains("//"))
                {
                    string infoPart = recv.Remove(recv.IndexOf("//"));
                    string messFrom = infoPart.Remove(infoPart.IndexOf("/"));
                    string data = recv.Substring(recv.IndexOf("//") + 2);
                    infoPart = infoPart.Substring(infoPart.IndexOf("/") + 1);
                    messFrom = messFrom.Substring(messFrom.IndexOf(":") + 1);
                    data = data.Remove(data.IndexOf("\0"));
                    int clientNUM = -1;

                    //sendfrom ?
                    for (int h = 0; h < clients.Count; h++)
                    {
                        if (messFrom == clients[h].portclient) clientNUM = clients[h].t;
                    }

                    //purpose ?
                    if (infoPart == "UPDATESTATUS")
                    {
                        if (data == "OK")
                        {
                            infoView.Items[clientNUM].ImageIndex = 1;
                            clientchoice tempo = clients[clientNUM];
                            tempo.status = "active";
                            clients[clientNUM] = tempo;
                            //MessageBox.Show("done");
                        }

                    }
                    else if (infoPart == "UPDATEINFO")
                    {
                        clientchoice temp = clients[clientNUM];
                        temp.name = data;
                        clients[clientNUM] = temp;
                    }
                    else if (infoPart == "ANSWERQ")
                    {
                        if (data.Contains("START"))
                        {
                            //MessageBox.Show(data);
                            string nextQ = data.Substring(data.IndexOf("$$") + 2);
                            int nextQnum = int.Parse(nextQ) - 1;
                            string fullQ = Questions[nextQnum].Q + "$$" + Questions[nextQnum].As[0] + "$$" + Questions[nextQnum].As[1] + "$$" + Questions[nextQnum].As[2] + "$$" + Questions[nextQnum].As[3];
                            //MessageBox.Show(fullQ);
                            sendmess(serverSocket[clientNUM], fullQ);
                        }
                        else
                        {
                            //check answer and scoring
                            string currentQ = data.Remove(data.IndexOf("$$"));
                            int currentQnum = int.Parse(currentQ) - 1;
                            data = data.Substring(data.IndexOf("$$") + 2);
                            string clientAnswer = data.Remove(data.IndexOf("$$"));
                            if (clientAnswer == Questions[currentQnum].A)
                            {
                                clientchoice temp = clients[clientNUM];
                                temp.score++;
                                clients[clientNUM] = temp;
                                //MessageBox.Show(temp.name + ": " + temp.score);
                            }

                            //process next Q
                            string nextQ = data.Substring(data.IndexOf("$$") + 2);
                            int nextQnum = int.Parse(nextQ) - 1;
                            if (nextQnum + 1 != -1)
                            {
                                string fullQ = Questions[nextQnum].Q + "$$" + Questions[nextQnum].As[0] + "$$" + Questions[nextQnum].As[1] + "$$" + Questions[nextQnum].As[2] + "$$" + Questions[nextQnum].As[3];
                                //MessageBox.Show(fullQ);
                                sendmess(serverSocket[clientNUM], fullQ);
                            }
                            else
                            {
                                //MessageBox.Show("check");
                                string s = "END";
                                sendmess(serverSocket[clientNUM], s);
                                ENDCLIcheck++;
                            }
                        }

                    }
                    else if (infoPart == "RESINFO")
                    {
                        if (data == "BXH")
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                string fullBXH = "";
                                List<clientchoice> tempo = clients;
                                int imAT = 0;
                                while (imAT < tempo.Count - 1)
                                {
                                    int highestAT = imAT;
                                    for (int h = imAT; h < tempo.Count; h++)
                                    {
                                        if (tempo[h].score > tempo[highestAT].score) highestAT = h;
                                    }
                                    clientchoice swap = tempo[imAT];
                                    tempo[imAT] = tempo[highestAT];
                                    tempo[highestAT] = swap;
                                    imAT++;
                                }
                                fullBXH += "BXH$$" + tempo.Count + "$$";
                                for (int h = 0; h < tempo.Count; h++)
                                {
                                    if (h == tempo.Count - 1) fullBXH += tempo[h].name;
                                    else fullBXH += tempo[h].name + "$$";
                                }
                                sendmess(serverSocket[clientNUM], fullBXH);
                                if (ENDCLIcheck > 0)
                                {
                                    ENDCLIcheck--;
                                    playerDONE++;
                                }
                                if (playerDONE == clients.Count)
                                {
                                    ENDallCli();
                                }
                            }));
                        }
                        else if (data == "MENU")
                        {
                            string s = "MENUINFO$$" + clients[clientNUM].name + "$$" + clients[clientNUM].score + "$$" + serverListener.Server.LocalEndPoint + "$$" + clockBOX.Text;
                            sendmess(serverSocket[clientNUM], s);
                        }

                    }

                }
            }
            catch(Exception)
            {

            }
        }
        
        void ENDallCli()
        {
            int tempocount = clients.Count;
            for(int h=tempocount-1;h>=0;h--)
            {
                ENDCLI(h);
            }
            clockBOX.Text = "00:00";
        }
        void ENDCLI(int clientNUM)
        {
            SocketShutdown bruh = new SocketShutdown();
            serverSocket[clientNUM].Shutdown(bruh);
            serverSocket[clientNUM].Close();
            for (int h = clientNUM; h < clients.Count; h++)
            {
                if (h == clients.Count - 1)
                {
                    clients.RemoveAt(h);
                    serverSocket.RemoveAt(h);
                }
                else
                {
                    clients[h] = clients[h + 1];
                    serverSocket[h] = serverSocket[h + 1];
                }
            }
            //MessageBox.Show(clients.Count + "");
            //MessageBox.Show(i+"");
            i--;
            playerStart--;
            refreshList();
            ENDCLIcheck --;
        }
        private void browse_Click(object sender, EventArgs e)
        {
            string s;
            OpenFileDialog browseQ = new OpenFileDialog();
            if (browseQ.ShowDialog() == DialogResult.OK)
            {
                FileStream readQ = new FileStream(browseQ.FileName, FileMode.Open);
                byte[] reading = new byte[Constants.MaxQVolume];
                readQ.Read(reading, 0, reading.Length);
                readQ.Close();
                s = Encoding.UTF8.GetString(reading);
                //checkingView.Text = s;
                CreateListQuestion(s, Questions);
                showQ.Enabled = true;
                StartBtn.Enabled = true;
            }
        }

        private void showQ_Click(object sender, EventArgs e)
        {
            checkingView.Text = "";
            foreach (Question q in Questions)
            {
                checkingView.Text += q.Q + "\n";
                foreach(string a in q.As)
                {
                    checkingView.Text += a + "\n";
                }
                checkingView.Text += "\nAnswer: " + q.A + "\n";
                checkingView.Text += "\n\n";
            }
        }
        void sendmess (Socket client,string s)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(s);
                client.Send(data);
            }
            catch(Exception ex)
            {

            }
        }
        private void playercheckBtn_Click(object sender, EventArgs e)
        {
            infoView.Items.Clear();
            for (int h=0;h<clients.Count;h++)
            {
                string check = "CHECKING";
                sendmess(serverSocket[h], check);
                infoView.Items.Add(clients[h].name, 0);
                clientchoice tempo = clients[h];
                tempo.status = "inactive";
                clients[h] = tempo;
            }
        }
        int playerStart, playerDONE=0;
        private void StartBtn_Click(object sender, EventArgs e)
        {
            bool checkP = true;
            for(int h=0;h<clients.Count; h++)
            {
                if (clients[h].status == "inactive") checkP = false;
            }
            if(checkP==true &&  setTime())
            {
                for(int h=0;h<clients.Count;h++)
                {
                    string s = "START";
                    sendmess(serverSocket[h], s);
                }
                EndBtn.Enabled = true;
                clockBOX.Enabled = false;
                StartBtn.Enabled = false;
                playercheckBtn.Enabled = false;
                playerStart = clients.Count;
                playerDONE = 0;
            }
        }
        void everySec(int min,int sec)
        {
            if(min==0)
            {
                if (sec == 0)
                {
                    ENDCLIcheck = clients.Count;
                    string s = "END";
                    for(int h=0;h<clients.Count;h++)
                    {
                        sendmess(serverSocket[h], s);
                    }
                    timer1.Enabled = false;
                    clockBOX.Enabled = true;
                    StartBtn.Enabled = true;
                    playercheckBtn.Enabled = true;
                    EndBtn.Enabled = false;
                }
                else sec--;
            }
            else if (sec == 0)
            {
                min--;
                sec = 59;
            }
            else sec--;
            clockBOX.Text = min + ":" + sec;
            
        }
        bool setTime()
        {
            bool check = true;
            int min = 0;
            int sec = 0;
            if (clockBOX.Text.Contains(":"))
            {
                if (int.TryParse(clockBOX.Text.Remove(clockBOX.Text.IndexOf(":")), out min) == false) check = false;
                else if (int.TryParse(clockBOX.Text.Substring(clockBOX.Text.IndexOf(":") + 1), out sec) == false) check = false;
                else if (min == 0 && sec == 0) check = false;
            }
            else check = false;
            if (check == true)
            {
                timer1.Enabled = true;
                timer1.Interval = 1000;
            }
            return check;
        }
        private void infoView_Click(object sender, EventArgs e)
        {
            int[] clientNUMs=new int[100];
            infoView.SelectedIndices.CopyTo(clientNUMs,0);
            int clientNUM = clientNUMs[0];
            USERinfoANDinteract.Items[0].Text ="Name:"+clients[clientNUM].name;
            USERinfoANDinteract.Items[1].Text ="Score: "+ clients[clientNUM].score.ToString();
            USERinfoANDinteract.Show(USERinfoANDinteract.Location=Cursor.Position);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (clockBOX.Text.Contains(":"))
            {
                int min = 0;
                int sec = 0;
                if (int.TryParse(clockBOX.Text.Remove(clockBOX.Text.IndexOf(":")), out min) == false) MessageBox.Show("time not vail");
                else if (int.TryParse(clockBOX.Text.Substring(clockBOX.Text.IndexOf(":") + 1), out sec) == false) MessageBox.Show("time not vail");
                everySec(min, sec);
            }
            else MessageBox.Show("time not vail");
        }

        private void EndBtn_Click(object sender, EventArgs e)
        {
            clockBOX.Text = "00:00";
        }
        void refreshList()
        {
            infoView.Items.Clear();
            for(int h=0;h<clients.Count;h++)
            {
                if(clients[h].status=="inactive")infoView.Items.Add(clients[h].name, 0);
                else infoView.Items.Add(clients[h].name, 1);
            }
        }
        private void Kick_Click(object sender, EventArgs e)
        {
            int[] clientNUMs = new int[100];
            infoView.SelectedIndices.CopyTo(clientNUMs, 0);
            int clientNUM = clientNUMs[0];
            //string s = "END";
            //sendmess(serverSocket[clientNUM], s);
            ENDCLI(clientNUM);
        }
    }
}
