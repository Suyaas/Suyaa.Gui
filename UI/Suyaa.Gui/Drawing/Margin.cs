using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Drawing
{
    /// <summary>
    /// 边距
    /// </summary>
    public struct Margin
    {
        /// <summary>
        /// 上
        /// </summary>
        public float Top;
        /// <summary>
        /// 右
        /// </summary>
        public float Right;
        /// <summary>
        /// 下
        /// </summary>
        public float Bottom;
        /// <summary>
        /// 左
        /// </summary>
        public float Left;

        /// <summary>
        /// 边距
        /// </summary>
        public Margin(float top, float right, float bottom, float left)
        {
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
            this.Left = left;
        }

        
    }
}
