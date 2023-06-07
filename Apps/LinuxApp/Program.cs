using SkiaSharp;
using System;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.InteropServices;
using Suyaa.Gui.LinuxNative.Apis;
using Suyaa.Gui;
using Suyaa.Gui.LinuxNative;

namespace LinuxApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.Set<XApplication>().Run(new FrmMain());
        }
    }
}