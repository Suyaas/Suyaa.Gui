using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Gui.Enums;

namespace Suyaa.Gui.Messages
{
    /// <summary>
    /// 消息
    /// </summary>
    public abstract class Message : IMessage
    {
        /// <summary>
        /// 消息
        /// </summary>
        public GuiMessageType MessageType { get; }

        /// <summary>
        /// 对象句柄
        /// </summary>
        public long Handle { get; }

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="canvas"></param>
        public Message(GuiMessageType messageType, long handle)
        {
            this.Handle = handle;
            this.MessageType = messageType;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
