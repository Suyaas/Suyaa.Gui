//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using System.Windows.Forms;
using Suyaa.Gui;
using Suyaa.Gui.Native.Win32;

namespace Win32App
{
    internal static class Program
    {
        //public static Bitmap? ByteToBitmap(byte[] ImageByte)
        //{
        //    Bitmap? bitmap = null;
        //    try
        //    {
        //        using (MemoryStream stream = new MemoryStream(ImageByte))
        //        {
        //            bitmap = new Bitmap((Image)new Bitmap(stream));
        //        }
        //    }
        //    catch { }
        //    return bitmap;
        //}

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //// To customize application configuration such as set high DPI settings or default font,
            //// see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            Application.Set<Win32Application>().Run(new FrmMain());
        }
    }
}