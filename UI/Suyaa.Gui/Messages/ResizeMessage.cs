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
    public class ResizeMessage : Message
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// 高度
        /// </summary>
        public float Height { get; }

        /// <summary>
        /// 缩放比例
        /// </summary>
        public float Scale { get; }

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="handle"></param>
        public ResizeMessage(long handle, float width, float height, float scale) : base(GuiMessageType.Close, handle)
        {
            this.Width = width;
            this.Height = height;
            this.Scale = scale;
        }
    }
}
