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
    public sealed class MouseMoveMessage : Message
    {

        /// <summary>
        /// 坐标
        /// </summary>
        public Point Point { get; }

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="handle"></param>
        public MouseMoveMessage(long handle, Point point) : base(GuiMessages.MouseMove, handle)
        {
            this.Point = point;
        }
    }
}
