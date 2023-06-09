using SkiaSharp;
using Suyaa.Gui.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 组件集合
    /// </summary>
    public interface IControlContainer<T> : IList<T>
        where T : IControl
    {
    }
}
