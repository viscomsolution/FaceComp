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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using TGMTcs;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Video.DirectShow;
using System.Threading;
using AForge.Video;
using System.ComponentModel;
using System.Windows.Threading;

namespace FaceComp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class frmLandmark : Window
    {
        string imagePath1;
        string imagePath2;

        int m_imageIndex = 0;

        FaceCompMgr faceCompMgr;
        Bitmap imageTaken = null;

        VideoCaptureDevice m_videoSource;
        DispatcherTimer timerProgress = new DispatcherTimer();

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public frmLandmark()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

            InitializeComponent();
            
            btnOpen1.Visibility = Visibility.Hidden;
            btnOpen2.Visibility = Visibility.Hidden;

            btnWebcam1.Visibility = Visibility.Hidden;
            btnWebcam2.Visibility = Visibility.Hidden;

            label1.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;

            cbWebcam1.Visibility = Visibility.Hidden;
            cbWebcam2.Visibility = Visibility.Hidden;

            btnSnapshot1.Visibility = Visibility.Hidden;
            btnSnapshot2.Visibility = Visibility.Hidden;

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

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Title = FaceCompMgr.GetVersion() + (faceCompMgr.HasLicense ? " (License is valid)" : " (No license - Contact: 0939.825.125)");

            btnOpen1.Visibility = Visibility.Visible;
            btnOpen2.Visibility = Visibility.Visible;

            btnWebcam1.Visibility = Visibility.Visible;
            btnWebcam2.Visibility = Visibility.Visible;

            timerProgress.Stop();
            progressbar.Visibility = Visibility.Hidden;            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            faceCompMgr = new FaceCompMgr();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        void Compare()
        {
            Thread t1 = new Thread(new ThreadStart(GetSimilarPercent));
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(DrawLandmarkAndSave));
            t2.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void GetSimilarPercent()
        {
            if (imagePath1 != null && imagePath2 != null && imagePath1 != "" && imagePath2 != "")
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                FacialCompare result = faceCompMgr.Compare(imagePath1, imagePath2, true);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                

                this.Dispatcher.Invoke(() =>
                {
                    label.Content = result.percent + "% (" + elapsedMs + "ms)";
                    if (result.percent >= faceCompMgr.Thresh)
                        label.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0x00, 0xBB, 0x3C));
                    else
                        label.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                });
                
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DrawLandmarkAndSave()
        {
            if (imagePath1 != null && imagePath2 != null && imagePath1 != "" && imagePath2 != "")
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                string imageOutputPath1 = Directory.GetCurrentDirectory() + "\\result1.jpg";
                string imageOutputPath2 = Directory.GetCurrentDirectory() + "\\result2.jpg";
                faceCompMgr.DrawLandmarkAndSave(imagePath1, imageOutputPath1);
                faceCompMgr.DrawLandmarkAndSave(imagePath2, imageOutputPath2);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                this.Dispatcher.Invoke(() =>
                {
                    imageResult1.Source = TGMTimage.LoadImageWithoutLock(imageOutputPath1);
                });


                this.Dispatcher.Invoke(() =>
                {
                    imageResult2.Source = TGMTimage.LoadImageWithoutLock(imageOutputPath2);
                });

            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnOpen1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files |*.bmp;*.jpg;*.png;*.BMP;*.JPG;*.PNG";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                imagePath1 = ofd.FileName;
                image1.Source = TGMTimage.LoadImageWithoutLock(imagePath1);
            }

            Compare();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnOpen2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files |*.bmp;*.jpg;*.png;*.BMP;*.JPG;*.PNG";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                imagePath2 = ofd.FileName;
                image2.Source = TGMTimage.LoadImageWithoutLock(imagePath2);
            }

            Compare();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnWebcam1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            m_imageIndex = 1;
            InitCamera(1);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnWebcam2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            m_imageIndex = 2;
            InitCamera(2); 
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmWebcam_RaiseCustomEvent(object sender, CustomEventArgs e)
        {
            if(m_imageIndex == 1)
                image1.Source = ToBitmapImage(e.bitmap);
            else
                image2.Source = ToBitmapImage(e.bitmap);
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

        void InitCamera(int pictureIndex)
        {
            cbWebcam1.Items.Clear();
            cbWebcam2.Items.Clear();

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources.Count == 0)
            {
                MessageBox.Show("Can not find camera");
                return;
            }


            for (int i = 0; i < videosources.Count; i++)
            {
                cbWebcam1.Items.Add(videosources[i].Name);
                cbWebcam2.Items.Add(videosources[i].Name);
            }

            if (pictureIndex == 1)
            {
                cbWebcam1.Visibility = Visibility.Visible;
                label1.Visibility = Visibility.Visible;
                btnWebcam1.Visibility = Visibility.Hidden;
            }                
            else
            {
                cbWebcam2.Visibility = Visibility.Visible;
                label2.Visibility = Visibility.Visible;
                btnWebcam2.Visibility = Visibility.Hidden;
            }                
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ConnectLocalCamera(int pictureIndex)
        {
            if (pictureIndex == 1)
            {
                if (cbWebcam1.Items.Count == 0 || cbWebcam1.SelectedIndex == -1)
                    return;
            }
            else
            {
                if (cbWebcam2.Items.Count == 0 || cbWebcam2.SelectedIndex == -1)
                    return;
            }

            if (m_videoSource != null)
            {
                m_videoSource.Stop();
            }
            else
            {
                FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (pictureIndex == 1)
                {
                    m_videoSource = new VideoCaptureDevice(videosources[cbWebcam1.SelectedIndex].MonikerString);

                }
                else
                {
                    m_videoSource = new VideoCaptureDevice(videosources[cbWebcam2.SelectedIndex].MonikerString);

                }
            }

            m_videoSource.NewFrame += new NewFrameEventHandler(OnCameraFrame);
            m_videoSource.Start();

            if (pictureIndex == 1)
            {
                btnSnapshot1.Visibility = Visibility.Visible;
            }
            else
            {
                btnSnapshot2.Visibility = Visibility.Visible;
            }
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
                if(m_imageIndex ==1)
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { image1.Source = bi; }));
                else
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { image2.Source = bi; }));

                //Thread.Sleep(10);
            }
            catch (Exception ex)
            {
                //catch your error here
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnSnapshot1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (m_videoSource != null)
                m_videoSource.Stop();

            string datetime = DateTime.Now.AddHours(7).ToString("yyyy-MM-dd-hh-mm-ss") + ".jpg";

            imageTaken.Save(datetime, ImageFormat.Jpeg);
            imagePath2 = datetime;

            label1.Visibility = Visibility.Hidden;
            cbWebcam1.Visibility = Visibility.Hidden;
            btnSnapshot1.Visibility = Visibility.Hidden;
            btnWebcam1.Visibility = Visibility.Visible;

            Compare();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnSnapshot2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (m_videoSource != null)
                m_videoSource.Stop();

            string datetime = DateTime.Now.AddHours(7).ToString("yyyy-MM-dd-hh-mm-ss") + ".jpg";

            imageTaken.Save(datetime, ImageFormat.Jpeg);
            imagePath2 = datetime;

            label2.Visibility = Visibility.Hidden;
            cbWebcam2.Visibility = Visibility.Hidden;
            btnSnapshot2.Visibility = Visibility.Hidden;
            btnWebcam2.Visibility = Visibility.Visible;

            Compare();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CbWebcam1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            ConnectLocalCamera(1);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CbWebcam2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConnectLocalCamera(2);
        }
    }
}
