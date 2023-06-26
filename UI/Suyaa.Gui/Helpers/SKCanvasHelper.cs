using Forms;
using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using Point = Suyaa.Gui.Drawing.Point;
using Rectangle = Suyaa.Gui.Drawing.Rectangle;

namespace Suyaa.Gui.Helpers
{
    /// <summary>
    /// SKCanvas助手
    /// </summary>
    public static class SKCanvasHelper
    {

        // 计算两点之间的距离
        private static float Distance(float ox, float oy, float px, float py)
        {
            var distSquare = Square(px - ox) + Square(py - oy);
            return (float)Math.Sqrt(distSquare);
        }

        // 计算坐标的弧度
        private static float Angle(float ox, float oy, float px, float py)
        {
            var angle = Math.Atan2(py - oy, px - ox);
            return (float)(angle * (180 / Math.PI));
        }

        // 计算坐标的弧度
        private static float Angle(Point op, Point p)
        {
            return Angle(op.X, op.Y, p.X, p.Y);
        }

        // 获取长度比例上的透明度值
        private static byte GetDistAlpha(byte alpha, float dist, float distFull)
        {
            // 获取比例
            float scale = 1 - dist / distFull;
            // 计算透明度
            return (byte)(scale * scale * scale * alpha);
        }

        // 计算平方数
        private static float Square(float value)
        {
            if (value == 0) return 0;
            return value * value;
        }

        // 计算平方数
        private static int Square(int value)
        {
            if (value == 0) return 0;
            return value * value;
        }

        // 根据圆心，半径与当前位置，计算点与圆离开的实际距离的平方(在圆内均为0)
        private static float DistanceSquare(float ox, float oy, float px, float py, float radiusSquare)
        {
            var distSquare = Square(px - ox) + Square(py - oy);
            if (distSquare > radiusSquare) return Square((float)Math.Sqrt(distSquare) - (float)Math.Sqrt(radiusSquare));
            return 0;
        }

        #region 绘制边框

        /*
         * 圆角边框算法：
         * 采用相邻两边取平均值缩小圆角，再平移圆心定位边框内圆角
         */


        /// <summary>
        /// 绘制边框像素
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="distInner"></param>
        /// <param name="radiusInner"></param>
        /// <param name="isAntialias"></param>
        public static void DrawBorderPoint(this SKCanvas cvs, float x, float y, float distInner, float radiusInner, float distOuter, float radiusOuter, SKColor color, bool isAntialias)
        {
            // 判断是否执行外圆角判断
            if (radiusOuter > 0)
            {
                if (isAntialias)
                {
                    // 超出圆角范围，则跳过
                    if (distOuter >= radiusOuter + 1) return;
                    // 兼容外抗锯齿
                    if (distOuter > radiusOuter)
                    {
                        // 计算透明度
                        var alphaScale = 1 - (distOuter - radiusOuter);
                        byte alpha = (byte)(alphaScale * color.Alpha);
                        // 绘制边框点
                        cvs.DrawPoint(x, y, new SKColor(color.Red, color.Green, color.Blue, alpha));
                        return;
                    }
                }
                else
                {
                    // 超出圆角范围，则跳过
                    if (distOuter > radiusOuter) return;
                }
            }
            // 判断是否执行内圆角判断
            if (radiusInner > 0)
            {
                if (isAntialias)
                {
                    // 判断是否在边框范围内
                    if (distInner <= radiusInner) return;
                    // 兼容内抗锯齿
                    if (distInner < radiusInner + 1)
                    {
                        // 计算透明度
                        var alphaScale = 1 - (radiusInner - distInner);
                        byte alpha = (byte)(alphaScale * color.Alpha);
                        // 绘制边框点
                        cvs.DrawPoint(x, y, new SKColor(color.Red, color.Green, color.Blue, alpha));
                        return;
                    }
                }
                else
                {
                    // 超出圆角范围，则跳过
                    if (distInner < radiusInner) return;
                }
            }
            // 绘制边框点
            cvs.DrawPoint(x, y, color);
        }

