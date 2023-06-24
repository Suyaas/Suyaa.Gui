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
        public static Margin GetShadowMargin(this StyleCollection styles, float scale)
        {
            // 获取阴影大小
            var size = (int)(styles.Get(Enums.Styles.BorderShadowSize, 0) * scale);
            if (size <= 0) return new Margin(0, 0, 0, 0);
            // 获取横向偏移
            float x = 0;
            if (styles.ContainsKey(Enums.Styles.BorderShadowX)) x = styles.Get<float>(Enums.Styles.BorderShadowX) * scale;
            // 获取纵向偏移
            float y = 0;
            if (styles.ContainsKey(Enums.Styles.BorderShadowY)) y = styles.Get<float>(Enums.Styles.BorderShadowY) * scale;
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
        public static Margin GetPadding(this StyleCollection styles, float scale)
        {
            float top = styles.Get<float>(Enums.Styles.PaddingTop, 0) * scale;
            float right = styles.Get<float>(Enums.Styles.PaddingRight, 0) * scale;
            float bottom = styles.Get<float>(Enums.Styles.PaddingBottom, 0) * scale;
            float left = styles.Get<float>(Enums.Styles.PaddingLeft, 0) * scale;
            return new Margin((int)top, (int)right, (int)bottom, (int)left);
        }

        /// <summary>
        /// 获取内边距
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static Margin GetBorders(this StyleCollection styles, float scale)
        {
            float top = styles.Get<float>(Enums.Styles.BorderTopSize, 0) * scale;
            float right = styles.Get<float>(Enums.Styles.BorderRightSize, 0) * scale;
            float bottom = styles.Get<float>(Enums.Styles.BorderBottomSize, 0) * scale;
            float left = styles.Get<float>(Enums.Styles.BorderLeftSize, 0) * scale;
            return new Margin((int)top, (int)right, (int)bottom, (int)left);
        }

        /// <summary>
        /// 获取外边距
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static Margin GetMargin(this StyleCollection styles, float scale)
        {
            float top = styles.Get<float>(Enums.Styles.MarginTop, 0) * scale;
            float right = styles.Get<float>(Enums.Styles.MarginRight, 0) * scale;
            float bottom = styles.Get<float>(Enums.Styles.MarginBottom, 0) * scale;
            float left = styles.Get<float>(Enums.Styles.MarginLeft, 0) * scale;
            return new Margin((int)top, (int)right, (int)bottom, (int)left);
        }

        /// <summary>
        /// 获取外边距
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static Margin GetDisplayMargin(this StyleCollection styles, float scale)
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
        public static Size GetSize(this StyleCollection styles, Size parentSize, float scale)
        {
            var width = styles.Get<float>(Enums.Styles.Width) * scale;
            var height = styles.Get<float>(Enums.Styles.Height) * scale;
            var widthUnit = styles.Get<UnitType>(Enums.Styles.WidthUnit);
            var heightUnit = styles.Get<UnitType>(Enums.Styles.HeightUnit);
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
        /// 获取填充画笔
        /// </summary>
        /// <param name="styles"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static SKPaint? GetFillPaint(this StyleCollection styles, Enums.Styles color)
        {
            if (!styles.ContainsKey(color)) return null;
            SKPaint paint = new SKPaint()
            {
                Color = styles.Get<SKColor>(color),
                //Color = new SKColor(0, 0, 0, 33),
                Style = SKPaintStyle.Fill,
                //IsAntialias=styles.Get(style)
            };
            return paint;
        }

        /// <summary>
        /// 获取虚线描述
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static RectangleDashed[] GetDasheds(this StyleCollection styles, Rectangle rect, int[] radiuses)
        {
            // 定义虚线描述
            RectangleDashed[] dasheds = new RectangleDashed[12];

            // 获取边框样式
            bool isTopDashed = styles.Get(Enums.Styles.BorderTopStyle, BorderStyles.Solid) == BorderStyles.Dashed;
            bool isRightDashed = styles.Get(Enums.Styles.BorderRightStyle, BorderStyles.Solid) == BorderStyles.Dashed;
            bool isBottomDashed = styles.Get(Enums.Styles.BorderBottomStyle, BorderStyles.Solid) == BorderStyles.Dashed;
            bool isLeftDashed = styles.Get(Enums.Styles.BorderLeftStyle, BorderStyles.Solid) == BorderStyles.Dashed;

            // 计算左上角2/2
            float start = 0;
            float dist = (float)(radiuses[0] * Math.PI / 4);
            dasheds[0] = new RectangleDashed(start, dist, 8, isTopDashed ? 4 : 0);
            // 计算上边
            start += dist;
            dist = rect.Width - radiuses[0] - radiuses[1];
            dasheds[1] = new RectangleDashed(start, dist, 8, isTopDashed ? 4 : 0);
            // 计算右上角1/2
            //start += rect.Width - radiuses[0] - radiuses[1];
            start += dist;
            dist = (float)(radiuses[1] * Math.PI / 4);
            dasheds[2] = new RectangleDashed(start, dist, 8, isTopDashed ? 4 : 0);

            // 计算右上角2/2
            //start += (float)(radiuses[1] * Math.PI / 4);
            start += dist;
            dist = (float)(radiuses[1] * Math.PI / 4);
            dasheds[3] = new RectangleDashed(start, dist, 8, isRightDashed ? 4 : 0);
            // 计算右边
            //start += (float)(radiuses[1] * Math.PI / 2);
            start += dist;
            dist = rect.Height - radiuses[1] - radiuses[2];
            dasheds[4] = new RectangleDashed(start, dist, 8, isRightDashed ? 4 : 0);
            // 计算右下角1/2
            //start += rect.Height - radiuses[1] - radiuses[2];
            start += dist;
            dist = (float)(radiuses[2] * Math.PI / 4);
            dasheds[5] = new RectangleDashed(start, dist, 8, isRightDashed ? 4 : 0);

            // 计算右下角2/2
            //start += (float)(radiuses[2] * Math.PI / 4);
            start += dist;
            dist = (float)(radiuses[2] * Math.PI / 4);
            dasheds[6] = new RectangleDashed(start, dist, 8, isBottomDashed ? 4 : 0);
            // 计算下边
            //start += (float)(radiuses[2] * Math.PI / 4);
            start += dist;
            dist = rect.Width - radiuses[2] - radiuses[3];
            dasheds[7] = new RectangleDashed(start, dist, 8, isBottomDashed ? 4 : 0);
            // 计算左下角1/2
            //start += rect.Width - radiuses[2] - radiuses[3];
            start += dist;
            dist = (float)(radiuses[3] * Math.PI / 4);
            dasheds[8] = new RectangleDashed(start, dist, 8, isBottomDashed ? 4 : 0);

            // 计算左下角2/2
            //start += (float)(radiuses[3] * Math.PI / 4);
            start += dist;
            dist = (float)(radiuses[3] * Math.PI / 4);
            dasheds[9] = new RectangleDashed(start, dist, 8, isLeftDashed ? 4 : 0);
            // 计算下边
            //start += (float)(radiuses[3] * Math.PI / 4);
            start += dist;
            dist = rect.Height - radiuses[3] - radiuses[0];
            dasheds[10] = new RectangleDashed(start, dist, 8, isLeftDashed ? 4 : 0);
            // 计算左上角1/2
            //start += rect.Height - radiuses[3] - radiuses[0];
            start += dist;
            dist = (float)(radiuses[0] * Math.PI / 4);
            dasheds[11] = new RectangleDashed(start, dist, 8, isLeftDashed ? 4 : 0);
            return dasheds;
        }

        /// <summary>
        /// 样式集合覆盖
        /// </summary>
        /// <param name="styles"></param>
        /// <param name="target"></param>
        public static StyleCollection Cover(this StyleCollection styles, StyleCollection target)
        {
            // 依次设置
            foreach (var style in styles)
            {
                target.Set(style.Key, style.Value);
            }
            // 获取不存在的样式
            List<Enums.Styles> styleTypes = new List<Enums.Styles>();
            foreach (var key in target.Keys)
            {
                if (!styles.ContainsKey(key)) styleTypes.Add(key);
            }
            // 清理不存在的样式
            foreach (var type in styleTypes)
            {
                target.Remove(type);
            }
            return styles;
        }
    }
}
