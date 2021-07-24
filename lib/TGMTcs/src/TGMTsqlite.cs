using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace TGMTcs
{
    class TGMTsqlite
    {
        static TGMTsqlite m_instance;
        SQLiteConnection con;
        SQLiteCommand cmd;
        string m_filePath = "";

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //public static TGMTsqlite GetInstance()
        //{
        //    if (m_instance == null)
        //        m_instance = new TGMTsqlite();
        //    return m_instance;
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public TGMTsqlite(string filePath)
        {
            m_filePath = Directory.GetCurrentDirectory() + "\\" + filePath;
            if (!File.Exists(m_filePath))
            {
                SQLiteConnection.CreateFile(m_filePath);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Connect()
        {
            string _strConnect = "Data Source=" + m_filePath + ";Version=3;";
            con = new SQLiteConnection(_strConnect);
            con.Open();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CloseConnection()
        {
            con.Close();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CreateTable(string sql)
        {
            //string sql = "CREATE TABLE IF NOT EXISTS tbl_students ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, fullname nvarchar(50), birthday varchar(15), email varchar(30), address nvarchar(100), phone varchar(11))";

            SQLiteCommand command = new SQLiteCommand(sql, con);
            command.ExecuteNonQuery();
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void QueryData(string sql)
        {
            SQLiteDataReader rdr = cmd.ExecuteReader();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ExecuteNonQuery(string sql)
        {
            Connect();

            SQLiteCommand command = new SQLiteCommand(sql, con);
            int result = command.ExecuteNonQuery();

            CloseConnection();
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet LoadData(string sql)
        {
            Connect();

            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, con);
            da.Fill(ds);

            CloseConnection();
            return ds;
        }
    }
}
