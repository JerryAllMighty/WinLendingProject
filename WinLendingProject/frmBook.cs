using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLendingProject
{
    public partial class frmBook : Form
    {
        public frmBook()
        {
            InitializeComponent();
        }

        private void BookManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            BookDB db = new BookDB();
            db.GetAllData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmBookIns frm = new frmBookIns();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //입력받은 값으로 DB에 저장
                Book book = frm.BookInfo;
                BookDB db = new BookDB();
                bool result = db.Insert(book);
                db.Dispose();
                if (result)
                {
                    MessageBox.Show("성공적으로 추가되었습니다.");
                    LoadData();
                }
                else { MessageBox.Show("다시 시도하여주십시오"); }
                //
            }
        }

        private void LoadData()
        {
            BookDB db = new BookDB();
            DataTable dt = db.GetAllData();
            db.Dispose();
            dgvMember.DataSource = dt;
        }
    }
}
