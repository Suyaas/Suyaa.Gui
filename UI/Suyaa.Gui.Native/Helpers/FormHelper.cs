using Suyaa.Gui.Drawing;
using Suyaa.Gui.Native.Linux;
using Suyaa.Gui.Native.Win32;
using Suyaa.Gui.Native.Win32.Apis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Suyaa.Gui.Native.Win32.Apis.Enums;
using static Suyaa.Gui.Native.Win32.Apis.Imm32;
using Point = Suyaa.Gui.Drawing.Point;

namespace Suyaa.Gui.Native.Helpers
{
    /// <summary>
    /// 窗体助手类
    /// </summary>
    public static class FormHelper
    {
        // 设置 Windows Ime 状态
        private static void SetWin32ImeState(IForm form, BOOL state)
        {
            if (form.NativeForm is not Win32Form win32Form) return;
            var hImc = Imm32.ImmGetContext(win32Form.Hwnd);
            if (hImc == 0) return;
            var res = Imm32.ImmSetOpenStatus(hImc, state);
            if (res == BOOL.FALSE) return;
            Imm32.ImmReleaseContext(win32Form.Hwnd, hImc);
        }

        // 设置 Windows Ime 状态
        internal static void SetWin32ImePosition(this IForm form)
        {
            if (form.NativeForm is not Win32Form win32Form) return;
            if (form.CurrentControl is null) return;
            if (form.CurrentControl is not IWidgetTextContent txt) return;
            var hImc = Imm32.ImmGetContext(win32Form.Hwnd);
            if (hImc == 0) return;
            // 获取光标位置
            Point p = form.CurrentControl.GetFormOffset();
            var rect = txt.InputCursorRectangle;
            COMPOSITIONFORM composition = new COMPOSITIONFORM();
            composition.dwStyle = Imm32.CFS_POINT;
            composition.ptCurrentPos.x = (int)(p.X + rect.Left);
            composition.ptCurrentPos.y = (int)(p.Y + rect.Top);
            var res = Imm32.ImmSetCompositionWindow(hImc, ref composition);
            if (res == BOOL.FALSE) return;
            Imm32.ImmReleaseContext(win32Form.Hwnd, hImc);
        }

        /// <summary>
        /// 更新IME位置
        /// </summary>
        public static void UpdateImePosition(this IForm form)
        {
            if (sy.OS.IsWindows)
            {
                form.SetWin32ImePosition();
                return;
            }
            //if (sy.OS.IsLinux) return typeof(XForm);
            throw new NotSupportedException("OS not supported.");
        }

        /// <summary>
        /// 设置IME可用
        /// </summary>
        public static void SetImeEnable(this IForm form)
        {
            if (sy.OS.IsWindows)
            {
                SetWin32ImeState(form, BOOL.TRUE);
                return;
            }
            //if (sy.OS.IsLinux) return typeof(XForm);
            throw new NotSupportedException("OS not supported.");
        }

        /// <summary>
        /// 设置IME不可用
        /// </summary>
        public static void SetImeDisabled(this IForm form)
        {
            if (sy.OS.IsWindows)
            {
                SetWin32ImeState(form, BOOL.FALSE);
                return;
            }
            //if (sy.OS.IsLinux) return typeof(XForm);
            throw new NotSupportedException("OS not supported.");
        }
    }
}
