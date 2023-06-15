using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Helpers
{
    /// <summary>
    /// SKCanvas助手
    /// </summary>
    public static class SKCanvasHelper
    {

        private static SKPaint? GetBorderPaint(Styles styles, StyleType size, StyleType color, StyleType style)
        {
            if (!styles.ContainsKey(size)) return null;
            if (!styles.ContainsKey(color)) return null;
            if (!styles.ContainsKey(style)) return null;
            SKPaint paint = new SKPaint();
            paint.Color = styles.Get<SKColor>(color);
            paint.Style = SKPaintStyle.Stroke;
            paint.StrokeWidth = styles.Get<float>(size);
            var borderStyle = styles.Get<BorderStyleType>(style);
            // 兼容虚线
            switch (borderStyle)
            {
                case BorderStyleType.Dashed:
                    paint.PathEffect = SKPathEffect.CreateDash(new Single[] { 2, 1 }, 0);
                    break;
            }
            return paint;
        }

        /// <summary>
        /// 绘制上边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderTopStyles(this SKCanvas cvs, Styles styles, Rectangle rect)
        {
            var paint = GetBorderPaint(styles, StyleType.BorderTopSize, StyleType.BorderTopColor, StyleType.BorderTopStyle);
            if (paint is null) return;
            // 转为内边距
            float offset = styles.Get<float>(StyleType.BorderTopSize) / 2;
            cvs.DrawLine(offset, offset, rect.Right - offset, offset, paint);
            paint.Dispose();
        }

        /// <summary>
        /// 绘制右边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderRightStyles(this SKCanvas cvs, Styles styles, Rectangle rect)
        {
            var paint = GetBorderPaint(styles, StyleType.BorderRightSize, StyleType.BorderRightColor, StyleType.BorderRightStyle);
            if (paint is null) return;
            // 转为内边距
            float offset = styles.Get<float>(StyleType.BorderRightSize) / 2;
            cvs.DrawLine(rect.Right - offset, offset, rect.Right - offset, rect.Bottom - offset, paint);
            paint.Dispose();
        }

        /// <summary>
        /// 绘制下边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderBottomStyles(this SKCanvas cvs, Styles styles, Rectangle rect)
        {
            var paint = GetBorderPaint(styles, StyleType.BorderBottomSize, StyleType.BorderBottomColor, StyleType.BorderBottomStyle);
            if (paint is null) return;
            // 转为内边距
            float offset = styles.Get<float>(StyleType.BorderBottomSize) / 2;
            cvs.DrawLine(rect.Right - offset, rect.Bottom - offset, offset, rect.Bottom - offset, paint);
            paint.Dispose();
        }

        /// <summary>
        /// 绘制左边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderLeftStyles(this SKCanvas cvs, Styles styles, Rectangle rect)
        {
            var paint = GetBorderPaint(styles, StyleType.BorderLeftSize, StyleType.BorderLeftColor, StyleType.BorderLeftStyle);
            if (paint is null) return;
            // 转为内边距
            float offset = styles.Get<float>(StyleType.BorderLeftSize) / 2;
            cvs.DrawLine(offset, rect.Bottom - offset, offset, offset, paint);
            paint.Dispose();
        }

        /// <summary>
        /// 绘制标准样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        public static void DrawStyles(this SKCanvas cvs, Styles styles, Rectangle rect)
        {
            // 绘制背景
            if (styles.ContainsKey(StyleType.BackgroundColor))
            {
                // 支持背景颜色输出
                var color = styles.Get<SKColor>(StyleType.BackgroundColor);
                cvs.Clear(color);
            }
            // 绘制上边框
            cvs.DrawBorderTopStyles(styles, rect);
            // 绘制右边框
            cvs.DrawBorderRightStyles(styles, rect);
            // 绘制下边框
            cvs.DrawBorderBottomStyles(styles, rect);
            // 绘制左边框
            cvs.DrawBorderLeftStyles(styles, rect);
        }
    }
}
