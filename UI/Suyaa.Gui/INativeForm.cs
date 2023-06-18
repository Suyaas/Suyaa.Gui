using Suyaa.Gui;
using Suyaa.Gui.Enums;

namespace Forms
{
    /// <summary>
    /// 原生窗体
    /// </summary>
    public interface INativeForm : IWidget, IDisposable
    {
        /// <summary>
        /// 窗口标题
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize();

        /// <summary>
        /// 显示
        /// </summary>
        void Show();

        /// <summary>
        /// 光标类型
        /// </summary>
        CursorType Cursor { get; set; }
    }
}