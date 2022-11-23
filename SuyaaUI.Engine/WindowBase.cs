using System;
using System.Collections.Generic;
using System.Text;

namespace SuyaaUI
{
    /// <summary>
    /// 基类窗口
    /// </summary>
    /// <typeparam name="TWindow"></typeparam>
    public partial class WindowBase<TWindow> where TWindow : INativeWindow, new()
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
            NativeWindow = new TWindow();
        }
    }
}
