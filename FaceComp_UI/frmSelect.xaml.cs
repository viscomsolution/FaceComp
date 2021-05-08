using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TGMTcs;

namespace FaceCompExample
{
    /// <summary>
    /// Interaction logic for frmSelect.xaml
    /// </summary>
    public partial class frmSelect : Window
    {
        public frmSelect()
        {
            InitializeComponent();

            this.Title = FaceComp.GetVersion();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            frmCompare frm = null;
            try
            {
                this.Hide();
                frm = new frmCompare();
                frm.Closed += Frm_Closed;
                frm.ShowDialog();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (frm != null)
                    frm.Close();
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            frmSearch frm = null;
            try
            {
                this.Hide();
                frm = new frmSearch();
                frm.Closed += Frm_Closed;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (frm != null)
                    frm.Close();
            }
        }

        private void btn_gender_Click(object sender, RoutedEventArgs e)
        {
            frmGender frm = null;
            try
            {
                this.Hide();
                frm = new frmGender();
                frm.Closed += Frm_Closed;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {

                if (frm != null)
                    frm.Close();
            }
        }

        private void Frm_Closed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://viscomsolution.com/facecomp-phan-mem-so-sanh-khuon-mat/");
        }

    }
}
