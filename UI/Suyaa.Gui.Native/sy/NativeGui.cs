using Forms;
using Suyaa.Gui;
using Suyaa.Gui.Native.Linux;
using Suyaa.Gui.Native.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sy
{
    /// <summary>
    /// 界面
    /// </summary>
    public static class NativeGui
    {
        /// <summary>
        /// 获取原生窗口类型
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static Type GetNativeFormType()
        {
            if (sy.OS.IsWindows) return typeof(Win32Form);
            if (sy.OS.IsLinux) return typeof(XForm);
            throw new NotSupportedException("OS not supported.");
        }

        /// <summary>
        /// 创建一个原生窗口
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static INativeForm CreateNativeForm()
        {
            if (sy.OS.IsWindows) return new Win32Form();
            if (sy.OS.IsLinux) return new XForm();
            throw new NotSupportedException("OS not supported.");
        }
    }
}
