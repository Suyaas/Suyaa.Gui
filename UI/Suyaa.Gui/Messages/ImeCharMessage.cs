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
    /// IME输入消息
    /// </summary>
    public sealed class ImeCharMessage : Message
    {
        /// <summary>
        /// 字符
        /// </summary>
        public char Char { get; set; }

        /// <summary>
        /// IME输入消息
        /// </summary>
        /// <param name="handle"></param>
        public ImeCharMessage(long handle, char chr) : base(GuiMessages.ImeChar, handle)
        {
            this.Char = chr;
        }
    }
}
