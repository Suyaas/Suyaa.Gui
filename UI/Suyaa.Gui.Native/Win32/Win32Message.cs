using SkiaSharp;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using Suyaa.Gui.Messages;
using Suyaa.Gui.Native.Helpers;
using Suyaa.Gui.Native.Win32.Apis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.User32;
using Point = Suyaa.Gui.Drawing.Point;
using Rectangle = Suyaa.Gui.Drawing.Rectangle;
using Size = Suyaa.Gui.Drawing.Size;

namespace Suyaa.Gui.Native.Win32
{
    /// <summary>
    /// Win32消息处理
    /// </summary>
    internal static class Win32Message
    {
        // 默认线程操作对象
        private static IntPtr _defWindowProc = IntPtr.Zero;

        /// <summary>
        /// 设置默认处理函数
        /// </summary>
        /// <param name="ptr"></param>
        public static void SetDefWindowProc(IntPtr ptr)
        {
            _defWindowProc = ptr;
        }

        // 获取Form
        private static IForm GetFormByHwnd(IntPtr hwnd)
        {
            Win32Application win32 = (Win32Application)Application.GetCurrent();
            long handle = win32.GetHandleByHwnd(hwnd);
            var form = Application.GetFormByHandle(handle);
            if (form is null) throw new GuiException($"Native form '0x{hwnd.ToString("x").PadLeft(12, '0')}' not found.");
            return form;
        }

        // 获取Win32Form
        private static Win32Form GetWin32FormByHwnd(IntPtr hwnd)
        {
            var form = GetFormByHwnd(hwnd);
            return (Win32Form)form.NativeForm;
        }

        // 获取坐标信息
        private static Point GetPointByLParam(IntPtr lParam)
        {
            var lp = lParam.ToInt32();
            return new Point(lp.GetLWord(), lp.GetHWord());
        }

        #region 绘制相关

        /// <summary>
        /// 处理绘制消息
        /// </summary>
        /// <param name="hwnd"></param>
        public static void ProcPaint(IntPtr hwnd)
        {
            // 输出调试
            //Debug.WriteLine($"[Win32Message] Paint - Hwnd: 0x{hwnd.ToString("x").PadLeft(12, '0')}");
            // 计算dpi比例
            //var scale = Gdi32.GetDpiScale();
            //var scale = Application.GetScale();
            //var form = GetWin32FormByHwnd(hwnd);
            var form = GetFormByHwnd(hwnd);
            //ProcPaint(form, scale);
            form.Repaint(true);
        }

        #endregion

        /// <summary>
        /// 处理重置尺寸消息
        /// </summary>
        /// <param name="form"></param>
        /// <param name="scale"></param>
        public static void ProcResize(Win32Form form, float scale)
        {
            // 输出调试
            //Debug.WriteLine($"[Win32Message] Resize - Handle: 0x{form.Handle.ToString("x").PadLeft(12, '0')}");
            using (ResizeMessage msg = new(form.Handle, new Size(), scale))
            {
                Application.SendMessage(msg);
            }
            // 重新绘制
            //ProcPaint(hwnd);
        }

        /// <summary>
        /// 处理重置尺寸消息
        /// </summary>
        /// <param name="hwnd"></param>
        public static void ProcResize(IntPtr hwnd)
        {
            // 计算dpi比例
            var scale = Application.GetScale();
            // 获取窗体
            var form = GetWin32FormByHwnd(hwnd);
            ProcResize(form, scale);
        }

        // 接收到绘制消息
        public unsafe static void ProcSysCommand(IntPtr hwnd, IntPtr wParam)
        {
            // 系统命令
            var wp = wParam.ToInt32().GetLWord() & 0xFFF0;
            var sc = (User32.SC)wp;
            Debug.WriteLine($"[Win32Message] SysCommand - Hwnd: 0x{hwnd.ToString("x").PadLeft(12, '0')}, {sc.ToString()}");
            // 获取关联窗体
            var form = GetFormByHwnd(hwnd);
            switch (sc)
            {
                // 还原
                case User32.SC.RESTORE:
                    using (StatusChangeMessage msg = new(form.Handle, FormStatuses.Normal))
                    {
                        form.SendMessage(msg);
                    }
                    break;
                // 最小化
                case User32.SC.MINIMIZE:
                    using (StatusChangeMessage msg = new(form.Handle, FormStatuses.Minimize))
                    {
                        form.SendMessage(msg);
                    }
                    break;
                // 最大化
                case User32.SC.MAXIMIZE:
                    using (StatusChangeMessage msg = new(form.Handle, FormStatuses.Maximize))
                    {
                        form.SendMessage(msg);
                    }
                    break;
            }
        }

