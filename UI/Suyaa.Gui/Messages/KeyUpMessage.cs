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
    /// 键盘抬起消息
    /// </summary>
    public sealed class KeyUpMessage : KeyMessage
    {
        /// <summary>
        /// 键盘抬起消息
        /// </summary>
        /// <param name="handle"></param>
        public KeyUpMessage(long handle, Keys key) : base(GuiMessages.KeyUp, handle, key) { }
    }
}
