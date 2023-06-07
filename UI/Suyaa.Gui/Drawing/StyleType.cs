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
        #region 二维样式
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
        #endregion
    }
}
