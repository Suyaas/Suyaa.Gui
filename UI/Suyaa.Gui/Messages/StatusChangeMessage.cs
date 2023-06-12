﻿using SkiaSharp;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Messages
{
    /// <summary>
    /// 状态变化消息
    /// </summary>
    public class StatusChangeMessage : Message
    {
        /// <summary>
        /// 窗体窗台
        /// </summary>
        public FormStatusType FormStatus { get; }

        /// <summary>
        /// 状态变化消息
        /// </summary>
        /// <param name="handle"></param>
        public StatusChangeMessage(long handle, FormStatusType formStatus) : base(GuiMessageType.StatusChange, handle)
        {
            this.FormStatus = formStatus;
        }
    }
}
