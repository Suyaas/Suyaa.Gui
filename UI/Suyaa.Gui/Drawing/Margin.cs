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
        public readonly float Top;
        /// <summary>
        /// 右
        /// </summary>
        public readonly float Right;
        /// <summary>
        /// 下
        /// </summary>
        public readonly float Bottom;
        /// <summary>
        /// 左
        /// </summary>
        public readonly float Left;

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

        /// <summary>
        /// 转化为字符串
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            return $"Margin({this.Top},{this.Right},{this.Bottom},{this.Left})";
        }

        /// <summary>
        /// 转化为字符串
        /// </summary>
        /// <returns></returns>
        public string ToString(string name)
        {
            return $"{name}({this.Top},{this.Right},{this.Bottom},{this.Left})";
        }
    }
}
