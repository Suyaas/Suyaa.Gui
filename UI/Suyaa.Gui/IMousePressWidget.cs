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
    /// 鼠标可按压组件
    /// </summary>
    public interface IMousePressWidget
    {
        /// <summary>
        /// 鼠标按下样式列表
        /// </summary>
        Styles MousePressStyles { get; }
    }
}
