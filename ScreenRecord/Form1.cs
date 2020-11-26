using Accord.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenRecord
{
    public partial class Form1 : Form
    {
        Timer t;
        VideoFileWriter vfw;
        Bitmap img;
        Graphics g;
        string path = "D://myScreen.mp4";

        public Form1()
        {
            InitializeComponent();
            t = new Timer();
            t.Interval = 10;
            t.Tick += t_Tick;
        }

        
        
        

       
        private void StartButton(object sender, EventArgs e)
        {
            vfw = new VideoFileWriter();
            vfw.Open(path, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 10, VideoCodec.MPEG4, 100000);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //start the record
            img = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            g = Graphics.FromImage(img);
            g.CopyFromScreen(0, 0, 0, 0, img.Size);
            pictureBox.Image = img;
            vfw.WriteVideoFrame(img);
        }

        private void SaveButton(object sender, EventArgs e)
        {
            t.Stop();
            vfw.Close();
        }
    }
}
