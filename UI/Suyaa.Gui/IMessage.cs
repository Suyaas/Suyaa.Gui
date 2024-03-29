﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Gui.Enums;

namespace Suyaa.Gui
{
    /// <summary>
    /// 消息
    /// </summary>
    public interface IMessage : IDisposable
    {
        /// <summary>
        /// 唯一句柄
        /// </summary>
        long Handle { get; }

        /// <summary>
        /// 消息类型
        /// </summary>
        GuiMessages MessageType { get; }
    }
}
