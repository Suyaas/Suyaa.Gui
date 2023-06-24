using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Messages
{
    /// <summary>
    /// 绘制消息
    /// </summary>
    public sealed class PaintMessage : Message
    {
        /// <summary>
        /// 画板
        /// </summary>
        public SKCanvas Canvas { get; }

        /// <summary>
        /// 矩形区域
        /// </summary>
        public Rectangle Rectangle { get; }

        /// <summary>
        /// 缩放比例
        /// </summary>
        public float Scale { get; }

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="canvas"></param>
        /// <param name="rectangle"></param>
        /// <param name="scale"></param>
        public PaintMessage(long handle, SKCanvas canvas, Rectangle rectangle, float scale) : base(GuiMessages.Close, handle)
        {
            this.Canvas = canvas;
            this.Rectangle = rectangle;
            Scale = scale;
        }
    }
}
