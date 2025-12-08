using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;


namespace SmartSecurityCam_v1
{
    public partial class Form1 : Form
    {
        private VideoCapture capture;
        private Mat frame;
        private Mat prevGray;
        private bool isRunning = false;
        private Thread cameraThread;

        private string snapshotFolder = "Snapshots";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(snapshotFolder))
                    System.IO.Directory.CreateDirectory(snapshotFolder);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);

            if (!capture.IsOpened())
            {
                MessageBox.Show("Cannot open camera, Close other apps using the camera.");
                return;
            }

            frame = new Mat();
            prevGray = null;
            isRunning = true;

            cameraThread = new Thread(CameraLoop);
            cameraThread.IsBackground = true;
            cameraThread.Start();
        }

        private void CameraLoop()
        {
            while (isRunning)
            {
                Mat temp = new Mat();

                if (!capture.Grab())
                {
                    Thread.Sleep(5);
                    continue;
                }

                // Safe Retrieve (pulls the grabbed frame)
                capture.Retrieve(temp);

                if (temp.Empty())
                    continue;

                // Use temp as the current frame
                frame?.Dispose();
                frame = temp.Clone();

                // Motion detection

                using (Mat gray = new Mat())
                {
                    Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);
                    Cv2.GaussianBlur(gray, gray, new OpenCvSharp.Size(21, 21), 0);

                    if (prevGray != null)
                    {
                        using (Mat diff = new Mat())
                        {
                            Cv2.Absdiff(prevGray, gray, diff);
                            Cv2.Threshold(diff, diff, 25, 255, ThresholdTypes.Binary);

                            int count = Cv2.CountNonZero(diff);

                            if (count > 5000)
                            {
                                listLog.Invoke(new Action(() =>
                                {
                                    listLog.Items.Add($"Motion detected at {DateTime.Now}");
                                    listLog.TopIndex = listLog.Items.Count - 1;
                                }));
                            }
                        }
                    }

                    prevGray?.Dispose();
                    prevGray = gray.Clone();
                }

                // Show camera feed

                byte[] bmpData = frame.ImEncode(".bmp");
                using (var ms = new System.IO.MemoryStream(bmpData))
                {
                    Bitmap bitmap = new Bitmap(ms);
                    pictureBoxFeed.Invoke(new Action(() =>
                    {
                        pictureBoxFeed.Image?.Dispose();
                        pictureBoxFeed.Image = bitmap;
                    }));
                }
            }

            // Cleanup after the loop completes
            capture?.Release();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isRunning = false;

            if (cameraThread != null && cameraThread.IsAlive) 
            {
                int waited = 0;
                while (cameraThread.IsAlive && waited < 2000)
                {
                    Application.DoEvents();
                    Thread.Sleep(50);
                    waited += 50;
                }
            }
            capture?.Release();
            capture?.Dispose();
            capture = null;

            frame?.Release();
            frame = null;

            prevGray?.Dispose();
            prevGray = null;

            if (pictureBoxFeed.InvokeRequired)
            {
                pictureBoxFeed.Invoke(new Action(() =>
                {
                    pictureBoxFeed.Image?.Dispose();
                    pictureBoxFeed.Image = null;
                }));
            }
            else
            {
                pictureBoxFeed?.Dispose();
                pictureBoxFeed = null;
            }

            if (listLog.InvokeRequired)
            {
                listLog.Invoke(new Action(() =>
                {
                    listLog.Items.Add("Camera Stopped");
                }));
            }
            else
            {
                listLog.Items.Add("Camera Stopped");
            }
        }
    }
}
