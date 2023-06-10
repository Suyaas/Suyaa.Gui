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
    /// 控件集合
    /// </summary>
    public interface IControlContainer<T> : IList<T>
        where T : IWidget
    {
        /// <summary>
        /// 批量添加控件
        /// </summary>
        /// <param name="items"></param>
        void AddRange(params T[] items);
    }
}
