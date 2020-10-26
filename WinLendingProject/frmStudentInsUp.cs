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
    public partial class frmStudentInsUp : Form
    {
        public Student StudentInfo {
            get
            { return new Student(int.Parse(txtStudentID.Text), txtStudentName.Text, txtStudentDepartment.Text); } 
            //set;
        }
        public frmStudentInsUp()
        {
            InitializeComponent();
        }

        private void txtStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //유효성체크
            StringBuilder sb = new StringBuilder();
            
            if (txtStudentID.Text.Length < 10)
            {
                sb.AppendLine("학번은 10자리로 입력하세요.");
                //return;
            }

            if (string.IsNullOrEmpty(txtStudentName.Text))
            {
                sb.AppendLine("학생명을 입력하세요.");
             
            }
            if (sb.ToString().Length > 0)
            {
                MessageBox.Show(sb.ToString());
            }
            else 
            {
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }
    }
}
