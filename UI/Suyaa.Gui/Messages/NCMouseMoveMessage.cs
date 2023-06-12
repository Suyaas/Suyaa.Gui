using SkiaSharp;
using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Messages
{
    /// <summary>
    /// 非工作区鼠标移动消息
    /// </summary>
    public class NCMouseMoveMessage : Message
    {
        /// <summary>
        /// 坐标
        /// </summary>
        public Point Point { get; }

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="handle"></param>
        public NCMouseMoveMessage(long handle, Point point) : base(GuiMessageType.MouseMove, handle)
        {
            this.Point = point;
        }
    }
}
