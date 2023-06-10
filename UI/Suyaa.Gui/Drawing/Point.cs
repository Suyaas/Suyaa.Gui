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
        public float X; 
        /// <summary>
        /// Y
        /// </summary>
        public float Y;

        /// <summary>
        /// 点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(float x,float y)
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
    }
}
