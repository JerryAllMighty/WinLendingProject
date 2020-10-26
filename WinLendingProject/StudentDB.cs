using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Data;

namespace WinLendingProject
{
    /// <summary>
    /// 학생정보
    /// </summary>
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }

        public Student()
        {

        }

        public Student(int stuID, string stuName, string stuDept)
        {
            ID = stuID;
            Name = stuName;
            Dept = stuDept;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class StudentDB : IDisposable    
    {
        MySqlConnection conn;
        public StudentDB()
        {
            string strConn = ConfigurationManager.ConnectionStrings["gudi"].ConnectionString;

            conn = new MySqlConnection(strConn);
            conn.Open();
        }
        public bool Insert(Student std)
        {
            try
            {
                string sql = $@"insert into student (studentid, studentname, department) 
                                        values({std.ID}, '{std.Name}', '{std.Dept}') ";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }

        }

        public DataTable GetAllData()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"select studentid, studentname, department, deleted from student
                            where deleted = 0;";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);


                da.Fill(dt);
                return dt;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;

            }


        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
