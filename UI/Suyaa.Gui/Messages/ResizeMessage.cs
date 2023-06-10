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
        /// 消息
        /// </summary>
        /// <param name="handle"></param>
        public ResizeMessage(long handle) : base(GuiMessageType.Close, handle)
        {
        }
    }
}
