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

namespace Do_An_CK
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            IPAddress temp;
            int porttemp;
            string name = tenbox.Text;
            if (IPAddress.TryParse(IPBOX1.Text, out temp) == false || int.TryParse(PORTBOX1.Text,out porttemp)==false) ;
            else
            {
                Play_GiaoDien play = new Play_GiaoDien(name,temp,porttemp);
                play.Show(this);
                play.FormClosed += new FormClosedEventHandler(child_FormClosed);
                //Button button = (Button)sender;
                this.Visible = false;
            }
        }
        void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible=true;
        }


        private void btnHD_Click(object sender, EventArgs e)
        {
            HuongDan HD = new HuongDan();
            HD.Show();
            HD.FormClosed += new FormClosedEventHandler(child_FormClosed);
            //Button button = (Button)sender;
            this.Visible=false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
