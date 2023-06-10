using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Drawing
{
    /// <summary>
    /// 矩形
    /// </summary>
    public struct Rectangle
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
        /// 矩形
        /// </summary>
        public Rectangle(float left, float top, float width, float height)
        {
            this.Left = left;
            this.Top = top;
            this.Right = left + width;
            this.Bottom = top + height;
        }

        /// <summary>
        /// X
        /// </summary>
        public float X 
            => this.Left;

        /// <summary>
        /// Y
        /// </summary>
        public float Y 
            => this.Top;

        /// <summary>
        /// 宽度
        /// </summary>
        public float Width
            => this.Right - this.Left;

        /// <summary>
        /// 高度
        /// </summary>
        public float Height
            => this.Bottom - this.Top;

        /// <summary>
        /// 位置
        /// </summary>
        public Point Point 
            => new Point(this.Left, this.Top);

        /// <summary>
        /// 尺寸
        /// </summary>
        public Size Size 
            => new Size(this.Right - this.Left, this.Bottom - this.Top);
    }
}
