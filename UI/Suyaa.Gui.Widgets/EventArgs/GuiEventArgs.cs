using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Controls.EventArgs
{
    /// <summary>
    /// Gui事件参数
    /// </summary>
    public class GuiEventArgs : IDisposable
    {
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
