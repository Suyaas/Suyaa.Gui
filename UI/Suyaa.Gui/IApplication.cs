using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 应用接口
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// 启动应用
        /// </summary>
        void Run(IForm form);
    }
}
