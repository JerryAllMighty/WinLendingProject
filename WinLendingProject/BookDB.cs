using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using System.Data;

namespace WinLendingProject
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

        public Book()
        {

        }

        public Book(int bookID, string bookName, string bookAuthor)
        {
            ID = bookID;
            Name = bookName;
            Author = bookAuthor;
        }
    }

    class BookDB : IDisposable
    {
        MySqlConnection conn;
        public BookDB()
        {
            string strConn = ConfigurationManager.ConnectionStrings["gudi"].ConnectionString;

            conn = new MySqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Book book)
        {
            try
            {
                string sql = $@"insert into book (bookid, bookname, author) 
                                        values({book.ID}, '{book.Name}', '{book.Author}') ";

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
                string sql = @"select bookid, bookname, author, deleted from book
                            where deleted = 0";
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
