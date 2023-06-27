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
        Cursors Cursor { get; set; }

        /// <summary>
        /// 处理系统绘制消息
        /// </summary>
        public bool Repaint(bool force);

        /// <summary>
        /// 当前控件
        /// </summary>
        IControl? CurrentControl { get; set; }
    }
}