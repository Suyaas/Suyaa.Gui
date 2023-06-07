using Suyaa.Gui;
using Suyaa.Gui.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui
{
    /// <summary>
    /// 应用
    /// </summary>
    public static class Application
    {
        // 所有窗体
        private static List<IForm> _forms = new List<IForm>();
        // 所有控件关系
        private static Dictionary<long, long> _controls = new Dictionary<long, long>();
        // 应用信息
        private static IApplication? _application;
        // 默认窗体
        private static IForm? _currentForm;
        // 句柄生成器
        private static long _hanlder = 0;
        private static object _hanlderLock = new object();

        /// <summary>
        /// 设置应用实现类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static IApplication Set<T>() where T : IApplication, new()
        {
            _application = new T();
            return _application;
        }

        /// <summary>
        /// 获取当前应用
        /// </summary>
        /// <returns></returns>
        public static IApplication GetCurrent()
        {
            if (_application is null) throw new GuiException($"No application found.");
            return _application;
        }

        /// <summary>
        /// 设置默认窗体
        /// </summary>
        public static void SetCurrentForm(IForm form)
        {
            _currentForm = form;
        }

        /// <summary>
        /// 显示默认窗体
        /// </summary>
        public static void ShowCurrentForm()
        {
            if (_currentForm is null) throw new GuiException($"No current form found.");
            _currentForm.Show();
        }

        /// <summary>
        /// 注册控件
        /// </summary>
        /// <param name="control">组件</param>
        /// <param name="form">窗体</param>
        public static void RegControl(IControl control, IForm? form)
        {
            long formHandle = 0;
            if (form != null) formHandle = form.Handle;
            _controls[control.Handle] = formHandle;
        }

        /// <summary>
        /// 注册窗体
        /// </summary>
        /// <param name="form"></param>
        public static void RegForm(IForm form)
        {
            _forms.Add(form);
            _controls[form.Handle] = form.Handle;
        }

        /// <summary>
        /// 获取所有窗体
        /// </summary>
        public static List<IForm> GetForms()
            => _forms;

        /// <summary>
        /// 获取窗体
        /// </summary>
        public static IForm GetForm(long handle)
        {
            var form = GetFormByHandle(handle);
            if (form is null) throw new GuiException($"Form handle '{handle}' not found.");
            return form;
        }

        /// <summary>
        /// 获取窗体
        /// </summary>
        public static IForm GetForm(IControl control)
        {
            var form = GetFormByControl(control);
            if (form is null) throw new GuiException($"Control handle '{control.Handle}' not found form.");
            return form;
        }

        /// <summary>
        /// 获取窗体
        /// </summary>
        public static IForm? GetFormByHandle(long handle)
            => _forms.Where(d => d.Handle == handle).FirstOrDefault();

        /// <summary>
        /// 获取窗体
        /// </summary>
        public static IForm? GetFormByControl(IControl control)
        {
            if (!_controls.ContainsKey(control.Handle)) return null;
            long formHandle = _controls[control.Handle];
            if (formHandle <= 0) return null;
            return GetFormByHandle(formHandle);
        }

        /// <summary>
        /// 获取窗体句柄
        /// </summary>
        public static long GetFormHanldeByControl(IControl control)
        {
            return GetFormHanldeByControlHanlde(control.Handle);
        }

        /// <summary>
        /// 获取窗体句柄
        /// </summary>
        public static long GetFormHanldeByControlHanlde(long handle)
        {
            if (!_controls.ContainsKey(handle)) return 0;
            long formHandle = _controls[handle];
            if (formHandle <= 0) return 0;
            return formHandle;
        }

        /// <summary>
        /// 移除窗体
        /// </summary>
        public static void RemoveForm(IForm form)
            => _forms.Remove(form);

        /// <summary>
        /// 获取一个新的句柄
        /// </summary>
        /// <returns></returns>
        public static long GetNewHandle()
        {
            long handle = 0;
            lock (_hanlderLock)
            {
                _hanlder++;
                handle = _hanlder;
            }
            return handle;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        public static bool SendMessage(IMessage msg)
        {
            var formHandle = GetFormHanldeByControlHanlde(msg.Handle);
            var form = GetForm(formHandle);
            return form.SendMessage(msg);
        }

        /// <summary>
        /// 提交消息
        /// </summary>
        public static void PostMessage(IMessage msg)
        {
            switch (msg)
            {
                case CloseMessage closeMessage:

                    break;
            }
            var formHandle = GetFormHanldeByControlHanlde(msg.Handle);
            var form = GetForm(formHandle);
            form.PostMessage(msg);
        }
    }
}
