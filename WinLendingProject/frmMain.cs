using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WinLendingProject
{
    public partial class frmMain : Form
    {
        string strConn = ConfigurationManager.ConnectionStrings["gudi"].ConnectionString;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(strConn);
        }

        private void 학생관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent frm = new frmStudent();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void 도서관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBook b1 = new frmBook();
            b1.MdiParent = this;
            b1.Show();
            b1.Activate();
        }
    }
}
