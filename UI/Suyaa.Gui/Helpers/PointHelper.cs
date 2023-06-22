using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Helpers
{
    /// <summary>
    /// 点助手类
    /// </summary>
    public static class PointHelper
    {
        // 获取单位向量
        private static Point GetUnitPoint(float x, float y)
        {
            var distSquare = x * x + y * y;
            var dist = (float)Math.Sqrt(distSquare);
            return new Point(x / dist, x / dist);
        }

        /// <summary>
        /// 获取单位向量
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Point ToUnitPoint(this Point p)
        {
            return GetUnitPoint(p.X, p.Y);
        }

        /// <summary>
        /// 计算点相对于线的位置
        /// 0(on)1(left)-1(right)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static int RelativeToLine(this Point p, Point p1, Point p2)
        {
            var res = (p1.Y - p2.Y) * p.X + (p2.X - p1.X) * p.Y + p1.X * p2.Y - p2.X * p1.Y;
            return res == 0 ? 0 : (res > 0 ? 1 : -1);
        }
    }
}
