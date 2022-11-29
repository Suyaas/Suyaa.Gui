using System;
using System.Collections.Generic;
using System.Text;

namespace SuyaaUI.Engine.Blocks
{
    /// <summary>
    /// 区块接口
    /// </summary>
    public interface IBlock
    {
        /// <summary>
        /// 左边距
        /// </summary>
        int Left { get; }
        /// <summary>
        /// 上边距
        /// </summary>
        int Top { get; }
        /// <summary>
        /// 宽度
        /// </summary>
        int Width { get; }
        /// <summary>
        /// 高度
        /// </summary>
        int Height { get; }
        /// <summary>
        /// 样式集合
        /// </summary>
        Dictionary<string, string> Styles { get; }
        /// <summary>
        /// 更新显示
        /// </summary>
        void UpdateDisplay();
    }
}
