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
    /// 初始化消息
    /// </summary>
    public class InitMessage : Message
    {
        /// <summary>
        /// 初始化消息
        /// </summary>
        /// <param name="handle"></param>
        public InitMessage(long handle) : base(GuiMessageType.Init, handle) { }
    }
}
