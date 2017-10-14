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
        int index;
        String[] images;

        public Form1()
        {
            InitializeComponent();
            BehindDesktopIcon.FixBehindDesktopIcon(this.Handle);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.Bounds.Size;

            this.pictureBox1.BackColor = Color.Transparent;

            index = 0;

            //images = GetImages(@"C:\Users\dsm2016\Pictures\wallpaper");
            //SlideShow();

            webBrowser1.Navigate("http://www.youtube.com");
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



        // Show image from local path image
        private void DrawImage(String path)
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = Image.FromFile(@path);
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

        // term 만큼 이미지를 바꿔가며 보여줌 
        private void SlideShow()
        {
            int term = 1000;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = term;
            timer.Tick += ChangeImage;
            timer.Start();            
        }

        // term 마다 실행되면서 이미지를 바꿈
        private void ChangeImage(object sender, EventArgs e)
        {
            index = index >= images.Length ? 0 : index;
            DrawImage(images[index]);
            index += 1;
            if (!pictureBox1.Enabled)
                pictureBox1.Enabled = true;
        }
    }
}
