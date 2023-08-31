using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;

namespace Checkin
{
    public partial class FormPerson : Form
    {
        static FormPerson m_instance;

        public FormPerson()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormPerson GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormPerson();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frm_person_Load(object sender, EventArgs e)
        {
            LoadPerson();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintError(string message)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintSuccess(string message)
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintMessage(string message)
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void LoadPerson()
        {
            string sql = string.Format("select personID, fullName, timeUpdate from Person");
            DataSet ds = TGMTsqlite.GetInstance().LoadData(sql);
            if (ds == null) return;

            DataTable tbl = ds.Tables[0];
            if (tbl.Rows.Count == 0) return;

            for(int i=0; i<tbl.Rows.Count; i++)
            {
                DataRow row = tbl.Rows[i];
                ListViewItem item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row[1].ToString());
                item.SubItems.Add(row[2].ToString());
            }            
        }
       
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frm_person_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
