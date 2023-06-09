﻿using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Messages
{
    /// <summary>
    /// 绘制消息
    /// </summary>
    public class PaintMessage : Message
    {
        /// <summary>
        /// 画板
        /// </summary>
        public SKCanvas Canvas { get; }

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="handle"></param>
        public PaintMessage(long handle, SKCanvas canvas) : base(GuiMessageType.Close, handle) {
            this.Canvas = canvas;
        }
    }
}