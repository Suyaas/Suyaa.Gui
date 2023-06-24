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
    /// 键盘按下消息
    /// </summary>
    public sealed class KeyDownMessage : KeyMessage
    {
        /// <summary>
        /// 键盘按下消息
        /// </summary>
        /// <param name="handle"></param>
        public KeyDownMessage(long handle, Keys key) : base(GuiMessages.KeyDown, handle, key) { }
    }
}
