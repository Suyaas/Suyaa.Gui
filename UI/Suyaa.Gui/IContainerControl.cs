using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 控件
    /// </summary>
    public interface IContainerControl : IControl
    {
        /// <summary>
        /// 子控件集合
        /// </summary>
        IControlCollection<IControl> Controls { get; }
    }
}
