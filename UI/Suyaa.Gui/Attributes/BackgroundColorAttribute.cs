﻿using SkiaSharp;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 背景颜色
    /// </summary>
    public class BackgroundColorAttribute : ValueStyleAttribute<SKColor>
    {
        /// <summary>
        /// 背景颜色
        /// </summary>
        /// <param name="value"></param>
        public BackgroundColorAttribute(SKColor value) : base(StyleType.BackgroundColor, value)
        {
        }

        /// <summary>
        /// 背景颜色
        /// </summary>
        /// <param name="value"></param>
        public BackgroundColorAttribute(byte red, byte green, byte blue, byte alpha) : base(StyleType.BackgroundColor, new SKColor(red, green, blue, alpha))
        {
        }

        /// <summary>
        /// 背景颜色
        /// </summary>
        /// <param name="value"></param>
        public BackgroundColorAttribute(byte red, byte green, byte blue) : base(StyleType.BackgroundColor, new SKColor(red, green, blue))
        {
        }

        /// <summary>
        /// 背景颜色
        /// </summary>
        /// <param name="value"></param>
        public BackgroundColorAttribute(uint color) : base(StyleType.BackgroundColor, new SKColor(color))
        {
        }
    }
}
