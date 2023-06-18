using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Helpers
{
    /// <summary>
    /// 助手类
    /// </summary>
    public static class RectangleHelper
    {
        /// <summary>
        /// 判断矩形是否包含坐标
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Contain(this Rectangle rect, Point p)
        {
            return p.X >= rect.Left && p.X <= rect.Right && p.Y >= rect.Top && p.Y <= rect.Bottom;
        }

        /// <summary>
        /// 获取附加外边框后的矩形
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="margin"></param>
        /// <param name="isMove">是否</param>
        /// <returns></returns>
        public static Rectangle Margin(this Rectangle rect, Margin margin)
        {
            return new Rectangle(
                rect.Left - margin.Left,
                rect.Top - margin.Top,
                rect.Width + margin.Left + margin.Right,
                rect.Height + margin.Top + margin.Bottom
                );
        }

        /// <summary>
        /// 获取附加外边框后的矩形
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="margin"></param>
        /// <param name="isMove">是否</param>
        /// <returns></returns>
        public static Rectangle Margin(this Rectangle rect, Margin margin, AlignType xAlign, AlignType yAlign)
        {
            float width = rect.Width + margin.Left + margin.Right;
            float height = rect.Height + margin.Top + margin.Bottom;
            return xAlign switch
            {
                // 横向锚点为中
                AlignType.Center => yAlign switch
                {
                    // 纵向锚点为中
                    AlignType.Center => new Rectangle(rect.Left - margin.Left, rect.Top - margin.Top, width, height),
                    // 纵向锚点为下
                    AlignType.Opposite => new Rectangle(rect.Left - margin.Left, rect.Top - margin.Top - margin.Bottom, width, height),
                    // 纵向锚点为左
                    _ => new Rectangle(rect.Left - margin.Left, rect.Top, width, height)
                },
                // 横向锚点为右
                AlignType.Opposite => yAlign switch
                {
                    // 纵向锚点为中
                    AlignType.Center => new Rectangle(rect.Left - margin.Left - margin.Right, rect.Top - margin.Top, width, height),
                    // 纵向锚点为下
                    AlignType.Opposite => new Rectangle(rect.Left - margin.Left - margin.Right, rect.Top - margin.Top - margin.Bottom, width, height),
                    // 纵向锚点为左
                    _ => new Rectangle(rect.Left - margin.Left - margin.Right, rect.Top, width, height)
                },
                // 横向锚点为左
                _ => yAlign switch
                {
                    // 纵向锚点为中
                    AlignType.Center => new Rectangle(rect.Left, rect.Top - margin.Top, width, height),
                    // 纵向锚点为下
                    AlignType.Opposite => new Rectangle(rect.Left, rect.Top - margin.Top - margin.Bottom, width, height),
                    // 纵向锚点为左
                    _ => new Rectangle(rect.Left, rect.Top, width, height)
                }
            };
        }

        /// <summary>
        /// 获取排除内边框后的矩形
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="margin"></param>
        /// <param name="isMove"></param>
        /// <returns></returns>
        public static Rectangle Padding(this Rectangle rect, Margin padding)
        {
            return new Rectangle(
                rect.Left + padding.Left,
                rect.Top + padding.Top,
                rect.Width - padding.Left - padding.Right,
                rect.Height - padding.Top - padding.Bottom
                );
        }

        /// <summary>
        /// 获取移动后的矩形
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Rectangle Move(this Rectangle rect, Point point)
        {
            return new Rectangle(
                rect.Left + point.X,
                rect.Top + point.Y,
                rect.Width,
                rect.Height
                );
        }

        /// <summary>
        /// 获取移动后的矩形
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Rectangle Move(this Rectangle rect, float x, float y)
        {
            return new Rectangle(
                rect.Left + x,
                rect.Top + y,
                rect.Width,
                rect.Height
                );
        }
    }
}
