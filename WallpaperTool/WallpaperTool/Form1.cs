using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using ShockwaveFlashObjects;

namespace WallpaperTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BehindDesktopIcon.FixBehindDesktopIcon(this.Handle);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.Bounds.Size;

            String[] images = GetImages(@"C:\Users\dsm2016\Pictures\wallpaper");
            SlideShow(images);
        }

        // rainbow background
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Black, Color.Black, 0, false);
            ColorBlend cb = new ColorBlend();
            cb.Positions = new[] { 0, 1 / 6f, 2 / 6f, 3 / 6f, 4 / 6f, 5 / 6f, 1 };
            cb.Colors = new[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Navy, Color.Purple };
            brush.InterpolationColors = cb;
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        // Play youtube video from internet
        private void PlayYoutube()
        {
            axShockwaveFlash1.Movie= "http://youtube.com/v/oyEuk8j8imI";
            axShockwaveFlash1.Play();
        }

        // Show image from local path image
        private void DrawImage(String path)
        {
            pictureBox1.Image = System.Drawing.Image.FromFile(@path);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Location = this.Location;
            pictureBox1.Size = this.Size;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // path로 부터 모든 이미지 파일(path)를 가져와 String[]으로 return
        private String[] GetImages(String path)
        {
            //List<string> images = new List<string>();
            String[] names = Directory.GetFiles(path);
            String[] images = (from name in names
                         where name.EndsWith(".png") || name.EndsWith(".jpg") || name.EndsWith(".bmp") || name.EndsWith(".jpeg")
                         select name).ToArray();

            return images;
        }

        private void SlideShow(String[] images)
        {
            DrawImage(images[0]);

            // 1000 == 1초
            //    Thread.Sleep(100000);
            DrawImage(images[1]);

            //// 1000 == 1초
            //Thread.Sleep(100000);
            //DrawImage(images[2]);

            //// 1000 == 1초
            //Thread.Sleep(100000);

        }
    }
}
