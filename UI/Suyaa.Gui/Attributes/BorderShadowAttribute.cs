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
    /// 边框阴影设置
    /// </summary>
    public class BorderShadowAttribute : StyleAttribute
    {
        /// <summary>
        /// 尺寸
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public SKColor Color { get; set; }

        /// <summary>
        /// 水平偏移
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// 垂直偏移
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// 边框样式设置
        /// </summary>
        public BorderShadowAttribute(float x, float y, int size, uint color) : base(StyleType.None)
        {
            this.Size = size;
            this.Color = new SKColor(color);
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Styles styles)
        {
            styles
                .Set(StyleType.BorderShadowSize, this.Size)
                .Set(StyleType.BorderShadowColor, this.Color)
                .Set(StyleType.BorderShadowX, this.X)
                .Set(StyleType.BorderShadowY, this.Y);
        }
    }
}
