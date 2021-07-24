using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;

namespace Checkin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new frm_findPerson());
            }
            catch(Exception ex)
            {

            }
            
        }

        public static FaceComp g_facecomp = null;
        public static string g_parentDir = "";
    }
}
