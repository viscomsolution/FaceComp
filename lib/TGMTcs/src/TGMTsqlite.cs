using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace TGMTcs
{
    class TGMTsqlite
    {        
        static TGMTsqlite m_instance = null;
        SQLiteConnection con;
        SQLiteCommand cmd;
        string m_filePath = "";
        string m_password = "";
        bool m_isEncrypted = false;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static TGMTsqlite GetInstance()
        {
            if (m_instance == null)
                m_instance = new TGMTsqlite();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool LoadDatabase(string filePath, string password = "")
        {
            m_filePath = Directory.GetCurrentDirectory() + "\\" + filePath;
            m_password = password;

            if (!File.Exists(m_filePath))
            {
                MessageBox.Show("Database " + filePath + " not exist");
                return false;
            }
            else
            {                
                return Connect();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool Connect()
        {
            string _strConnect = "Data Source=" + m_filePath + ";Version=3;";
            if (m_password != "" && m_isEncrypted)
            {
                _strConnect += "Password=" + m_password + ";";
            }
            con = new SQLiteConnection(_strConnect);            
            con.Open();


            bool isConnected = con.State == ConnectionState.Open;
            return isConnected;
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
            try
            {
                Connect();

                SQLiteCommand command = new SQLiteCommand(sql, con);
                int result = command.ExecuteNonQuery();

                CloseConnection();
                return result;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("file is encrypted or is not a database"))
                {
                    if (!m_isEncrypted)
                    {
                        m_isEncrypted = true;
                        return ExecuteNonQuery(sql);
                    }
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
                return -1;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet LoadData(string sql)
        {
            try
            {
                Connect();

                DataSet ds = new DataSet();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, con);
                da.Fill(ds);

                CloseConnection();
                return ds;
            }
            catch(Exception ex)
            {
                if(ex.Message.Contains("file is encrypted or is not a database"))
                {
                    if(!m_isEncrypted)
                    {
                        m_isEncrypted = true;
                        return LoadData(sql);
                    }
                }
                else if(ex.Message.Contains("no such table"))
                {

                }
                else
                {
                    Console.WriteLine(ex.Message);
                }                
                return null;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool SetPassword(string password)
        {
            try
            {
                string _strConnect = "Data Source=" + m_filePath + ";Version=3;";
                if (m_password != "" && m_isEncrypted)
                {
                    _strConnect += "Password=" + m_password + ";";
                }
                con = new SQLiteConnection(_strConnect);
                con.Open();
                con.ChangePassword(password);
                
                m_isEncrypted = password != "";
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RemovePassword()
        {
            return SetPassword("");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsFileEncrypted()
        {
            var tables = GetTables();
            m_isEncrypted = tables.Count == 0;
            return m_isEncrypted;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayList GetTables()
        {
            ArrayList list = new ArrayList();

            // executes query that select names of all tables in master table of the database
            String query = "SELECT name FROM sqlite_master " +
                    "WHERE type = 'table'" +
                    "ORDER BY 1";
            try
            {

                DataTable table = GetDataTable(query);

                // Return all table names in the ArrayList

                foreach (DataRow row in table.Rows)
                {
                    list.Add(row.ItemArray[0].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable GetDataTable(string sql)
        {
            try
            {
                Connect();
                DataTable dt = new DataTable();
                using (var c = new SQLiteConnection(con))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            dt.Load(rdr);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
