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
    /// 重置大小消息
    /// </summary>
    public sealed class MoveMessage : Message
    {
        /// <summary>
        /// 有效区域
        /// </summary>
        public Point Point { get; set; }

        /// <summary>
        /// 重置大小消息
        /// </summary>
        /// <param name="handle"></param>
        public MoveMessage(long handle, Point point) : base(GuiMessages.Layout, handle)
        {
            this.Point = point;
        }
    }
}
