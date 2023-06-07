using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 消息
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// 唯一句柄
        /// </summary>
        long Handle { get; }

        /// <summary>
        /// 消息类型
        /// </summary>
        GuiMessageType MessageType { get; }
    }
}
