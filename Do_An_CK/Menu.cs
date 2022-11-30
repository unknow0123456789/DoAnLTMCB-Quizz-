using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_CK
{
    public partial class Menu : Form
    {
        public Menu(string name,string score,string ipServer,string PortServer,string timeleft)
        {
            InitializeComponent();
            TenLabel.Text = "Name: "+name;
            DiemLabel.Text = "Score: "+score;
            IPserverLabel.Text = "Server's IP: "+ipServer;
            PortserverLabel.Text = "Server's Port: "+PortServer;
            timeleftLabel.Text = "Time left: "+timeleft;
        }

        private void btn_ChoiTiep_Click(object sender, EventArgs e)
        {
            //Play_GiaoDien play = new Play_GiaoDien();
            //play.Show();
            //Button button = (Button)sender;
            //this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}