        #region 鼠标相关

        // 接收到鼠标移动消息
        public unsafe static void ProcNCMouseMove(IntPtr hwnd, IntPtr lParam)
        {
            // 获取关联窗体
            var form = GetFormByHwnd(hwnd);
            // 获取坐标
            var point = GetPointByLParam(lParam);
            using (NCMouseMoveMessage msg = new(form.Handle, point))
            {
                form.SendMessage(msg);
            }
        }

        // 接收到鼠标移动消息
        public unsafe static void ProcMouseMove(IntPtr hwnd, IntPtr lParam)
        {
            // 获取关联窗体
            var form = GetFormByHwnd(hwnd);
            // 获取坐标
            var point = GetPointByLParam(lParam);
            using (MouseMoveMessage msg = new(form.Handle, point))
            {
                form.SendMessage(msg);
            }
        }

        // 接收到鼠标操作消息
        public unsafe static void ProcMouseOperate(IntPtr hwnd, IntPtr lParam, MouseOperates mouseOperate)
        {
            // 获取关联窗体
            var form = GetFormByHwnd(hwnd);
            // 获取坐标
            var point = GetPointByLParam(lParam);
            //Debug.WriteLine($"[Win32Message] MouseOperate - Hwnd: 0x{hwnd.ToString("x").PadLeft(12, '0')}, {mouseOperate.ToString()}({point.X}, {point.Y})");
            using (MouseButtonMessage msg = new(form.Handle, mouseOperate, point))
            {
                form.SendMessage(msg);
            }
        }

        /// <summary>
        /// 处理光标消息
        /// </summary>
        /// <param name="hwnd"></param>
        public static void ProcCursor(IntPtr hwnd)
        {
            // 获取窗体
            var form = GetFormByHwnd(hwnd);
            //var cursor = (Cursor)form.Cursor;
            //Debug.WriteLine($"[Win32Message] Cursor - Hwnd: 0x{hwnd.ToString("x").PadLeft(12, '0')}, Cursor: {form.Cursor})");
            //form.Cursor = form.Cursor;
            using (CursorMessage msg = new(form.Handle))
            {
                form.SendMessage(msg);
            }
        }

        /// <summary>
        /// 处理键盘按下事件
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="wParam"></param>
        public static void ProcKeyDown(IntPtr hwnd, IntPtr wParam)
        {
            // 获取窗体
            var form = GetFormByHwnd(hwnd);
            var key = (Keys)wParam;
            //Debug.WriteLine($"[Win32Message] KeyDown - Hwnd: 0x{hwnd.ToString("x").PadLeft(12, '0')}, Key: {key})");
            using (KeyDownMessage msg = new(form.Handle, key))
            {
                form.SendMessage(msg);
            }
        }

        /// <summary>
        /// 处理键盘按下事件
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="wParam"></param>
        public static void ProcKeyUp(IntPtr hwnd, IntPtr wParam)
        {
            // 获取窗体
            var form = GetFormByHwnd(hwnd);
            var key = (Keys)wParam;
            //Debug.WriteLine($"[Win32Message] KeyUp - Hwnd: 0x{hwnd.ToString("x").PadLeft(12, '0')}, Key: {key})");
            using (KeyUpMessage msg = new(form.Handle, key))
            {
                form.SendMessage(msg);
            }
        }

        #endregion

        #region 输入法相关

        /// <summary>
        /// Ime通知事件
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="wParam"></param>
        public static void ProcImeNotify(IntPtr hwnd, IntPtr wParam)
        {
            // 获取窗体
            var form = GetFormByHwnd(hwnd);
            var imn = (Imm32.IMN)wParam;
            Debug.WriteLine($"[Win32Message] ImeNotify - Hwnd: 0x{hwnd.ToString("x").PadLeft(12, '0')}, imn: {imn})");
            if (imn == Imm32.IMN.SETCONVERSIONMODE)
            {
                using (ImeNotifyMessage msg = new(form.Handle))
                {
                    form.SendMessage(msg);
                }
            }
        }

