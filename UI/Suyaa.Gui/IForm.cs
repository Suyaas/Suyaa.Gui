using Forms;
using Suyaa.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 窗口
    /// </summary>
    public interface IForm: INativeForm
    {
        /// <summary>
        /// 原生窗体
        /// </summary>
        INativeForm NativeForm { get; }
    }

    /// <summary>
    /// 窗口
    /// </summary>
    public interface IForm<T> : IForm
        where T : IControl
    {
        /// <summary>
        /// 控件集合
        /// </summary>
        IControlContainer<T> Controls { get; }
    }
}
