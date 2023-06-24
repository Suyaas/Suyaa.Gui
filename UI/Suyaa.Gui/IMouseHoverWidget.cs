using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 鼠标可停悬组件
    /// </summary>
    public interface IMouseHoverWidget
    {
        /// <summary>
        /// 停悬样式列表
        /// </summary>
        StyleCollection MouseHoverStyles { get; }
    }
}
