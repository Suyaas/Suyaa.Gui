using SkiaSharp;
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
    public class PaintMessage : IMessage
    {
        /// <summary>
        /// 消息
        /// </summary>
        public GuiMessageType Message { get; }

        /// <summary>
        /// 对象句柄
        /// </summary>
        public long Handle { get; }

        /// <summary>
        /// 画板
        /// </summary>
        public SKCanvas Canvas { get; }

        /// <summary>
        /// 绘制消息
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="canvas"></param>
        public PaintMessage(long handle, SKCanvas canvas)
        {
            this.Handle = handle;
            this.Message = GuiMessageType.Paint;
            this.Canvas = canvas;
        }
    }
}
