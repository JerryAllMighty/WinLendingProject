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
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStudentInsUp frm = new frmStudentInsUp();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //입력받은 값으로 DB에 저장
                Student stu = frm.StudentInfo;
                StudentDB db = new StudentDB();
                bool result = db.Insert(stu);
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

        private void frmStudent_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            StudentDB db = new StudentDB();
            DataTable dt = db.GetAllData();
            db.Dispose();
            dataGridView1.DataSource = dt;
        }

    }
}
