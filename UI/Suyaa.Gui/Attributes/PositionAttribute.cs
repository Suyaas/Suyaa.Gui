using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
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
    public class PositionAttribute : StyleAttribute
    {
        /// <summary>
        /// 定位方式
        /// </summary>
        public Positions Position { get; }

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
        public PositionAttribute(float x, float y) : base(Enums.Styles.None)
        {
            this.X = x;
            this.Y = y;
            this.XAlign = AlignType.Normal;
            this.YAlign = AlignType.Normal;
            this.Position = Positions.Fixed;
        }

        /// <summary>
        /// 值样式特性
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        public PositionAttribute(float x, float y, AlignType xAlign, AlignType yAlign) : base(Enums.Styles.None)
        {
            this.X = x;
            this.Y = y;
            this.XAlign = xAlign;
            this.YAlign = yAlign;
            this.Position = Positions.Fixed;
        }

        /// <summary>
        /// 值样式特性
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        public PositionAttribute(AlignType xAlign, AlignType yAlign) : base(Enums.Styles.None)
        {
            this.X = 0;
            this.Y = 0;
            this.XAlign = xAlign;
            this.YAlign = yAlign;
            this.Position = Positions.Float;
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Drawing.StyleCollection styles)
        {
            styles
                .Set(Enums.Styles.X, this.X)
                .Set(Enums.Styles.Y, this.Y)
                .Set(Enums.Styles.XAlign, this.XAlign)
                .Set(Enums.Styles.YAlign, this.YAlign)
                .Set(Enums.Styles.Position, this.Position);
        }
    }
}
