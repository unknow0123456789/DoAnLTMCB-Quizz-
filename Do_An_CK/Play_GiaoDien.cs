using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
namespace Do_An_CK
{
    public partial class Play_GiaoDien : Form
    {
        class Constants
        {
            public const int MaxQRandom = 10;
        }
        public Play_GiaoDien(string NAME,IPAddress sourceIP,int portSV)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            IPtemp = sourceIP;
            port = portSV;
            Name = NAME;
            connect();
        }
        TcpClient client;   //tcpclient dieu khien chinh
        Stream recvstream;  //stream nhan thong diep tu server
        StreamReader test;
        IPEndPoint IPE;     //ipendpoint chua dia chi va port server
        IPAddress IPtemp;   //ipaddress chua dia chi server
        int port;           //so portserver
        string SfromSV;     //luu thong diep server
        string Name;        //ten nguoi choi
        int ENDCHECK = 0;   //dieu kien ket thuc
        void connect()
        {
            try
            {
                client = new TcpClient();
                IPE = new IPEndPoint(IPtemp, port);
                client.Connect(IPE);
                recvstream = client.GetStream();
                string pp = "UPDATEINFO";
                Send(Name,pp);
                Thread receiving1 = new Thread(receiving);
                receiving1.IsBackground = true;
                receiving1.Start();
                //addIPinIPBOX();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n");
            }
        }
        bool allowToRecv = true;
        void receiving()
        {
            try
            {
                while (recvstream.CanRead && allowToRecv)
                {
                    byte[] recv = new byte[1024];
                    recvstream.Read(recv, 0, recv.Length);
                    //SErecvstream.Read(recv, 0, recv.Length);
                    string tesst = Encoding.UTF8.GetString(recv);
                    newReceive(recv);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "\n");
            }
        }
        void Send(string raw,string purpose)
        {
            try
            {
                string fullmess = client.Client.LocalEndPoint + "/" + purpose + "//" + raw;
                byte[] data = Encoding.UTF8.GetBytes(fullmess);
                client.Client.Send(data);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void newReceive(byte[] arv)
        {
            string data = Encoding.UTF8.GetString(arv);
            SfromSV = data;
            SfromSV = SfromSV.Remove(SfromSV.IndexOf("\0"));
            //MessageBox.Show(SfromSV);

            //purpose ?
            if(SfromSV.Contains("CHECKING"))
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    checkingPlayer();
                    this.Enabled = false;

                }));
            }
            else if(SfromSV=="START")
            {
                //MessageBox.Show("checkstart");
                string s = "START$$" + sortQ[currentQ];
                string pp = "ANSWERQ";
                Send(s, pp);
            }
            else if(SfromSV=="END")
            {
                resBXH();
                ENDCHECK = 1;
            }
            else if(SfromSV.Contains("BXH"))
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    SfromSV = SfromSV.Substring(SfromSV.IndexOf("$$") + 2);
                    string howmanyP = SfromSV.Remove(SfromSV.IndexOf("$$"));
                    int howmanyPint = int.Parse(howmanyP);
                    SfromSV = SfromSV.Substring(SfromSV.IndexOf("$$") + 2);
                    List<string> BXHP = new List<string>();
                    for(int h=0;h<howmanyPint;h++)
                    {
                        if (h == howmanyPint - 1) BXHP.Add(SfromSV);
                        else
                        {
                            BXHP.Add(SfromSV.Remove(SfromSV.IndexOf("$$")));
                            SfromSV = SfromSV.Substring(SfromSV.IndexOf("$$") + 2);
                        }
                    }
                    BXH currentBXH = new BXH(BXHP);
                    currentBXH.Show();
                    if (ENDCHECK == 1) this.Enabled = false;
                    currentBXH.FormClosed += new FormClosedEventHandler(thoatBXH);
                }));
            }
            else if(SfromSV.Contains("MENUINFO"))
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    SfromSV = SfromSV.Substring(SfromSV.IndexOf("$$") + 2);
                    string ten = SfromSV.Remove(SfromSV.IndexOf("$$"));
                    SfromSV = SfromSV.Substring(SfromSV.IndexOf("$$") + 2);
                    string diem = SfromSV.Remove(SfromSV.IndexOf("$$"));
                    SfromSV = SfromSV.Substring(SfromSV.IndexOf("$$") + 2);
                    string ip = SfromSV.Remove(SfromSV.IndexOf(":"));
                    SfromSV = SfromSV.Substring(SfromSV.IndexOf(":") + 1);
                    string port = SfromSV.Remove(SfromSV.IndexOf("$$"));
                    SfromSV = SfromSV.Substring(SfromSV.IndexOf("$$") + 2);
                    string time = SfromSV;
                    Menu Mn = new Menu(ten, diem, ip, port, time);
                    Mn.Show(this);
                    Mn.btnThoat.Click += new EventHandler(thoatform);
                    Mn.BXH_btn.Click += new EventHandler(btn_BXH_Click);
                }));
            }
            else if(SfromSV.Contains("$$"))
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    btnA.Enabled = true;
                    btnB.Enabled = true;
                    btnC.Enabled = true;
                    btnD.Enabled = true;
                    string Q = SfromSV.Remove(SfromSV.IndexOf("$$"));
                    SfromSV = SfromSV.Substring(SfromSV.IndexOf("$$") + 2);
                    string opA, opB, opC, opD;
                    opA = SfromSV.Remove(SfromSV.IndexOf("$$"));
                    SfromSV = SfromSV.Substring(SfromSV.IndexOf("$$") + 2);
                    opB = SfromSV.Remove(SfromSV.IndexOf("$$"));
                    SfromSV = SfromSV.Substring(SfromSV.IndexOf("$$") + 2);
                    opC = SfromSV.Remove(SfromSV.IndexOf("$$"));
                    SfromSV = SfromSV.Substring(SfromSV.IndexOf("$$") + 2);
                    opD = SfromSV;
                    richTextBox1.Text = Q;
                    btnA.Text = opA;
                    btnB.Text = opB;
                    btnC.Text = opC;
                    btnD.Text = opD;
                    txtCS.Text = (currentQ+1)+"";
                }));
            }
            //MessageBox.Show(SfromSV);
        }
        void thoatBXH(object sender,EventArgs e)
        {
            if (ENDCHECK == 1)
            {
                allowToRecv = false;
                SocketShutdown bruh = new SocketShutdown();
                client.Client.Shutdown(bruh);
                client.Client.Close();
                client.Close();
                this.Close();
            }
        }
        Checkplayer checking;   //form checking nguoi choi
        
        bool checkingPlayer()
        {
            checking = new Checkplayer();
            checking.Show();
            checking.FormClosed += new FormClosedEventHandler(thoatcheck);
            return checking.checker;
        }

        int[] sortQ = new int[Constants.MaxQRandom];  //mang chua thu tu cau hoi
        int currentQ=0;             //chi so cau hoi hien tai
        
        void thoatcheck(object sender,EventArgs e)
        {
            if(checking.checker==true)
            {
                string s = "OK";
                string pp = "UPDATESTATUS";
                Send(s, pp);

                richTextBox1.Text = "";
                Qchoice_Random(ref sortQ);
                richTextBox1.Text = "ĐANG CHỜ NHỮNG NGƯỜI CHƠI KHÁC....";
            }
            this.Enabled = true;
        }
        private void btnMn_Gd_Click(object sender, EventArgs e)
        {
            string s = "MENU";
            string pp = "RESINFO";
            Send(s, pp);
        }
        void thoatform(object sender,EventArgs e)
        {
            this.Close();
        }
        void resBXH()
        {
            string s = "BXH";
            string pp = "RESINFO";
            Send(s, pp);
        }
        private void btn_BXH_Click(object sender, EventArgs e)
        {
            resBXH();
        }
        void Qchoice_Random(ref int[] sorting)  //tao thu tu cac cau hoi se hien ra randomly
        {
            Random choice = new Random();
            int count = 0;
            int[] choiceR = new int[Constants.MaxQRandom];
            for (int h = 0; h < Constants.MaxQRandom; h++)
            {
                choiceR[h] = -1;
            }
            while (choiceR[Constants.MaxQRandom-1] == -1)
            {
                //MessageBox.Show("check");
                int temp = choice.Next(1, Constants.MaxQRandom+1);
                bool check = true;
                for (int t = 0; t < Constants.MaxQRandom; t++) if (choiceR[t] == temp) check = false;
                if (check == true)
                {
                    choiceR[count] = temp;
                    count++;
                }
            }
            sorting = choiceR;
            currentQ = 0;
        }
        void AnswerAndSend(string answer)   //traloi cau hoi va gui den server
        {
            if (currentQ < sortQ.Length - 1)
            {
                string fullA = sortQ[currentQ++] + "$$" + answer + "$$" + (sortQ[currentQ]);
                string pp = "ANSWERQ";
                Send(fullA, pp);
            }
            else
            {
                string fullA = sortQ[currentQ] + "$$" + answer + "$$" + -1;
                string pp = "ANSWERQ";
                Send(fullA, pp);
            }
        }
        private void btnA_Click(object sender, EventArgs e)
        {
            AnswerAndSend(btnA.Text);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            AnswerAndSend(btnB.Text);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            AnswerAndSend(btnC.Text);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            AnswerAndSend(btnD.Text);
        }

        private void Play_GiaoDien_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
