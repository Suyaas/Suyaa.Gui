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
        public static Margin GetShadowMargin(this Styles styles, float scale)
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
                (int)(size - y),
                (int)(size + x),
                (int)(size + y),
                (int)(size - x)
                );
        }

        /// <summary>
        /// 获取内边距
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static Margin GetPadding(this Styles styles, float scale)
        {
            float top = styles.Get<float>(StyleType.PaddingTop, 0) * scale;
            float right = styles.Get<float>(StyleType.PaddingRight, 0) * scale;
            float bottom = styles.Get<float>(StyleType.PaddingBottom, 0) * scale;
            float left = styles.Get<float>(StyleType.PaddingLeft, 0) * scale;
            return new Margin((int)top, (int)right, (int)bottom, (int)left);
        }

        /// <summary>
        /// 获取外边距
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static Margin GetMargin(this Styles styles, float scale)
        {
            float top = styles.Get<float>(StyleType.MarginTop, 0) * scale;
            float right = styles.Get<float>(StyleType.MarginRight, 0) * scale;
            float bottom = styles.Get<float>(StyleType.MarginBottom, 0) * scale;
            float left = styles.Get<float>(StyleType.MarginLeft, 0) * scale;
            return new Margin((int)top, (int)right, (int)bottom, (int)left);
        }

        /// <summary>
        /// 获取外边距
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static Margin GetDisplayMargin(this Styles styles, float scale)
        {
            // 获取边框尺寸
            float top = 0;
            float right = 0;
            float bottom = 0;
            float left = 0;
            // 获取阴影边框尺寸
            var marginShadow = styles.GetShadowMargin(scale);
            if (marginShadow.Top > top) top = marginShadow.Top;
            if (marginShadow.Right > right) right = marginShadow.Right;
            if (marginShadow.Bottom > bottom) bottom = marginShadow.Bottom;
            if (marginShadow.Left > left) left = marginShadow.Top;
            return new Margin(top, right, bottom, left);
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
    }
}
