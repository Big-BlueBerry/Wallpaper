using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;


namespace WallpaperTool
{
    class Youtuber
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        private const int SW_MAXIMISE = 3;

        // 브라우저에서 youtube.com로 이동하기 
        public void OpenWindow()
        {
            SHDocVw.WebBrowser browser = new SHDocVw.WebBrowser();  //Instanciate the class.
            ShowWindow((IntPtr)browser.HWND, SW_MAXIMISE);   //Maximise the window.
            browser.Visible = true;   //Set the window to visible.

            browser.Navigate("http://youtube.com");

            Thread.Sleep(5000);
            browser.Quit();
        }
    }
}
