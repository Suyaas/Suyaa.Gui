using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /// <summary>
    /// 句柄包含接口
    /// </summary>
    public interface IHandle
    {
        /// <summary>
        /// 句柄
        /// </summary>
        IntPtr Handle { get; }
    }
}
