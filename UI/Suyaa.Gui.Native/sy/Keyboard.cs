using Forms;
using Suyaa.Gui;
using Suyaa.Gui.Enums;
using Suyaa.Gui.Native.Linux;
using Suyaa.Gui.Native.Win32;
using Suyaa.Gui.Native.Win32.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sy
{
    /// <summary>
    /// 键盘操作
    /// </summary>
    public static class Keyboard
    {
        /// <summary>
        /// 创建一个键盘管理器
        /// </summary>
        /// <returns></returns>
        public static IKeyboard Create()
        {
            if (sy.OS.IsWindows) return new Win32Keyboard();
            //if (sy.OS.IsLinux) return typeof(XForm);
            throw new NotSupportedException("OS not supported.");
        }
    }
}
