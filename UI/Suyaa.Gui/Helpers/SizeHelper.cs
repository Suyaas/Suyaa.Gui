using SkiaSharp;
using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Helpers
{
    /// <summary>
    /// 尺寸类
    /// </summary>
    public static class SizeHelper
    {
        /// <summary>
        /// 判断两个尺寸是否相同
        /// </summary>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SameAs(this Size size, Size value)
        {
            return size.Width == value.Width && size.Height == value.Height;
        }
    }
}
