using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Drawing
{
    /// <summary>
    /// 助手类
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// 判断矩形是否包含坐标
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Contain(this Rectangle rect, Point p)
        {
            return p.X >= rect.Left && p.X <= rect.Right && p.Y >= rect.Top && p.Y <= rect.Bottom;
        }
    }
}
