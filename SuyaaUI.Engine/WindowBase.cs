using SuyaaUI.Engine.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuyaaUI
{
    /// <summary>
    /// 基类窗口
    /// </summary>
    /// <typeparam name="TWindow"></typeparam>
    public partial class WindowBase<TWindow> where TWindow : INativeWindow, IBlock, new()
    {
        /// <summary>
        /// 获取原生窗口
        /// </summary>
        public TWindow NativeWindow { get; }

        /// <summary>
        /// 基类窗口
        /// </summary>
        public WindowBase()
        {
            var win = NativeWindow = new TWindow();
            win.Create(win.Left, win.Top, win.Width, win.Height);
        }
    }
}
