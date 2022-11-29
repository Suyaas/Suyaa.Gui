using System;
using System.Collections.Generic;
using System.Text;
using static SuyaaUI.Windows.Natives.Win32Api;
using static SuyaaUI.Windows.Natives.Win32Msg;

namespace SuyaaUI.Windows.Natives
{
    /// <summary>
    /// 应用程序
    /// </summary>
    public static class Application
    {
        // 私有变量
        private static bool _isInitialized = false;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialize()
        {
            if (_isInitialized) return;
            _isInitialized = true;
            // 进入消息循环
            MSG msg = new MSG();
            while (true)
            {
                try
                {
                    GetMessage(ref msg, IntPtr.Zero, 0, 0);
                    TranslateMessage(ref msg);
                    DispatchMessage(ref msg);
                }
                catch { }
            }
        }
    }
}
