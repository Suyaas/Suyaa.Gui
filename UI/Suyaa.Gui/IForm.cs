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
    public interface IForm : IWidget, IDisposable
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
    }
}
