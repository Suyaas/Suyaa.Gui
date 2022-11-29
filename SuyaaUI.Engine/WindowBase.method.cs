using System;
using System.Collections.Generic;
using System.Text;

namespace SuyaaUI
{
    /* 方法 */
    public partial class WindowBase<TWindow>
    {

        /// <summary>
        /// 显示窗口
        /// </summary>
        public void Show()
        {
            NativeWindow.Show();
        }

    }
}
