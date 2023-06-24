using SkiaSharp;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Messages
{
    /// <summary>
    /// 关闭消息
    /// </summary>
    public sealed class CloseMessage : Message
    {
        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="handle"></param>
        public CloseMessage(long handle) : base(GuiMessages.Close, handle) { }
    }
}
