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
    public interface IForm : INativeForm
    {
        /// <summary>
        /// 原生窗体
        /// </summary>
        INativeForm NativeForm { get; }

        /// <summary>
        /// 发送消息
        /// </summary>
        bool SendMessage(IMessage msg);

        /// <summary>
        /// 提交消息
        /// </summary>
        void PostMessage(IMessage msg);

        /// <summary>
        /// 控件集合
        /// </summary>
        IControlCollection<IControl> Controls { get; }
    }
}
