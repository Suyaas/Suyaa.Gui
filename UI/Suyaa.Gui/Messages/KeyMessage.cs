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
    public abstract class KeyMessage : Message
    {
        /// <summary>
        /// 键值
        /// </summary>
        public Keys Key { get; }

        /// <summary>
        /// 按键消息消息
        /// </summary>
        /// <param name="handle"></param>
        public KeyMessage(GuiMessages message, long handle, Keys key) : base(message, handle)
        {
            Key = key;
        }
    }
}
