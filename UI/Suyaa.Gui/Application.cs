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
        // 应用信息
        private static IApplication? _application;
        // 默认窗体
        private static IForm? _currentForm;
        // 句柄生成器
        private static long _hanlder = 0;
        private static object _hanlderLock = new object();
        // DPI放大比例
        private static float _scale = 1;
        private static bool _scaleble = false;

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
        /// 设置程序是否支持缩放
        /// </summary>
        /// <returns></returns>
        public static void UseScale(bool scaleble)
        {
            _scaleble = scaleble;
        }

        /// <summary>
        /// 设置程序放大比例
        /// </summary>
        /// <returns></returns>
        public static void SetScale(float scale)
        {
            _scale = scale;
        }

        /// <summary>
        /// 获取程序放大比例
        /// </summary>
        /// <returns></returns>
        public static float GetScale()
        {
            if (!_scaleble) return 1;
            return _scale;
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
        /// 注册窗体
        /// </summary>
        /// <param name="form"></param>
        public static void RegForm(IForm form)
        {
            _forms.Add(form);
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
        public static IForm? GetFormByHandle(long handle)
            => _forms.Where(d => d.Handle == handle).FirstOrDefault();

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
            // 分发消息
            foreach (var form in _forms)
            {
                if (!form.SendMessage(msg)) return false;
            }
            return true;
        }

        /// <summary>
        /// 提交消息
        /// </summary>
        public static void PostMessage(IMessage msg)
        {
            switch (msg)
            {
                // 关闭消息
                case CloseMessage _:
                    if (_currentForm is null) throw new GuiException($"No current form found.");
                    if (msg.Handle == _currentForm.Handle)
                    {
                        Environment.Exit(0);
                    }
                    return;
            }
            // 分发消息
            foreach (var form in _forms)
            {
                form.PostMessage(msg);
            }
        }
    }
}