        /// <summary>
        /// 处理键盘按下事件
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="wParam"></param>
        public static void ProcChar(IntPtr hwnd, IntPtr wParam)
        {
            // 获取窗体
            var form = GetFormByHwnd(hwnd);
            var chr = (char)wParam;
            //Debug.WriteLine($"[Win32Message] KeyDown - Hwnd: 0x{hwnd.ToString("x").PadLeft(12, '0')}, Key: {key})");
            using (ImeCharMessage msg = new(form.Handle, chr))
            {
                form.SendMessage(msg);
            }
        }

        #endregion

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static IntPtr Proc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            User32.WM wm = (User32.WM)msg;
            User32.SetWindowLong(hwnd, User32.GWL.WNDPROC, _defWindowProc);
            switch (wm)
            {
                // 创建
                case User32.WM.CREATE: break;
                // 系统命令
                case User32.WM.SYSCOMMAND: ProcSysCommand(hwnd, wParam); break;
                // 绘制背景处理
                // case User32.WM.ERASEBKGND: WinProcPaint(hwnd); break;
                // 绘制
                case User32.WM.PAINT: ProcPaint(hwnd); break;
                // 尺寸变更
                case User32.WM.SIZE: ProcResize(hwnd); break;
                // 鼠标事件
                case User32.WM.MOUSEMOVE: ProcMouseMove(hwnd, lParam); break;
                //case User32.WM.MOUSELEAVE: ProcMouseLeave(hwnd, lParam); break;
                //case User32.WM.MOUSEHOVER: ProcMouseHover(hwnd, lParam); break;
                case User32.WM.LBUTTONDOWN: ProcMouseOperate(hwnd, lParam, MouseOperates.LButtonDown); break;
                case User32.WM.LBUTTONUP: ProcMouseOperate(hwnd, lParam, MouseOperates.LButtonUp); break;
                case User32.WM.RBUTTONDOWN: ProcMouseOperate(hwnd, lParam, MouseOperates.RButtonDown); break;
                case User32.WM.RBUTTONUP: ProcMouseOperate(hwnd, lParam, MouseOperates.RButtonUp); break;
                case User32.WM.MBUTTONDOWN: ProcMouseOperate(hwnd, lParam, MouseOperates.MButtonDown); break;
                case User32.WM.MBUTTONUP: ProcMouseOperate(hwnd, lParam, MouseOperates.MButtonUp); break;
                // 非活动区鼠标移动
                case User32.WM.NCMOUSEMOVE: ProcNCMouseMove(hwnd, lParam); break;
                case User32.WM.NCMOUSEHOVER: break;
                case User32.WM.NCMOUSELEAVE: break;
                // 销毁窗口
                case User32.WM.DESTROY:
                    //User32.PostQuitMessage(0);
                    Win32Application win32 = (Win32Application)Application.GetCurrent();
                    Application.PostMessage(new CloseMessage(win32.GetHandleByHwnd(hwnd)));
                    break;
                // 光标设置
                case User32.WM.SETCURSOR: ProcCursor(hwnd); break;
                // 键盘操作
                case User32.WM.KEYDOWN: ProcKeyDown(hwnd, wParam); break;
                case User32.WM.KEYUP: ProcKeyUp(hwnd, wParam); break;
                case WM.CHAR: ProcChar(hwnd, wParam); break;
                // Ime相关
                case User32.WM.IME_NOTIFY: ProcImeNotify(hwnd, wParam); break;
                //case User32.WM.IME_REQUEST: break;
                //case User32.WM.IME_STARTCOMPOSITION: break;
                //case User32.WM.IME_COMPOSITION: break;
                default:
                    Debug.WriteLine($"[WinProc] Hwnd: 0x{hwnd.ToString("X2")}, Message: {wm.ToString()}(0x{msg.ToString("X2")})");
                    break;
            }
            var res = User32.DefWindowProcW(hwnd, wm, wParam, lParam);
            //Debug.WriteLine($"[WinProc] Hwnd: 0x{hwnd.ToString("X2")}, Message: {wm.ToString()}(0x{msg.ToString("X2")}), Result: {res}");
            return res;
        }
    }
}
