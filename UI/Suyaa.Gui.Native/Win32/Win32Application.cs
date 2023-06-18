using Forms;
using Suyaa.Gui;
using Suyaa.Gui.Native.Win32.Apis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Win32
{
    /// <summary>
    /// Win32应用
    /// </summary>
    public class Win32Application : IApplication
    {
        // 是否循环处理消息
        private bool _continueLoop = false;

        /// <summary>
        /// 窗体句柄信息
        /// </summary>
        public Dictionary<IntPtr, long> Handles { get; }

        /// <summary>
        /// Win32应用
        /// </summary>
        public Win32Application()
        {
            this.Handles = new Dictionary<IntPtr, long>();
            // 设置
            Application.SetScale(Gdi32.GetDpiScale());
            // 光标预加载
            Cursors.Load();
        }

        /// <summary>
        /// 根据hwnd获取窗口句柄
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public long GetHandleByHwnd(IntPtr hwnd)
        {
            if (this.Handles.ContainsKey(hwnd)) return this.Handles[hwnd];
            return 0;
        }

        private bool PreTranslateMessage(User32.MSG msg)
        {
            User32.WM wm = (User32.WM)msg.message;
            //Debug.WriteLine($"[Loop] Hwnd: 0x{msg.hwnd.ToString("X2")}, Message: {wm.ToString()}(0x{msg.message.ToString("X2")})");
            switch (wm)
            {
                case User32.WM.DWMNCRENDERINGCHANGED:
                    //Debug.WriteLine(wm.ToString());
                    //var form = Application.GetForm(msg.hwnd.ToInt64());
                    //form.Show();
                    break;
                case User32.WM.TIMER:
                    // Debug.WriteLine(nameof(WM_TIMER));
                    break;
                case User32.WM.NCMOUSEMOVE:
                    // Debug.WriteLine(nameof(WM_NCMOUSEMOVE));
                    break;
                case User32.WM.NCLBUTTONDOWN:
                    // Debug.WriteLine(nameof(WM_NCLBUTTONDOWN));
                    break;
                case User32.WM.MOUSEMOVE:
                    // Debug.WriteLine(nameof(WM_MOUSEMOVE));
                    break;
                //case User32.WM.PAINT: return true;
                case User32.WM.QUIT:
                    _continueLoop = false;
                    Environment.Exit(0);
                    return true;
                    //default: Debug.WriteLine($"Message = {wm.ToString()}(0x{msg.message.ToString("X2")})"); break;
            }
            return false;
        }

        /// <summary>
        /// 退出
        /// </summary>
        public void Exit()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 启动应用
        /// </summary>
        public void Run(IForm form)
        {
            // SetProcessDPIAware 防止UI变大
            // 设置默认窗体
            Application.SetCurrentForm(form);
            // 默认窗体初始化
            form.Initialize();
            // 显示默认窗体
            Application.ShowCurrentForm();
            // 进入消息循环
            User32.MSG msg = new User32.MSG();
            _continueLoop = true;
            //bool unicodeWindow = true;

            while (_continueLoop)
            {
                //// 等待消息队列
                //if (User32.PeekMessage(ref msg))
                //{
                //    // 处理退出
                //    User32.WM wm = (User32.WM)msg.message;
                //    if (wm == User32.WM.QUIT)
                //    {
                //        Exit();
                //        continue;
                //    }
                User32.GetMessageW(ref msg, IntPtr.Zero, 0, 0);
                if (msg.message <= 0) continue;
                // 处理消息
                if (!PreTranslateMessage(msg))
                {
                    User32.TranslateMessage(ref msg);
                    User32.DispatchMessageW(ref msg);
                }
                //}

                //try
                //{
                //    // 等待消息队列
                //    if (User32.PeekMessage(ref msg))
                //    {
                //        // 获取消息
                //        //if (!User32.GetMessage(ref msg, IntPtr.Zero, 0, 0)) continue;
                //        User32.WM wm = (User32.WM)msg.message;
                //        Debug.WriteLine($"[Loop] Hwnd: 0x{msg.hwnd.ToString("X2")}, Message: {wm.ToString()}(0x{msg.message.ToString("X2")})");
                //        // 处理退出
                //        if (wm == User32.WM.QUIT)
                //        {
                //            Exit();
                //            continue;
                //        }
                //        // 判断字符集
                //        if (msg.hwnd != IntPtr.Zero && User32.IsWindowUnicode(msg.hwnd).IsTrue())
                //        {
                //            unicodeWindow = true;
                //            // 获取消息
                //            if (User32.GetMessageW(ref msg).IsFalse())
                //                continue;
                //        }
                //        else
                //        {
                //            unicodeWindow = false;
                //            //if (User32.GetMessageA(ref msg).IsFalse())
                //            //    continue;
                //            if (!User32.GetMessage(ref msg, IntPtr.Zero, 0, 0))
                //                continue;
                //        }
                //        // 处理消息
                //        if (!PreTranslateMessage(msg))
                //        {
                //            User32.TranslateMessage(ref msg);
                //            //User32.DispatchMessage(ref msg);
                //            if (unicodeWindow)
                //            {
                //                User32.DispatchMessageW(ref msg);
                //            }
                //            else
                //            {
                //                User32.DispatchMessageA(ref msg);
                //            }
                //        }
                //    }
                //}
                //catch { }
            }
        }
    }
}
