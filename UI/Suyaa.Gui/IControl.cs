using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 控件
    /// </summary>
    public interface IControl : IWidget
    {
        /// <summary>
        /// 关联窗体
        /// </summary>
        IForm Form { get; }

        /// <summary>
        /// 父控件
        /// </summary>
        IControl Parent { get; }

        /// <summary>
        /// 发送消息
        /// </summary>
        bool SendMessage(IMessage msg);

        /// <summary>
        /// 提交消息
        /// </summary>
        void PostMessage(IMessage msg);
    }
}
