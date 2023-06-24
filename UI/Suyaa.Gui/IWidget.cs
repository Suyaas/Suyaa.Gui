using SkiaSharp;
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
        Drawing.StyleCollection Style { get; }

        /// <summary>
        /// 缓存图像
        /// </summary>
        SKBitmap? CacheBitmap { get; }

        #endregion

        /// <summary>
        /// 刷新
        /// </summary>
        void Refresh();

        /// <summary>
        /// 获取样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <returns></returns>
        T GetStyle<T>(Enums.Styles style);

        /// <summary>
        /// 获取样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        T GetStyle<T>(Enums.Styles style, T defaultValue);

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        IWidget UseStyles(Action<Drawing.StyleCollection> action);

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <returns></returns>
        IWidget UseStyles<T>();
    }
}
