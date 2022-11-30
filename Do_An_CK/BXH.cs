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
    public partial class BXH : Form
    {
        public BXH(List<string>XH)
        {
            InitializeComponent();
            hereBXH = XH;
            upBXH();

        }

        List<string> hereBXH;
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void upBXH()
        {
            for(int h=0;h<hereBXH.Count;h++)
            {
                DaBoard.Text += (h+1)+"."+hereBXH[h] + "\n";
            }
        }
    }
}
