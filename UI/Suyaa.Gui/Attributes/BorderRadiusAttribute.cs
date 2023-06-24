using SkiaSharp;
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
    /// 圆角样式设置
    /// </summary>
    public class BorderRadiusAttribute : StyleAttribute
    {
        /// <summary>
        /// 左上
        /// </summary>
        public float LeftTop { get; set; }

        /// <summary>
        /// 右上
        /// </summary>
        public float RightTop { get; set; }

        /// <summary>
        /// 右下
        /// </summary>
        public float RightBottom { get; set; }

        /// <summary>
        /// 左下
        /// </summary>
        public float LeftBottom { get; set; }

        /// <summary>
        /// 圆角样式设置
        /// </summary>
        public BorderRadiusAttribute(float size) : base(Enums.Styles.None)
        {
            this.LeftTop = size;
            this.RightTop = size;
            this.RightBottom = size;
            this.LeftBottom = size;
        }

        /// <summary>
        /// 圆角样式设置
        /// </summary>
        public BorderRadiusAttribute(float leftTop, float rightTop, float rightBottom, float leftBottom) : base(Enums.Styles.None)
        {
            this.LeftTop = leftTop;
            this.RightTop = rightTop;
            this.RightBottom = rightBottom;
            this.LeftBottom = leftBottom;
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Drawing.StyleCollection styles)
        {
            styles
                .Set(Enums.Styles.BorderRadiusLeftTop, this.LeftTop)
                .Set(Enums.Styles.BorderRadiusRightTop, this.RightTop)
                .Set(Enums.Styles.BorderRadiusRightBottom, this.RightBottom)
                .Set(Enums.Styles.BorderRadiusLeftBottom, this.LeftBottom);
        }
    }
}
