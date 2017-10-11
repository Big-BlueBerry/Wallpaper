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
using Microsoft.DirectX.AudioVideoPlayback;

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
            VideoBox();
            DrawImage();

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

        private void DrawImage()
        {
            pictureBox1.Image = System.Drawing.Image.FromFile(@"D:\DSM10121HKH\Pictures\images\asuna\wallpaper\301609.jpg");
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

        private void VideoBox()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.FileName = @"C:\Users\DSM10121\Downloads\CA.mp4";
            Video video = new Video(@"C:\Users\DSM10121\Downloads\CA.mp4")
            {
                Owner = this,
                Size = this.Size
            };
            video.Play();
        }
    }
}
