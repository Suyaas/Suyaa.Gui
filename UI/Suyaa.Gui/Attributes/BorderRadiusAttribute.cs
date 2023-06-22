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
        public BorderRadiusAttribute(float size) : base(StyleType.None)
        {
            this.LeftTop = size;
            this.RightTop = size;
            this.RightBottom = size;
            this.LeftBottom = size;
        }

        /// <summary>
        /// 圆角样式设置
        /// </summary>
        public BorderRadiusAttribute(float leftTop, float rightTop, float rightBottom, float leftBottom) : base(StyleType.None)
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
        protected override void OnApply(Styles styles)
        {
            styles
                .Set(StyleType.BorderRadiusLeftTop, this.LeftTop)
                .Set(StyleType.BorderRadiusRightTop, this.RightTop)
                .Set(StyleType.BorderRadiusRightBottom, this.RightBottom)
                .Set(StyleType.BorderRadiusLeftBottom, this.LeftBottom);
        }
    }
}
