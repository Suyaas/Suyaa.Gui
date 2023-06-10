using Suyaa.Gui.Drawing;
using Suyaa.Gui.Native.Win32.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Helpers
{
    /// <summary>
    /// 原生对象助手类
    /// </summary>
    public static class NativeHelper
    {
        /// <summary>
        /// 转化为绘图矩形
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static Rectangle ToRectangle(this RECT rect)
        {
            return new Rectangle(rect.left, rect.top, rect.Width, rect.Height);
        }
    }
}
