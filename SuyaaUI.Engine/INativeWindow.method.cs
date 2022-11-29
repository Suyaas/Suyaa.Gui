using SkiaSharp;
using System;

namespace SuyaaUI
{
    /* 方法 */
    public partial interface INativeWindow
    {
        /// <summary>
        /// 创建窗口
        /// </summary>
        /// <returns></returns>
        void Create(int left, int top, int width, int height);

        /// <summary>
        /// 设置图标
        /// </summary>
        /// <param name="bitmap"></param>
        void SetIcon(SKBitmap bitmap);

        /// <summary>
        /// 设置图标
        /// </summary>
        /// <param name="path"></param>
        void SetIcon(string path);

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        void Show();
    }
}
