using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Drawing
{
    /// <summary>
    /// 点
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// X
        /// </summary>
        public readonly float X;
        /// <summary>
        /// Y
        /// </summary>
        public readonly float Y;

        /// <summary>
        /// 点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 点
        /// </summary>
        public Point()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// 判断坐标是否相同
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Equals(Point point)
        {
            return this.X == point.X && this.Y == point.Y;
        }
    }
}
