using Forms;
using Suyaa.Gui;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Linux
{
    /// <summary>
    /// Win32应用
    /// </summary>
    public class XApplication : IApplication
    {

        /// <summary>
        /// 退出
        /// </summary>
        public void Exit()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 启动应用
        /// </summary>
        public void Run(IForm form)
        {
            // 设置默认窗体
            Application.SetCurrentForm(form);
            // 默认窗体初始化
            form.Initialize();
            // 显示默认窗体
            Application.ShowCurrentForm();
            // 进入消息循环
            //User32.MSG msg = new User32.MSG();
        }
    }
}