        /// <summary>
        /// 绘制左上边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderLeftTopStyles(this SKCanvas cvs, Drawing.StyleCollection styles, Rectangle rect, int[] borders, int[] radiuses, RectangleDashed[] dasheds)
        {
            // 没有边框尺寸，则退出
            float sizeX = borders[3];
            float sizeY = borders[0];
            if (sizeX <= 0 && sizeY <= 0) return;
            // 获取抗锯齿设定
            bool isAntialias = styles.Get(Enums.Styles.Antialias, false);
            // 获取颜色
            SKColor colorX = styles.Get(Enums.Styles.BorderLeftColor, new SKColor());
            SKColor colorY = styles.Get(Enums.Styles.BorderTopColor, new SKColor());
            // 获取外圆角半径及圆心坐标
            float radiusOuter = radiuses[0];
            Point opOuter = new Point(rect.Left + radiusOuter, rect.Top + radiusOuter);
            float radiusUnit = (float)((Math.PI * radiusOuter) / 180);
            // 获取内圆角半径及圆心坐标
            float sizeHalf = (sizeX + sizeY) / 2;
            float radiusInner = radiusOuter - sizeHalf;
            if (radiusInner < 0)
            {
                radiusInner = 0;
                sizeHalf = 0;
            }
            Point opInner = new Point(opOuter.X + sizeX - sizeHalf, opOuter.Y + sizeY - sizeHalf);
            // 定义分割线段的标准坐标
            Point opSandardFrom = new Point(0, 0);
            Point opSandardTo = new Point(opInner.X, opInner.Y);
            // 计算处理区域
            int width = (int)(radiusOuter + sizeX);
            int height = (int)(radiusOuter + sizeY);
            // 遍历区域中的像素
            for (int yr = 0; yr < height; yr++)
            {
                for (int xr = 0; xr < width; xr++)
                {
                    // 转化为实际坐标
                    Point p = new Point(rect.Left + xr, rect.Top + yr);
                    // 判断相对位置
                    var relative = p.RelativeToLine(opSandardFrom, opSandardTo);
                    var color = relative > 0 ? colorX : colorY;
                    bool inOuter = p.X <= opOuter.X && p.Y < opOuter.Y;
                    bool inInner = p.X <= opInner.X && p.Y < opInner.Y;

                    #region 兼容虚线
                    // 在外圆中
                    if (inOuter)
                    {
                        if (relative > 0)
                        {
                            // 1/2
                            var dashed = dasheds[11];
                            if (dashed.Space > 0)
                            {
                                // 计算角度
                                var angle = Angle(opOuter, p) + 180;
                                // 计算位移
                                var offset = (int)dashed.GetOffset(angle * radiusUnit);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                        else
                        {
                            // 2/2
                            var dashed = dasheds[0];
                            if (dashed.Space > 0)
                            {
                                // 计算角度
                                var angle = Angle(opOuter, p) + 180 - 45;
                                // 计算位移
                                var offset = (int)dashed.GetOffset(angle * radiusUnit);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }

                        }
                    }
                    else
                    {
                        // 兼容虚线
                        if (relative > 0)
                        {
                            // 1/2
                            var dashed = dasheds[10];
                            if (dashed.Space > 0)
                            {
                                // 转为内边距
                                float adjust = rect.Bottom - radiuses[3] - 1;
                                // 计算位移
                                var offset = (int)dashed.GetOffset(adjust - p.Y);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                        else
                        {
                            // 2/2
                            var dashed = dasheds[1];
                            if (dashed.Space > 0)
                            {
                                // 计算校准长度
                                float adjust = rect.Left + radiuses[0];
                                // 计算位移
                                var offset = (int)dashed.GetOffset(p.X - adjust);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                    }
                    #endregion

                    // 判断是否在圆角扇形辐射范围
                    if (inInner && inOuter)
                    {
                        #region 即在内圆，又在外圆范围
                        // 计算当前像素到圆角圆心的距离
                        var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                        #endregion
                    }
                    else if (!inInner && inOuter)
                    {
                        if (p.X < opOuter.X)
                        {
                            #region 不在内圆，但在外圆范围，且横向在内圆控制范围内
                            // 计算当前像素到圆角圆心的距离
                            var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                            // 计算距离内圆角圆心距离
                            var distInner = Distance(opInner.X, p.Y, p.X, p.Y);
                            // 绘制边框像素点
                            cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                            #endregion
                        }
                        if (p.Y < opInner.Y)
                        {
                            #region 不在内外圆范围，但纵向在内圆控制范围内
                            // 计算当前像素到圆角圆心的距离
                            var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                            // 计算距离内圆角圆心距离
                            var distInner = Distance(p.X, opInner.Y, p.X, p.Y);
                            // 绘制边框像素点
                            cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                            #endregion
                        }
                    }
                    else if (!inOuter && inInner)
                    {
                        #region 不在外圆，但在内圆范围
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                    else if (p.Y < opInner.Y)
                    {
                        #region 不在内外圆范围，但纵向在内圆控制范围内
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(p.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                    else if (p.X < opOuter.X)
                    {
                        #region 不在内外圆范围，但横向在内圆控制范围内
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, p.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                }
            }
        }

        /// <summary>
        /// 绘制右上边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderRightTopStyles(this SKCanvas cvs, Drawing.StyleCollection styles, Rectangle rect, int[] borders, int[] radiuses, RectangleDashed[] dasheds)
        {
            // 没有边框尺寸，则退出
            float sizeX = borders[1];
            float sizeY = borders[0];
            if (sizeX <= 0 && sizeY <= 0) return;
            // 获取抗锯齿设定
            bool isAntialias = styles.Get(Enums.Styles.Antialias, false);
            // 获取颜色
            SKColor colorX = styles.Get(Enums.Styles.BorderRightColor, new SKColor());
            SKColor colorY = styles.Get(Enums.Styles.BorderTopColor, new SKColor());
            // 获取外圆角半径及圆心坐标
            float radiusOuter = radiuses[1];
            Point opOuter = new Point(rect.Right - radiusOuter - 1, rect.Top + radiusOuter);
            float radiusUnit = (float)((Math.PI * radiusOuter) / 180);
            // 获取内圆角半径及圆心坐标
            float sizeHalf = (sizeX + sizeY) / 2;
            float radiusInner = radiusOuter - sizeHalf;
            if (radiusInner < 0) radiusInner = 0;
            Point opInner = new Point(opOuter.X - sizeX + sizeHalf, opOuter.Y + sizeY - sizeHalf);
            // 计算处理区域
            int width = (int)(radiusOuter + sizeX);
            int height = (int)(radiusOuter + sizeY);
            // 定义分割线段的标准坐标
            Point opSandardFrom = new Point(rect.Right, 0);
            Point opSandardTo = new Point(opInner.X, opInner.Y);
            //// 绘制占位
            //using (SKPaint paint = new SKPaint()
            //{
            //    Color = new SKColor(0, 0, 0, 33),
            //    Style = SKPaintStyle.Fill,
            //})
            //{
            //    cvs.DrawCircle(opOuter.X, opOuter.Y, radiusOuter, paint);
            //    cvs.DrawCircle(opInner.X, opInner.Y, radiusInner, paint);
            //    cvs.DrawRect(new SKRect(opOuter.X, rect.Top, opOuter.X + 1, rect.Bottom), paint);
            //    cvs.DrawRect(new SKRect(rect.Left, opOuter.Y, rect.Right, opOuter.Y + 1), paint);
            //    cvs.DrawRect(new SKRect(opInner.X, rect.Top, opInner.X + 1, rect.Bottom), paint);
            //    cvs.DrawRect(new SKRect(rect.Left, opInner.Y, rect.Right, opInner.Y + 1), paint);
            //}
            // 遍历区域中的像素
            for (int yr = 0; yr < height; yr++)
            {
                for (int xr = 0; xr < width; xr++)
                {
                    // 转化为实际坐标
                    Point p = new Point(rect.Right - width + xr, rect.Top + yr);
                    // 判断相对位置
                    var relative = p.RelativeToLine(opSandardFrom, opSandardTo);
                    var color = relative > 0 ? colorY : colorX;
                    bool inOuter = p.X > opOuter.X && p.Y <= opOuter.Y;
                    bool inInner = p.X > opInner.X && p.Y <= opInner.Y;

                    #region 兼容虚线
                    // 在外圆中
                    if (inOuter)
                    {
                        if (relative > 0)
                        {
                            // 1/2
                            var dashed = dasheds[2];
                            if (dashed.Space > 0)
                            {
                                // 计算角度
                                var angle = Angle(opOuter, p) + 90;
                                // 计算位移
                                var offset = (int)dashed.GetOffset(angle * radiusUnit);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                        else
                        {
                            // 2/2
                            var dashed = dasheds[3];
                            if (dashed.Space > 0)
                            {
                                // 计算角度
                                var angle = Angle(opOuter, p) + 45;
                                // 计算位移
                                var offset = (int)dashed.GetOffset(angle * radiusUnit);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                    }
                    else
                    {
                        // 兼容虚线
                        if (relative > 0)
                        {
                            // 1/2
                            var dashed = dasheds[1];
                            if (dashed.Space > 0)
                            {
                                // 计算校准长度
                                float adjust = rect.Left + radiuses[0];
                                // 计算位移
                                var offset = (int)dashed.GetOffset(p.X - adjust);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                        else
                        {
                            // 2 / 2
                            var dashed = dasheds[4];
                            if (dashed.Space > 0)
                            {
                                // 转为内边距
                                float adjust = rect.Top + radiuses[1];
                                // 计算位移
                                var offset = (int)dashed.GetOffset(p.Y - adjust);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                    }
                    #endregion

                    // 判断是否在圆角扇形辐射范围
                    if (inInner && inOuter)
                    {
                        #region 即在内圆，又在外圆范围
                        // 计算当前像素到圆角圆心的距离
                        var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                        #endregion
                    }
                    else if (!inInner && inOuter)
                    {
                        if (p.X > opOuter.X)
                        {
                            #region 不在内圆，但在外圆范围，且横向在内圆控制范围内
                            // 计算当前像素到圆角圆心的距离
                            var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                            // 计算距离内圆角圆心距离
                            var distInner = Distance(opInner.X, p.Y, p.X, p.Y);
                            // 绘制边框像素点
                            cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                            #endregion
                        }
                        if (p.Y < opInner.Y)
                        {
                            #region 不在内外圆范围，但纵向在内圆控制范围内
                            // 计算当前像素到圆角圆心的距离
                            var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                            // 计算距离内圆角圆心距离
                            var distInner = Distance(p.X, opInner.Y, p.X, p.Y);
                            // 绘制边框像素点
                            cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                            #endregion
                        }
                    }
                    else if (!inOuter && inInner)
                    {
                        #region 不在外圆，但在内圆范围
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                    else if (p.Y < opInner.Y)
                    {
                        #region 不在内外圆范围，但纵向在内圆控制范围内
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(p.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                    else if (p.X > opOuter.X)
                    {
                        #region 不在内外圆范围，但横向在内圆控制范围内
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, p.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                }
            }
        }

        /// <summary>
        /// 绘制右下边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderRightBottomStyles(this SKCanvas cvs, Drawing.StyleCollection styles, Rectangle rect, int[] borders, int[] radiuses, RectangleDashed[] dasheds)
        {
            // 没有边框尺寸，则退出
            float sizeX = borders[1];
            float sizeY = borders[2];
            if (sizeX <= 0 && sizeY <= 0) return;
            // 获取抗锯齿设定
            bool isAntialias = styles.Get(Enums.Styles.Antialias, false);
            // 获取颜色
            SKColor colorX = styles.Get(Enums.Styles.BorderRightColor, new SKColor());
            SKColor colorY = styles.Get(Enums.Styles.BorderBottomColor, new SKColor());
            // 获取外圆角半径及圆心坐标
            float radiusOuter = radiuses[2];
            Point opOuter = new Point(rect.Right - radiusOuter - 1, rect.Bottom - radiusOuter - 1);
            float radiusUnit = (float)((Math.PI * radiusOuter) / 180);
            // 获取内圆角半径及圆心坐标
            float sizeHalf = (sizeX + sizeY) / 2;
            float radiusInner = radiusOuter - sizeHalf;
            if (radiusInner < 0) radiusInner = 0;
            Point opInner = new Point(opOuter.X - sizeX + sizeHalf, opOuter.Y - sizeY + sizeHalf);
            // 计算处理区域
            int width = (int)(radiusOuter + sizeX);
            int height = (int)(radiusOuter + sizeY);
            // 定义分割线段的标准坐标
            Point opSandardFrom = new Point(rect.Right, rect.Bottom);
            Point opSandardTo = new Point(opInner.X, opInner.Y);
            //// 绘制占位
            //using (SKPaint paint = new SKPaint()
            //{
            //    Color = new SKColor(0, 0, 0, 33),
            //    Style = SKPaintStyle.Fill,
            //})
            //{
            //    cvs.DrawCircle(opOuter.X, opOuter.Y, radiusOuter, paint);
            //    cvs.DrawCircle(opInner.X, opInner.Y, radiusInner, paint);
            //    cvs.DrawRect(new SKRect(opOuter.X, rect.Top, opOuter.X + 1, rect.Bottom), paint);
            //    cvs.DrawRect(new SKRect(rect.Left, opOuter.Y, rect.Right, opOuter.Y + 1), paint);
            //    cvs.DrawRect(new SKRect(opInner.X, rect.Top, opInner.X + 1, rect.Bottom), paint);
            //    cvs.DrawRect(new SKRect(rect.Left, opInner.Y, rect.Right, opInner.Y + 1), paint);
            //}
            // 遍历区域中的像素
            for (int yr = 0; yr < height; yr++)
            {
                for (int xr = 0; xr < width; xr++)
                {
                    // 转化为实际坐标
                    Point p = new Point(rect.Right - width + xr, rect.Bottom - height + yr);
                    // 绘制占位
                    //cvs.DrawPoint(p.X, p.Y, new SKColor(0, 0, 0, 33));
                    var relative = p.RelativeToLine(opSandardFrom, opSandardTo);
                    var color = relative > 0 ? colorX : colorY;
                    bool inOuter = p.X > opOuter.X && p.Y > opOuter.Y;
                    bool inInner = p.X > opInner.X && p.Y > opInner.Y;

                    #region 兼容虚线
                    // 在外圆中
                    if (inOuter)
                    {
                        if (relative > 0)
                        {
                            // 1/2
                            var dashed = dasheds[5];
                            if (dashed.Space > 0)
                            {
                                // 计算角度
                                var angle = Angle(opOuter, p);
                                // 计算位移
                                var offset = (int)dashed.GetOffset(angle * radiusUnit);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                        else
                        {
                            // 2/2
                            var dashed = dasheds[6];
                            if (dashed.Space > 0)
                            {
                                // 计算角度
                                var angle = Angle(opOuter, p) - 45;
                                // 计算位移
                                var offset = (int)dashed.GetOffset(angle * radiusUnit);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                    }
                    else
                    {
                        // 兼容虚线
                        if (relative > 0)
                        {
                            // 1/2
                            var dashed = dasheds[4];
                            if (dashed.Space > 0)
                            {
                                // 计算校准长度
                                float adjust = rect.Top + radiuses[1];
                                // 计算位移
                                var offset = (int)dashed.GetOffset(p.Y - adjust);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                        else
                        {
                            // 2/2
                            var dashed = dasheds[7];
                            if (dashed.Space > 0)
                            {
                                // 计算校准长度
                                float adjust = rect.Right - radiuses[2] - 1;
                                // 计算位移
                                var offset = (int)dashed.GetOffset(adjust - p.X);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                    }
                    #endregion

                    // 判断是否在圆角扇形辐射范围
                    if (inInner && inOuter)
                    {
                        #region 即在内圆，又在外圆范围
                        // 计算当前像素到圆角圆心的距离
                        var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                        #endregion
                    }
                    else if (!inInner && inOuter)
                    {
                        if (p.X > opOuter.X)
                        {
                            #region 不在内圆，但在外圆范围，且横向在内圆控制范围内
                            // 计算当前像素到圆角圆心的距离
                            var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                            // 计算距离内圆角圆心距离
                            var distInner = Distance(opInner.X, p.Y, p.X, p.Y);
                            // 绘制边框像素点
                            cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                            #endregion
                        }
                        if (p.Y > opInner.Y)
                        {
                            #region 不在内外圆范围，但纵向在内圆控制范围内
                            // 计算当前像素到圆角圆心的距离
                            var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                            // 计算距离内圆角圆心距离
                            var distInner = Distance(p.X, opInner.Y, p.X, p.Y);
                            // 绘制边框像素点
                            cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                            #endregion
                        }
                    }
                    else if (!inOuter && inInner)
                    {
                        #region 不在外圆，但在内圆范围
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                    else if (p.Y > opInner.Y)
                    {
                        #region 不在内外圆范围，但纵向在内圆控制范围内
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(p.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                    else if (p.X > opOuter.X)
                    {
                        #region 不在内外圆范围，但横向在内圆控制范围内
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, p.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                    else
                    {
                        // 绘制占位
                        //cvs.DrawPoint(p.X, p.Y, new SKColor(0, 0, 0, 33));
                    }
                }
            }
        }

        /// <summary>
        /// 绘制左下边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderLeftBottomStyles(this SKCanvas cvs, Drawing.StyleCollection styles, Rectangle rect, int[] borders, int[] radiuses, RectangleDashed[] dasheds)
        {
            // 没有边框尺寸，则退出
            float sizeX = borders[3];
            float sizeY = borders[2];
            if (sizeX <= 0 && sizeY <= 0) return;
            // 获取抗锯齿设定
            bool isAntialias = styles.Get(Enums.Styles.Antialias, false);
            // 获取颜色
            SKColor colorX = styles.Get(Enums.Styles.BorderLeftColor, new SKColor());
            SKColor colorY = styles.Get(Enums.Styles.BorderBottomColor, new SKColor());
            // 获取外圆角半径及圆心坐标
            float radiusOuter = radiuses[3];
            Point opOuter = new Point(rect.Left + radiusOuter, rect.Bottom - radiusOuter - 1);
            float radiusUnit = (float)((Math.PI * radiusOuter) / 180);
            // 获取内圆角半径及圆心坐标
            float sizeHalf = (sizeX + sizeY) / 2;
            float radiusInner = radiusOuter - sizeHalf;
            if (radiusInner < 0) radiusInner = 0;
            Point opInner = new Point(opOuter.X + sizeX - sizeHalf, opOuter.Y - sizeY + sizeHalf);
            // 计算处理区域
            int width = (int)(radiusOuter + sizeX);
            int height = (int)(radiusOuter + sizeY);
            // 定义分割线段的标准坐标
            Point opSandardFrom = new Point(rect.Left, rect.Bottom);
            Point opSandardTo = new Point(opInner.X, opInner.Y);
            //// 绘制占位
            //using (SKPaint paint = new SKPaint()
            //{
            //    Color = new SKColor(0, 0, 0, 33),
            //    Style = SKPaintStyle.Fill,
            //})
            //{
            //    cvs.DrawCircle(opOuter.X, opOuter.Y, radiusOuter, paint);
            //    cvs.DrawCircle(opInner.X, opInner.Y, radiusInner, paint);
            //    cvs.DrawRect(new SKRect(rect.Left, opOuter.Y, rect.Right, opOuter.Y + 1), paint);
            //    cvs.DrawRect(new SKRect(rect.Left, opInner.Y, rect.Right, opInner.Y + 1), paint);
            //}
            // 遍历区域中的像素
            for (int yr = 0; yr < height; yr++)
            {
                for (int xr = 0; xr < width; xr++)
                {
                    // 转化为实际坐标
                    Point p = new Point(rect.Left + xr, rect.Bottom - height + yr);
                    // 绘制占位
                    //cvs.DrawPoint(p.X, p.Y, new SKColor(0, 0, 0, 33));
                    var relative = p.RelativeToLine(opSandardFrom, opSandardTo);
                    var color = relative > 0 ? colorY : colorX;
                    bool inOuter = p.X < opOuter.X && p.Y >= opOuter.Y;
                    bool inInner = p.X < opInner.X && p.Y >= opInner.Y;

                    #region 兼容虚线
                    // 在外圆中
                    if (inOuter)
                    {
                        if (relative > 0)
                        {
                            // 1/2
                            var dashed = dasheds[8];
                            if (dashed.Space > 0)
                            {
                                // 计算角度
                                var angle = Angle(opOuter, p) - 90;
                                // 计算位移
                                var offset = (int)dashed.GetOffset(angle * radiusUnit);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                        else
                        {
                            // 2/2
                            var dashed = dasheds[9];
                            if (dashed.Space > 0)
                            {
                                // 计算角度
                                var angle = Angle(opOuter, p) - 135;
                                // 计算位移
                                var offset = (int)dashed.GetOffset(angle * radiusUnit);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                    }
                    else
                    {
                        // 兼容虚线
                        if (relative > 0)
                        {
                            // 1/2
                            var dashed = dasheds[7];
                            if (dashed.Space > 0)
                            {
                                // 计算校准长度
                                float adjust = rect.Right - radiuses[2] - 1;
                                // 计算位移
                                var offset = dashed.GetOffset(adjust - p.X);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                        else
                        {
                            // 2 / 2
                            var dashed = dasheds[10];
                            if (dashed.Space > 0)
                            {
                                // 转为内边距
                                float adjust = rect.Bottom - radiuses[3] - 1;
                                // 计算位移
                                var offset = dashed.GetOffset(adjust - p.Y);
                                // 判断是否显示
                                if (offset >= 0) continue;
                            }
                        }
                    }
                    #endregion

                    // 判断是否在圆角扇形辐射范围
                    if (inInner && inOuter)
                    {
                        #region 即在内圆，又在外圆范围
                        // 计算当前像素到圆角圆心的距离
                        var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                        #endregion
                    }
                    else if (!inInner && inOuter)
                    {
                        if (p.X < opOuter.X)
                        {
                            #region 不在内圆，但在外圆范围，且横向在内圆控制范围内
                            // 计算当前像素到圆角圆心的距离
                            var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                            // 计算距离内圆角圆心距离
                            var distInner = Distance(opInner.X, p.Y, p.X, p.Y);
                            // 绘制边框像素点
                            cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                            #endregion
                        }
                        if (p.Y > opInner.Y)
                        {
                            #region 不在内外圆范围，但纵向在内圆控制范围内
                            // 计算当前像素到圆角圆心的距离
                            var distOuter = Distance(opOuter.X, opOuter.Y, p.X, p.Y);
                            // 计算距离内圆角圆心距离
                            var distInner = Distance(p.X, opInner.Y, p.X, p.Y);
                            // 绘制边框像素点
                            cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, distOuter, radiusOuter, color, isAntialias);
                            #endregion
                        }
                    }
                    else if (!inOuter && inInner)
                    {
                        #region 不在外圆，但在内圆范围
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                    else if (p.Y > opInner.Y)
                    {
                        #region 不在内外圆范围，但纵向在内圆控制范围内
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(p.X, opInner.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                    else if (p.X < opOuter.X)
                    {
                        #region 不在内外圆范围，但横向在内圆控制范围内
                        // 计算距离内圆角圆心距离
                        var distInner = Distance(opInner.X, p.Y, p.X, p.Y);
                        // 绘制边框像素点
                        cvs.DrawBorderPoint(p.X, p.Y, distInner, radiusInner, 0, 0, color, isAntialias);
                        #endregion
                    }
                    else
                    {
                        // 绘制占位
                        //cvs.DrawPoint(p.X, p.Y, new SKColor(0, 0, 0, 33));
                    }
                }
            }
        }

        /// <summary>
        /// 绘制上边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderTopStyles(this SKCanvas cvs, Drawing.StyleCollection styles, Rectangle rect, int[] borders, int[] radiuses, RectangleDashed[] dasheds, SKPaint? paint)
        {
            if (paint is null) return;
            if (borders[0] <= 0) return;
            // 转为内边距
            float left = rect.Left + radiuses[0] + borders[3];
            float top = rect.Top;
            float right = rect.Right - radiuses[1] - borders[1];
            float bottom = rect.Top + borders[0];
            // 分开处理实线和虚线
            var dashed = dasheds[1];
            if (dashed.Space > 0)
            {
                //float start = dashed.Start + borders[3];
                // 计算绘制偏移和绘制长度
                var offset = (int)dashed.GetOffset(borders[3]);
                for (float adjust = left; adjust < right + dashed.Length; adjust += dashed.Length)
                {
                    float x1 = adjust + offset;
                    float x2 = x1 + dashed.Solid;
                    if (x1 >= right) continue;
                    if (x1 < left) x1 = left;
                    if (x2 > right) x2 = right;
                    cvs.DrawRect(new SKRect(x1, top, x2, bottom), paint);
                    // 输出调试信息
                    Debug.WriteLine($"[DrawBorderTop] {x1}, {top}, {x2}, {bottom}");
                }
            }
            else
            {
                cvs.DrawRect(new SKRect(left, top, right, bottom), paint);
            }
        }

        /// <summary>
        /// 绘制右边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderRightStyles(this SKCanvas cvs, Drawing.StyleCollection styles, Rectangle rect, int[] borders, int[] radiuses, RectangleDashed[] dasheds, SKPaint? paint)
        {
            if (paint is null) return;
            if (borders[1] <= 0) return;
            // 转为内边距
            float left = rect.Right - borders[1];
            float top = rect.Top + radiuses[1] + borders[0];
            float right = rect.Right;
            float bottom = rect.Bottom - radiuses[2] - borders[2];
            // 分开处理实线和虚线
            var dashed = dasheds[4];
            if (dashed.Space > 0)
            {
                //float start = dashed.Start + borders[0];
                // 计算绘制偏移和绘制长度
                var offset = (int)dashed.GetOffset(borders[0]);
                for (float adjust = top; adjust < bottom + dashed.Length; adjust += dashed.Length)
                {
                    // 计算绘制偏移和绘制长度
                    float y1 = adjust + offset;
                    float y2 = y1 + dashed.Solid;
                    if (y1 >= bottom) continue;
                    if (y1 < top) y1 = top;
                    if (y2 > bottom) y2 = bottom;
                    cvs.DrawRect(new SKRect(left, y1, right, y2), paint);
                    // 输出调试信息
                    Debug.WriteLine($"[DrawBorderRight] {left}, {y1}, {right}, {y2}");
                }
            }
            else
            {
                cvs.DrawRect(new SKRect(left, top, right, bottom), paint);
            }
        }

        /// <summary>
        /// 绘制下边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderBottomStyles(this SKCanvas cvs, Drawing.StyleCollection styles, Rectangle rect, int[] borders, int[] radiuses, RectangleDashed[] dasheds, SKPaint? paint)
        {
            if (paint is null) return;
            // 转为内边距
            //float size = styles.Get<float>(StyleType.BorderBottomSize, 0) * scale;
            //float radiusLeftBottom = styles.Get<float>(StyleType.BorderRadiusLeftBottom, 0) * scale;
            //float radiusRightBottom = styles.Get<float>(StyleType.BorderRadiusRightBottom, 0) * scale;
            float left = rect.Left + radiuses[3] + borders[3];
            float top = rect.Bottom - borders[2];
            float right = rect.Right - radiuses[2] - borders[1];
            float bottom = rect.Bottom;
            // 分开处理实线和虚线
            var dashed = dasheds[7];
            if (dashed.Space > 0)
            {
                //float start = dashed.Start + borders[0];
                // 计算绘制偏移和绘制长度
                var offset = (int)dashed.GetOffset(borders[1]);
                for (float adjust = right; adjust > left - dashed.Length; adjust -= dashed.Length)
                {
                    // 计算绘制偏移和绘制长度
                    float x1 = adjust - offset;
                    float x2 = x1 - dashed.Solid;
                    if (x1 <= left) continue;
                    if (x1 > right) x1 = right;
                    if (x2 < left) x2 = left;
                    cvs.DrawRect(new SKRect(x1, top, x2, bottom), paint);
                    // 输出调试信息
                    Debug.WriteLine($"[DrawBorderBottom] {x1}, {top}, {x2}, {bottom}");
                }
            }
            else
            {
                cvs.DrawRect(new SKRect(left, top, right, bottom), paint);
            }
        }

        /// <summary>
        /// 绘制左边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderLeftStyles(this SKCanvas cvs, Drawing.StyleCollection styles, Rectangle rect, int[] borders, int[] radiuses, RectangleDashed[] dasheds, SKPaint? paint)
        {
            if (paint is null) return;
            if (borders[3] <= 0) return;
            // 转为内边距
            float left = rect.Left;
            float top = rect.Top + radiuses[0] + borders[0];
            float right = rect.Left + borders[3];
            float bottom = rect.Bottom - radiuses[3] - borders[2];
            // 分开处理实线和虚线
            var dashed = dasheds[10];
            if (dashed.Space > 0)
            {
                //float start = dashed.Start + borders[0];
                // 计算绘制偏移和绘制长度
                var offset = (int)dashed.GetOffset(borders[2]);
                for (float adjust = bottom; adjust > top - dashed.Length; adjust -= dashed.Length)
                {
                    // 计算绘制偏移和绘制长度
                    float y1 = adjust - offset;
                    float y2 = y1 - dashed.Solid;
                    if (y1 <= top) continue;
                    if (y1 > bottom) y1 = bottom;
                    if (y2 < top) y2 = top;
                    cvs.DrawRect(new SKRect(left, y1, right, y2), paint);
                    // 输出调试信息
                    Debug.WriteLine($"[DrawBorderRight] {left}, {y1}, {right}, {y2}");
                }
            }
            else
            {
                cvs.DrawRect(new SKRect(left, top, right, bottom), paint);
            }
        }

        /// <summary>
        /// 绘制右边框样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBorderStyles(this SKCanvas cvs, Drawing.StyleCollection styles, Rectangle rect, float scale)
        {
            // 获取圆角值
            int[] radiuses = new int[] {
                (int)(styles.Get<float>(Enums.Styles.BorderRadiusLeftTop, 0) * scale ),
                (int)(styles.Get<float>(Enums.Styles.BorderRadiusRightTop, 0) * scale ),
                (int)(styles.Get<float>(Enums.Styles.BorderRadiusRightBottom, 0) * scale ),
                (int)(styles.Get<float>(Enums.Styles.BorderRadiusLeftBottom, 0) * scale),
            };
            // 获取边框尺寸值
            int[] borders = new int[] {
                (int)(styles.Get<float>(Enums.Styles.BorderTopSize, 0) * scale ),
                (int)(styles.Get<float>(Enums.Styles.BorderRightSize, 0) * scale ),
                (int)(styles.Get<float>(Enums.Styles.BorderBottomSize, 0) * scale ),
                (int)(styles.Get<float>(Enums.Styles.BorderLeftSize, 0) * scale),
            };
            // 获取虚线描述
            var dasheds = styles.GetDasheds(rect, radiuses);
#if DEBUG
            for (int i = 0; i < dasheds.Length; i++)
            {
                var dashed = dasheds[i];
                if (dashed.Space <= 0) continue;
                Debug.WriteLine($"[Dashed][{i}] s:{dashed.Start} d:{dashed.Distance} e:{dashed.End} so:{dashed.Solid} sp:{dashed.Space} sl:{dashed.Length} of:{dashed.Offset} on:{dashed.GetOffset(dashed.Distance)}");
            }
#endif
            // 建立画笔
            using (var paintTop = styles.GetFillPaint(Enums.Styles.BorderTopColor))
            using (var paintRight = styles.GetFillPaint(Enums.Styles.BorderRightColor))
            using (var paintBottom = styles.GetFillPaint(Enums.Styles.BorderBottomColor))
            using (var paintLeft = styles.GetFillPaint(Enums.Styles.BorderLeftColor))
            using (var bmp = new SKBitmap((int)rect.Width, (int)rect.Height))
            using (var bmpCvs = new SKCanvas(bmp))
            {
                var bmpRect = new Rectangle(0, 0, rect.Width, rect.Height);
                // 输出左上角
                bmpCvs.DrawBorderLeftTopStyles(styles, bmpRect, borders, radiuses, dasheds);
                // 输出上边框
                bmpCvs.DrawBorderTopStyles(styles, bmpRect, borders, radiuses, dasheds, paintTop);
                // 输出右上角
                bmpCvs.DrawBorderRightTopStyles(styles, bmpRect, borders, radiuses, dasheds);
                // 输出右边框
                bmpCvs.DrawBorderRightStyles(styles, bmpRect, borders, radiuses, dasheds, paintRight);
                // 输出右下角
                bmpCvs.DrawBorderRightBottomStyles(styles, bmpRect, borders, radiuses, dasheds);
                // 输出下边框
                bmpCvs.DrawBorderBottomStyles(styles, bmpRect, borders, radiuses, dasheds, paintBottom);
                // 输出左下角
                bmpCvs.DrawBorderLeftBottomStyles(styles, bmpRect, borders, radiuses, dasheds);
                // 输出左边框
                bmpCvs.DrawBorderLeftStyles(styles, bmpRect, borders, radiuses, dasheds, paintLeft);
                // 输出图像
                cvs.DrawBitmap(bmp, rect.Left, rect.Top);
            }
        }

        #endregion

        #region 绘制光标

        /// <summary>
        /// 绘制背景
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawBackgroundStyles(this SKCanvas cvs, Drawing.StyleCollection styles, Rectangle rect, float scale)
        {
            if (styles.ContainsKey(Enums.Styles.BackgroundColor))
            {
                // 获取圆角值
                float[] radiuses = new float[] {
                    styles.Get<float>(Enums.Styles.BorderRadiusLeftTop, 0) * scale,
                    styles.Get<float>(Enums.Styles.BorderRadiusRightTop, 0) * scale,
                    styles.Get<float>(Enums.Styles.BorderRadiusRightBottom, 0) * scale,
                    styles.Get<float>(Enums.Styles.BorderRadiusLeftBottom, 0) * scale,
                };
                using (SKPaint paint = new SKPaint()
                {
                    Color = styles.Get<SKColor>(Enums.Styles.BackgroundColor),
                    Style = SKPaintStyle.Fill,
                    //StrokeWidth = 10,
                    IsAntialias = styles.Get(Enums.Styles.Antialias, false),
                })
                {
                    // 左上+上
                    if (radiuses[0] > 0)
                    {
                        // 左上角
                        float radius = radiuses[0];
                        cvs.DrawArc(new SKRect(rect.Left, rect.Top, rect.Left + radius * 2, rect.Top + radius * 2), 180, 90, true, paint);
                        // 上边
                        cvs.DrawRect(new SKRect(rect.Left + radius, rect.Top, rect.Right - radiuses[1], rect.Top + radius), paint);
                    }
                    // 右上+右
                    if (radiuses[1] > 0)
                    {
                        // 右上角
                        float radius = radiuses[1];
                        cvs.DrawArc(new SKRect(rect.Right - radius * 2, rect.Top, rect.Right, rect.Top + radius * 2), 270, 90, true, paint);
                        // 右边
                        cvs.DrawRect(new SKRect(rect.Right - radius, rect.Top + radius, rect.Right, rect.Bottom - radiuses[2]), paint);
                    }
                    // 右下+下
                    if (radiuses[2] > 0)
                    {
                        float radius = radiuses[2];
                        cvs.DrawArc(new SKRect(rect.Right - radius * 2, rect.Bottom - radius * 2, rect.Right, rect.Bottom), 0, 90, true, paint);
                        // 右边
                        cvs.DrawRect(new SKRect(rect.Left + radiuses[3], rect.Bottom - radius, rect.Right - radius, rect.Bottom), paint);
                    }
                    // 左下+左
                    if (radiuses[3] > 0)
                    {
                        float radius = radiuses[3];
                        cvs.DrawArc(new SKRect(rect.Left, rect.Bottom - radius * 2, rect.Left + radius * 2, rect.Bottom), 90, 90, true, paint);
                        // 上边
                        cvs.DrawRect(new SKRect(rect.Left, rect.Top + radiuses[0], rect.Left + radius, rect.Bottom - radius), paint);
                    }
                    // 中间
                    cvs.DrawRect(new SKRect(rect.Left + radiuses[3], rect.Top + radiuses[0], rect.Right - radiuses[1], rect.Bottom - radiuses[2]), paint);
                }
            }
        }

        #endregion

        #region 绘制阴影

        /// <summary>
        /// 绘制阴影像素
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dist"></param>
        /// <param name="distFull"></param>
        public static void DrawShadowPoint(this SKCanvas cvs, SKColor color, int x, int y, float dist, float distFull)
        {
            // 在圆角外和半径范围内则输出羽化阴影
            if (dist <= 0)
            {
                // 输出原阴影色
                cvs.DrawPoint(x, y, color);
                return;
            }
            if (dist <= distFull)
            {
                // 计算当前坐标的透明度
                byte alpha = GetDistAlpha(color.Alpha, dist, distFull);
                // 绘制点
                cvs.DrawPoint(x, y, new SKColor(color.Red, color.Green, color.Blue, alpha));
            }
        }

        /// <summary>
        /// 绘制阴影样式
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        public static void DrawShadowStyles(this SKCanvas cvs, Drawing.StyleCollection styles, Rectangle rect, float scale)
        {
            // 获取配置
            if (!styles.ContainsKey(Enums.Styles.BorderShadowColor)) return;
            int size = (int)(styles.Get(Enums.Styles.BorderShadowSize, 0) * scale);
            if (size <= 0) return;
            int offsetX = (int)(styles.Get<float>(Enums.Styles.BorderShadowX, 0) * scale);
            int offsetY = (int)(styles.Get<float>(Enums.Styles.BorderShadowY, 0) * scale);
            SKColor color = styles.Get<SKColor>(Enums.Styles.BorderShadowColor);
            //SKColor colorStyle = styles.Get<SKColor>(StyleType.BorderShadowColor);
            //SKColor color = new SKColor(colorStyle.Red, colorStyle.Green, colorStyle.Blue, 255);
            // 逐行处理像素
            //int size2 = (int)(size * 1.2);
            int size2 = (int)(size);
            // 获取圆角值
            int[] radiuses = new int[] {
                (int)(styles.Get<float>(Enums.Styles.BorderRadiusLeftTop, 0) * scale ),
                (int)(styles.Get<float>(Enums.Styles.BorderRadiusRightTop, 0) * scale ),
                (int)(styles.Get<float>(Enums.Styles.BorderRadiusRightBottom, 0) * scale ),
                (int)(styles.Get<float>(Enums.Styles.BorderRadiusLeftBottom, 0) * scale),
            };
            int[] dists = new int[4];
            int[] radiusDists = new int[4];
            for (int i = 0; i < dists.Length; i++)
            {
                dists[i] = Square((int)size2);
                radiusDists[i] = Square(radiuses[i]);
            }
            int width = (int)(rect.Width + size * 2);
            int height = (int)(rect.Height + size * 2);
            // 偏移超过尺寸
            if (offsetX > size) width += offsetX - size;
            if (offsetX < -size) width += Math.Abs(offsetX + size);
            if (offsetY > size) height += offsetY - size;
            if (offsetY < -size) height += Math.Abs(offsetY + size);
            // 计算四个角的无偏移圆心
            Point[] ops = new Point[]
            {
                // 左上
                new Point(radiuses[0] + size2, radiuses[0] + size2),
                // 右上
                new Point(width - 1 - radiuses[1] - size2, radiuses[1] + size2),
                // 右下
                new Point(width - 1 - radiuses[2] - size2, height - 1 - radiuses[2] - size2),
                // 左下
                new Point(radiuses[3] + size2, height - 1 - radiuses[3] - size2),
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
                                var dist = DistanceSquare(op.X, op.Y, x, y, radiusDists[0]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[0]);
                            }
                            else if (x < op.X)
                            {
                                // 计算坐标到圆心的距离
                                var dist = DistanceSquare(op.X, y, x, y, radiusDists[0]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[0]);
                            }
                            else if (y < op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = DistanceSquare(x, op.Y, x, y, radiusDists[0]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[0]);
                            }
                            else
                            {
                                // 输出原阴影色
                                cvs.DrawPoint(x, y, color);
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
                                var dist = DistanceSquare(op.X, op.Y, x, y, radiusDists[3]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[3]);
                            }
                            else if (x < op.X)
                            {
                                // 计算坐标到圆心的距离
                                var dist = DistanceSquare(op.X, y, x, y, radiusDists[3]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[3]);
                            }
                            else if (y > op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = DistanceSquare(x, op.Y, x, y, radiusDists[3]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[3]);
                            }
                            else
                            {
                                // 输出原阴影色
                                cvs.DrawPoint(x, y, color);
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
                                var dist = DistanceSquare(op.X, op.Y, x, y, radiusDists[1]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[1]);
                            }
                            else if (x > op.X)
                            {
                                // 计算坐标到圆心的距离
                                var dist = DistanceSquare(op.X, y, x, y, radiusDists[1]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[1]);
                            }
                            else if (y < op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = DistanceSquare(x, op.Y, x, y, radiusDists[1]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[1]);
                            }
                            else
                            {
                                // 输出原阴影色
                                cvs.DrawPoint(x, y, color);
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
                                var dist = DistanceSquare(op.X, op.Y, x, y, radiusDists[2]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[2]);
                            }
                            else if (x > op.X)
                            {
                                // 计算坐标到圆心的距离
                                var dist = DistanceSquare(op.X, y, x, y, radiusDists[2]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[2]);
                            }
                            else if (y > op.Y)
                            {
                                // 计算坐标到圆心的距离
                                var dist = DistanceSquare(x, op.Y, x, y, radiusDists[2]);
                                // 绘制阴影点
                                cvs.DrawShadowPoint(color, xr, yr, dist, dists[2]);
                            }
                            else
                            {
                                // 输出原阴影色
                                cvs.DrawPoint(x, y, color);
                            }
                            #endregion
                        }
                    }
                }
            }
        }

        #endregion

        #region 绘制输入光标

        /// <summary>
        /// 绘制背景
        /// </summary>
        /// <param name="cvs"></param>
        /// <param name="styles"></param>
        /// <param name="rect"></param>
        public static void DrawInputCursor(this SKCanvas cvs, INativeForm form)
        {
            var ctl = form.CurrentControl;
            if (ctl is null) return;
            if (!ctl.IsEditable) return;
            if (ctl is not IWidgetTextContent textContent) return;
            if (!Application.GetInputCursorShow(form.Handle))
            {
                // 设置下一次为显示
                Application.SetInputCursorShow(form.Handle, true);
                return;
            }
            // 获取光标位置
            Point p = ctl.GetFormOffset();
            // 获取放大比例
            var scale = Application.GetScale();
            // 获取边框尺寸
            var borders = ctl.Style.GetBorders(scale);
            // 获取字体设置
            var fontNames = ctl.GetInheritableStyle(Styles.TextFont, string.Empty);
            // 获取字体高度
            using (SKPaint paint = new SKPaint(sy.Gui.GetFont(fontNames))
            {
                Color = ctl.GetInheritableStyle(Styles.TextColor, SKColors.Black),
                TextSize = ctl.GetInheritableStyle(Styles.TextSize, 9f) * scale,
                IsAntialias = ctl.GetInheritableStyle(Styles.Antialias, true),
                Style = SKPaintStyle.Fill,
            })
            {
                paint.GetFontMetrics(out SKFontMetrics metrics);
                var width = paint.MeasureText(textContent.GetContent(0, textContent.SelectionStart));
                var height = metrics.Bottom - metrics.Top - 2;
                var icRect = textContent.InputCursorRectangle;
                //var ctlHeight = ctl.Rectangle.Height - borders.Top - borders.Bottom - ctl.Padding.Top - ctl.Padding.Bottom;
                float left = p.X + icRect.Left;
                float top = p.Y + icRect.Top;
                cvs.DrawRect(new SKRect(left, top, left + icRect.Width, top + icRect.Height), paint);
            }
            // 设置下一次为不显示
            Application.SetInputCursorShow(form.Handle, false);
        }

        #endregion
    }
}
