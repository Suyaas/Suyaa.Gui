﻿using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Drawing
{
    // 样式类型
    public enum StyleType : uint
    {
        #region 基础样式
        /// <summary>
        /// 无样式
        /// </summary>
        None = 0,
        /// <summary>
        /// 可见性
        /// </summary>
        [StyleValue(typeof(bool))]
        Visible = 0x01,
        /// <summary>
        /// 使用缓存
        /// </summary>
        [StyleValue(typeof(bool))]
        UseCache = 0x11,
        #endregion
        #region 二维样式_0x100
        /// <summary>
        /// 上边距
        /// </summary>
        [StyleValue(typeof(float))]
        Top = 0x101,
        /// <summary>
        /// 右边距
        /// </summary>
        [StyleValue(typeof(float))]
        Right = 0x102,
        /// <summary>
        /// 下边距
        /// </summary>
        [StyleValue(typeof(float))]
        Bottom = 0x103,
        /// <summary>
        /// 左边距
        /// </summary>
        [StyleValue(typeof(float))]
        Left = 0x104,
        /// <summary>
        /// 宽度
        /// </summary>
        [StyleValue(typeof(float))]
        Width = 0x111,
        /// <summary>
        /// 高度
        /// </summary>
        [StyleValue(typeof(float))]
        Height = 0x112,
        /// <summary>
        /// 内边距（统一）
        /// </summary>
        [StyleValue(typeof(float))]
        Padding = 0x120,
        /// <summary>
        /// 内上边距
        /// </summary>
        [StyleValue(typeof(float))]
        PaddingTop = 0x121,
        /// <summary>
        /// 内右边距
        /// </summary>
        [StyleValue(typeof(float))]
        PaddingRight = 0x122,
        /// <summary>
        /// 内下边距
        /// </summary>
        [StyleValue(typeof(float))]
        PaddingBottom = 0x123,
        /// <summary>
        /// 内左边距
        /// </summary>
        [StyleValue(typeof(float))]
        PaddingLeft = 0x124,
        /// <summary>
        /// 背景颜色
        /// </summary>
        [StyleValue(typeof(SKColor))]
        BackgroundColor = 0x131,
        #endregion
        #region 边框相关样式_0x200
        /// <summary>
        /// 边框尺寸
        /// </summary>
        [StyleValue(typeof(float))]
        BorderSize = 0x201,
        /// <summary>
        /// 边框类型
        /// </summary>
        [StyleValue(typeof(float))]
        BorderStyle = 0x202,
        /// <summary>
        /// 边框颜色
        /// </summary>
        [StyleValue(typeof(SKColor))]
        BorderColor = 0x203,
        #endregion
        #region 文本样式_0x300
        /// <summary>
        /// 文本颜色
        /// </summary>
        [StyleValue(typeof(SKColor))]
        TextColor = 0x301,
        /// <summary>
        /// 文本字体
        /// </summary>
        [StyleValue(typeof(string))]
        TextFont = 0x302,
        /// <summary>
        /// 文本字号
        /// </summary>
        [StyleValue(typeof(float))]
        TextSize = 0x303,
        #endregion
    }
}