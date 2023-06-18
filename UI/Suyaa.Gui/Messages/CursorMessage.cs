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
    /// 光标设置消息
    /// </summary>
    public class CursorMessage : Message
    {

        /// <summary>
        /// 光标设置消息
        /// </summary>
        /// <param name="handle"></param>
        public CursorMessage(long handle) : base(GuiMessageType.Cursor, handle)
        {
        }
    }
}
