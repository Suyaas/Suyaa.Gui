﻿using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Attributes
{
    /// <summary>
    /// 样式基础特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = false)]
    public abstract class StyleAttribute : Attribute
    {
        /// <summary>
        /// 样式类型
        /// </summary>
        public Enums.Styles Style { get; }

        /// <summary>
        /// 样式基础特性
        /// </summary>
        /// <param name="style"></param>
        public StyleAttribute(Enums.Styles style)
        {
            this.Style = style;
        }

        /// <summary>
        /// 特性生效事件
        /// </summary>
        /// <param name="styles"></param>
        protected abstract void OnApply(Drawing.StyleCollection styles);

        /// <summary>
        /// 特性生效
        /// </summary>
        /// <param name="styles"></param>
        public void Apply(Drawing.StyleCollection styles) => this.OnApply(styles);
    }
}
