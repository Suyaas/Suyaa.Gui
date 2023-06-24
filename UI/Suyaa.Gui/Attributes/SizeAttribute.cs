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
    /// 尺寸样式设置
    /// </summary>
    public class SizeAttribute : StyleAttribute
    {
        /// <summary>
        /// 宽度单位
        /// </summary>
        public UnitType WidthUnit { get; }

        /// <summary>
        /// 高度单位
        /// </summary>
        public UnitType HeightUnit { get; }

        /// <summary>
        /// 宽度
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// 高度
        /// </summary>
        public float Height { get; }

        /// <summary>
        /// 值样式特性
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        public SizeAttribute(float width, float height) : base(Enums.Styles.None)
        {
            this.WidthUnit = UnitType.Pixel;
            this.HeightUnit = UnitType.Pixel;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// 值样式特性
        /// </summary>
        /// <param name="style"></param>
        /// <param name="value"></param>
        public SizeAttribute(float width, float height, UnitType widthUnit, UnitType heightUnit) : base(Enums.Styles.None)
        {
            this.WidthUnit = widthUnit;
            this.HeightUnit = heightUnit;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        protected override void OnApply(Drawing.StyleCollection styles)
        {
            styles
                .Set(Enums.Styles.WidthUnit, this.WidthUnit)
                .Set(Enums.Styles.HeightUnit, this.HeightUnit)
                .Set(Enums.Styles.Width, this.Width)
                .Set(Enums.Styles.Height, this.Height);
        }
    }
}
