﻿using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Messages
{
    /// <summary>
    /// 重置大小消息
    /// </summary>
    public class ResizeMessage : Message
    {
        /// <summary>
        /// 有效区域
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// 缩放比例
        /// </summary>
        public float Scale { get; }

        /// <summary>
        /// 重置大小消息
        /// </summary>
        /// <param name="handle"></param>
        public ResizeMessage(long handle, Size size, float scale) : base(GuiMessageType.Layout, handle)
        {
            this.Size = size;
            this.Scale = scale;
        }
    }
}
