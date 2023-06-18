using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rectangle = Suyaa.Gui.Drawing.Rectangle;

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
            SKPaint paint = new SKPaint()
            {
                Color = styles.Get<SKColor>(color),
                Style = SKPaintStyle.Stroke,
                StrokeWidth = styles.Get<float>(size),
            };
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
            cvs.DrawLine(rect.Left + offset, rect.Top + offset, rect.Right - offset, rect.Top + offset, paint);
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
            cvs.DrawLine(rect.Right - offset, rect.Top + offset, rect.Right - offset, rect.Bottom - offset, paint);
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
            cvs.DrawLine(rect.Right - offset, rect.Bottom - offset, rect.Top + offset, rect.Bottom - offset, paint);
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
            cvs.DrawLine(rect.Left + offset, rect.Bottom - offset, rect.Left + offset, rect.Top + offset, paint);
            paint.Dispose();
        }

        /// <summary>
        /// 绘制背景
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBackgroundStyles(this SKCanvas cvs, Styles styles, Rectangle rect)
        {
            if (styles.ContainsKey(StyleType.BackgroundColor))
            {
                using (SKPaint paint = new SKPaint()
                {
                    Color = styles.Get<SKColor>(StyleType.BackgroundColor),
                    Style = SKPaintStyle.Fill,
                })
                {
                    cvs.DrawRect(rect.Left, rect.Top, rect.Width, rect.Height, paint);
                }
            }
        }

        // 获取长度比例上的透明度值
        private static byte GetDistAlpha(byte alpha, float dist, float distFull)
        {
            // 获取比例
            float scale = 1 - dist / distFull;
            // 计算透明度
            return (byte)(scale * scale * scale * alpha);
        }

        /// <summary>
        /// 绘制阴影样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        public static void DrawShadowStyles(this SKCanvas cvs, Styles styles, Rectangle rect, float scale)
        {
            // 获取配置
            if (!styles.ContainsKey(StyleType.BorderShadowColor)) return;
            int size = (int)(styles.Get(StyleType.BorderShadowSize, 0) * scale);
            if (size <= 0) return;
            int offsetX = (int)(styles.Get<float>(StyleType.BorderShadowX, 0) * scale);
            int offsetY = (int)(styles.Get<float>(StyleType.BorderShadowY, 0) * scale);
            SKColor color = styles.Get<SKColor>(StyleType.BorderShadowColor);
            //SKColor colorStyle = styles.Get<SKColor>(StyleType.BorderShadowColor);
            //SKColor color = new SKColor(colorStyle.Red, colorStyle.Green, colorStyle.Blue, 255);
            // 逐行处理像素
            int size2 = (int)(size * 1.6);
            int dist2 = size2 * size2;
            int width = (int)(rect.Width + size * 2);
            int height = (int)(rect.Height + size * 2);
            // 偏移超过尺寸
            if (offsetX > size) width += offsetX - size;
            if (offsetX < -size) width += Math.Abs(offsetX + size);
            // 计算四个角的无偏移圆心
            Point[] ops = new Point[]
            {
                // 左上
                new Point(size2, size2),
                // 右上
                new Point(width - 1 - size2, size2),
                // 右下
                new Point(width - 1 - size2, height - 1 - size2),
                // 左下
                new Point(size2, height - 1 - size2),
            };
            // 逐行处理
            for (int yr = 0; yr < height; yr++)
            {
                // 逐像素处理
                for (int xr = 0; xr < width; xr++)
                {
                    // 转化为无偏移坐标
                    int x = xr;
                    int y = yr;
                    // 划分左上、右上、右下、左下四个区域进行处理
                    if (x <= width / 2)
                    {
                        if (y <= height / 2)
                        {
                            #region 左上
                            // 获取左上角的圆心
                            var op = ops[0];
                            if (x < op.X && y < op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (op.X - x) * (op.X - x) + (op.Y - y) * (op.Y - y);
                                // 在半径范围内则输出
                                if (dist <= dist2)
                                {
                                    // 计算当前坐标的透明度
                                    byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                    // 绘制点
                                    cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                                }
                            }
                            else if (x < op.X)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (op.X - x) * (op.X - x);
                                // 计算当前坐标的透明度
                                byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                // 绘制点
                                cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                            }
                            else if (y < op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (op.Y - y) * (op.Y - y);
                                // 计算当前坐标的透明度
                                byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                // 绘制点
                                cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                            }
                            else
                            {
                                // 绘制点
                                cvs.DrawPoint(xr, yr, color);
                            }
                            #endregion
                        }
                        else
                        {
                            #region 左下
                            // 获取左下角的圆心
                            var op = ops[3];
                            if (x < op.X && y > op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (op.X - x) * (op.X - x) + (op.Y - y) * (op.Y - y);
                                // 在半径范围内则输出
                                if (dist <= dist2)
                                {
                                    // 计算当前坐标的透明度
                                    byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                    // 绘制点
                                    cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                                }
                            }
                            else if (x < op.X)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (op.X - x) * (op.X - x);
                                // 计算当前坐标的透明度
                                byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                // 绘制点
                                cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                            }
                            else if (y > op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (y - op.Y) * (y - op.Y);
                                // 计算当前坐标的透明度
                                byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                // 绘制点
                                cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                            }
                            else
                            {
                                // 绘制点
                                cvs.DrawPoint(xr, yr, color);
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        if (y <= height / 2)
                        {
                            #region 右上
                            // 获取右上角的圆心
                            var op = ops[1];
                            if (x > op.X && y < op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (op.X - x) * (op.X - x) + (op.Y - y) * (op.Y - y);
                                // 在半径范围内则输出
                                if (dist <= dist2)
                                {
                                    // 计算当前坐标的透明度
                                    byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                    // 绘制点
                                    cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                                }
                            }
                            else if (x > op.X)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (x - op.X) * (x - op.X);
                                // 计算当前坐标的透明度
                                byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                // 绘制点
                                cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                            }
                            else if (y < op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (op.Y - y) * (op.Y - y);
                                // 计算当前坐标的透明度
                                byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                // 绘制点
                                cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                            }
                            else
                            {
                                // 绘制点
                                cvs.DrawPoint(xr, yr, color);
                            }
                            #endregion
                        }
                        else
                        {
                            #region 右下
                            // 获取右下角的圆心
                            var op = ops[2];
                            if (x > op.X && y > op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (op.X - x) * (op.X - x) + (op.Y - y) * (op.Y - y);
                                // 在半径范围内则输出
                                if (dist <= dist2)
                                {
                                    // 计算当前坐标的透明度
                                    byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                    // 绘制点
                                    cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                                }
                            }
                            else if (x > op.X)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (x - op.X) * (x - op.X);
                                // 计算当前坐标的透明度
                                byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                // 绘制点
                                cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                            }
                            else if (y > op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = (y - op.Y) * (y - op.Y);
                                // 计算当前坐标的透明度
                                byte alpha = GetDistAlpha(color.Alpha, dist, dist2);
                                // 绘制点
                                cvs.DrawPoint(xr, yr, new SKColor(color.Red, color.Green, color.Blue, alpha));
                            }
                            else
                            {
                                // 绘制点
                                cvs.DrawPoint(xr, yr, color);
                            }
                            #endregion
                        }
                    }
                }
            }
        }
    }
}
