using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Drawing
{
    /// <summary>
    /// 尺寸
    /// </summary>
    public struct Size
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public float Width;
        /// <summary>
        /// 高度
        /// </summary>
        public float Height;

        /// <summary>
        /// 尺寸
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Size(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// 尺寸
        /// </summary>
        public Size()
        {
            this.Width = 0;
            this.Height = 0;
        }
    }
}
