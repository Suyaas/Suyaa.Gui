using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 偏移样式设置
    /// </summary>
    public class OffsetAttribute : StyleAttribute
    {
        /// <summary>
        /// 水平偏移
        /// </summary>
        public float X { get; }

        /// <summary>
        /// 垂直偏移
        /// </summary>
        public float Y { get; }

        /// <summary>
        /// 水平对齐方式
        /// </summary>
        public AlignType XAlign { get; }

        /// <summary>
        /// 垂直对齐方式
        /// </summary>
        public AlignType YAlign { get; }

        /// <summary>
        /// 值样式特性
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        public OffsetAttribute(float x, float y) : base(StyleType.None)
        {
            this.X = x;
            this.Y = y;
            this.XAlign = AlignType.Normal;
            this.YAlign = AlignType.Normal;
        }

        /// <summary>
        /// 值样式特性
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        public OffsetAttribute(AlignType xAlign, float x, AlignType yAlign, float y) : base(StyleType.None)
        {
            this.X = x;
            this.Y = y;
            this.XAlign = xAlign;
            this.YAlign = yAlign;
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Styles styles)
        {
            styles
                .Set(StyleType.X, this.X)
                .Set(StyleType.Y, this.Y)
                .Set(StyleType.XAlign, this.XAlign)
                .Set(StyleType.YAlign, this.YAlign);
        }
    }
}
