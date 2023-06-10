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
    /// 组件
    /// </summary>
    public interface IWidget
    {
        #region 属性

        /// <summary>
        /// 唯一句柄
        /// </summary>
        long Handle { get; }

        /// <summary>
        /// 样式列表
        /// </summary>
        Styles Styles { get; }

        /// <summary>
        /// 缓存图像
        /// </summary>
        SKBitmap? CacheBitmap { get; }

        #endregion

        /// <summary>
        /// 刷新
        /// </summary>
        void Refresh();
    }
}
