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
    /// 鼠标移开消息
    /// </summary>
    public class MouseLeaveMessage : Message
    {
        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="handle"></param>
        public MouseLeaveMessage(long handle) : base(GuiMessageType.MouseMove, handle)
        {
        }
    }
}
