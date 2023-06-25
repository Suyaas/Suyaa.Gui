using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 支持偏移定位的组件
    /// </summary>
    public interface IWidgetOffset
    {
        /// <summary>
        /// 水平偏移
        /// </summary>
        int OffsetX { get; }

        /// <summary>
        /// 垂直偏移
        /// </summary>
        int OffsetY { get; }
    }
}
