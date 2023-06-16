using SkiaSharp;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Drawing
{
    /// <summary>
    /// 助手类
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// 获取外边距
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static Margin GetMargin(this Styles styles, float scale)
        {
            if (!styles.ContainsKey(StyleType.BorderShadowSize)) return new Margin(0, 0, 0, 0);
            // 获取阴影大小
            var size = styles.Get<float>(StyleType.BorderShadowSize) * scale;
            // 获取横向偏移
            float x = 0;
            if (styles.ContainsKey(StyleType.BorderShadowX)) x = styles.Get<float>(StyleType.BorderShadowX) * scale;
            // 获取纵向偏移
            float y = 0;
            if (styles.ContainsKey(StyleType.BorderShadowY)) y = styles.Get<float>(StyleType.BorderShadowY) * scale;
            return new Margin(
                (size - y > 0) ? size - x : 0,
                (size + x > 0) ? size + x : 0,
                (size + y > 0) ? size + y : 0,
                (size - x > 0) ? size - x : 0
                );
        }

        /// <summary>
        /// 获取有效尺寸
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static Size GetSize(this Styles styles, Size parentSize, float scale)
        {
            var width = styles.Get<float>(StyleType.Width) * scale;
            var height = styles.Get<float>(StyleType.Height) * scale;
            var widthUnit = styles.Get<UnitType>(StyleType.WidthUnit);
            var heightUnit = styles.Get<UnitType>(StyleType.HeightUnit);
            if (widthUnit == UnitType.Percentage)
            {
                width = parentSize.Width * (width / 100);
            }
            if (heightUnit == UnitType.Percentage)
            {
                height = parentSize.Height * (height / 100);
            }
            return new Size((int)width, (int)height);
        }

        /// <summary>
        /// 获取外边距
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static Rectangle GetRectangle(this Styles styles, Rectangle rect, Margin margin, float scale)
        {
            #region 处理尺寸
            var width = styles.Get<float>(StyleType.Width);
            var height = styles.Get<float>(StyleType.Height);
            var widthUnit = styles.Get<UnitType>(StyleType.WidthUnit);
            var heightUnit = styles.Get<UnitType>(StyleType.HeightUnit);
            if (widthUnit == UnitType.Percentage)
            {
                width = rect.Width * (width / 100);
            }
            if (heightUnit == UnitType.Percentage)
            {
                height = rect.Height * (height / 100);
            }
            var drawWidth = width * scale + margin.Left + margin.Right;
            var drawHeight = height * scale + margin.Top + margin.Bottom;
            #endregion

            #region 处理对齐
            var x = styles.Get<float>(StyleType.X);
            var y = styles.Get<float>(StyleType.Y);
            var left = x * scale;
            var top = y * scale;
            var xAlign = styles.Get<AlignType>(StyleType.XAlign);
            var yAlign = styles.Get<AlignType>(StyleType.YAlign);
            switch (xAlign)
            {
                case AlignType.Center:
                    left = (rect.Width - drawWidth) / 2 + x * scale;
                    break;
                case AlignType.Opposite:
                    left = rect.Right - drawWidth - x * scale;
                    break;
            }
            switch (yAlign)
            {
                case AlignType.Center:
                    top = (rect.Height - drawHeight) / 2 + y * scale;
                    break;
                case AlignType.Opposite:
                    top = rect.Bottom - drawHeight - y * scale;
                    break;
            }
            #endregion
            return new Rectangle(left, top, width, height);
        }
    }
}
