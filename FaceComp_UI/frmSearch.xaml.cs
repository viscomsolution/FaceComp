using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
using System.Threading;
using Microsoft.Win32;
using System.ComponentModel;
using System.Windows.Threading;

namespace FaceCompExample
{
    /// <summary>
    /// Interaction logic for frmWebcam.xaml
    /// </summary>
    public partial class frmSearch : Window
    {
        VideoCaptureDevice m_videoSource;
        public Bitmap imageTaken = null;
        string m_imagePath;        
        DispatcherTimer timerProgress = new DispatcherTimer();
        string m_result;

        FaceComp faceComp;        

        public frmSearch()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

            InitializeComponent();
            InitCamera();

            btnSearch.Visibility = Visibility.Hidden;
            btnSnapshot.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Hidden;
            cbWebcam.Visibility = Visibility.Hidden;
            progressbar.Visibility = Visibility.Hidden;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            faceComp = new FaceComp();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Visibility = Visibility.Visible;

            this.Title =  FaceComp.GetVersion() + (faceComp.HasLicense ? " (License is valid)" : " (No license - Contact: 0939.825.125)");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CbWebcam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConnectLocalCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitCamera()
        {
            cbWebcam.Items.Clear();

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources.Count == 0)
            {
                MessageBox.Show("Can not find camera");
                return;
            }


            for (int i = 0; i < videosources.Count; i++)
            {
                cbWebcam.Items.Add(videosources[i].Name);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ConnectLocalCamera()
        {
            if (cbWebcam.Items.Count == 0 || cbWebcam.SelectedIndex == -1)
                return;
            if (m_videoSource != null)
            {
                m_videoSource.Stop();
            }
            else
            {
                FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                m_videoSource = new VideoCaptureDevice(videosources[cbWebcam.SelectedIndex].MonikerString);
                
            }

            m_videoSource.NewFrame += new NewFrameEventHandler(OnCameraFrame);
            m_videoSource.Start();
            btnSnapshot.Visibility = Visibility.Visible;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnCameraFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                BitmapImage bi;
                using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                {
                    imageTaken = (Bitmap)bitmap.Clone();
                    bi = new BitmapImage();
                    bi.BeginInit();
                    MemoryStream ms = new MemoryStream();
                    bitmap.Save(ms, ImageFormat.Bmp);
                    bi.StreamSource = ms;
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.EndInit();
                }
                bi.Freeze();
                Dispatcher.BeginInvoke(new ThreadStart(delegate { picturebox1.Source = bi; }));

                Thread.Sleep(10);
            }
            catch (Exception ex)
            {
                //catch your error here
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnWebcam_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (cbWebcam.Items.Count == 0)
                return;
            cbWebcam.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            btnWebcam.Visibility = Visibility.Hidden;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnOpenFile_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files |*.bmp;*.jpg;*.png;*.BMP;*.JPG;*.PNG";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                m_imagePath = ofd.FileName;
                picturebox1.Source = TGMTimage.LoadImageWithoutLock(m_imagePath);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnOpenFolder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if(result == System.Windows.Forms.DialogResult.OK)
                {
                    txtDirPath.Text = dialog.SelectedPath;
                }                
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (m_imagePath == null || m_imagePath == "" || txtDirPath.Text == "")
                return;

            List<string> arguments = new List<string>() { m_imagePath, txtDirPath.Text };

            BackgroundWorker workerSearch = new BackgroundWorker();
            workerSearch.WorkerReportsProgress = true;
            workerSearch.DoWork += workerSearch_DoWork;
            workerSearch.RunWorkerCompleted += workerSearch_RunWorkerCompleted;
            workerSearch.RunWorkerAsync(arguments);


            progressbar.Visibility = Visibility.Visible;
            
            timerProgress.Tick += new EventHandler(dispatcherTimer_Tick);
            timerProgress.Interval = TimeSpan.FromMilliseconds(50);
            timerProgress.IsEnabled = true;
            timerProgress.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            progressbar.Value += 1;
            if (progressbar.Value >= progressbar.Maximum)
                progressbar.Value = progressbar.Minimum;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> arguments = e.Argument as List<string>;
            string imagePath = arguments[0];
            string dirPath = arguments[1];

            //string filePath = faceCompMgr.FindMostSimilar(imagePath, dirPath, true);
            //e.Result = filePath;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                string filePath = e.Result.ToString();

                if (filePath != "")
                {
                    string[] splitted = filePath.Split(',');
                    filePath = splitted[0];
                    if (filePath != "" && splitted.Length > 1)
                    {
                        int percent = int.Parse(splitted[1]);
                        lblPercent.Content = percent.ToString() + "%";

                        if (percent >= faceComp.Thresh)
                            lblPercent.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0x00, 0xBB, 0x3C));
                        else
                            lblPercent.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));

                        picturebox2.Source = TGMTimage.LoadImageWithoutLock(filePath);

                        m_result = filePath;
                    }
                }
            }
            catch(Exception ex)
            {

            }
                      

            btnSearch.IsEnabled = true;
            timerProgress.Stop();
            progressbar.Value = progressbar.Minimum;
            progressbar.Visibility = Visibility.Hidden;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnSnapshot_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (m_videoSource != null)
                m_videoSource.Stop();

            string datetime = DateTime.Now.AddHours(7).ToString("yyyy-MM-dd-hh-mm-ss") + ".jpg";

            imageTaken.Save(datetime, ImageFormat.Jpeg);
            m_imagePath = datetime;

            label1.Visibility = Visibility.Hidden;
            cbWebcam.Visibility = Visibility.Hidden;
            btnSnapshot.Visibility = Visibility.Hidden;
            btnWebcam.Visibility = Visibility.Visible;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Picturebox2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(m_result != "")
            {
                System.Diagnostics.Process.Start(m_result);
            }
        }
    }

    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(Bitmap bmp)
        {
            bitmap = bmp;
        }
        public Bitmap bitmap;
    }
}
