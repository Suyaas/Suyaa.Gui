using Forms.Helpers;
using SkiaSharp;
using Suyaa;
using Suyaa.Gui;
using Suyaa.Gui.Attributes;
using Suyaa.Gui.Controls;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Enums;
using Suyaa.Gui.Forms;
using Suyaa.Gui.Messages;
using Suyaa.Gui.Native.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms
{
    /// <summary>
    /// 窗体
    /// </summary>
    public abstract partial class FormBase : IForm
    {

        // 是否强制刷新
        private bool _refresh;

        /// <summary>
        /// 原生窗体
        /// </summary>
        public INativeForm NativeForm { get; }

        /// <summary>
        /// 窗口句柄
        /// </summary>
        public long Handle => NativeForm.Handle;

        /// <summary>
        /// 样式列表
        /// </summary>
        public StyleCollection Style => NativeForm.Style;

        /// <summary>
        /// 缓存图像
        /// </summary>
        public SKBitmap? CacheBitmap => NativeForm.CacheBitmap;

        /// <summary>
        /// 窗口标题
        /// </summary>
        public string Title { get => this.NativeForm.Title; set => this.NativeForm.Title = value; }

        /// <summary>
        /// 工作区域
        /// </summary>
        public Workarea Workarea { get; }

        /// <summary>
        /// 控件集合
        /// </summary>
        public IControlCollection<IControl> Controls => this.Workarea.Controls;

        /// <summary>
        /// 是否需要重新绘制
        /// </summary>
        public bool IsNeedRepaint
        {
            get => _refresh;
            protected internal set => _refresh = value;
        }

        /// <summary>
        /// 光标
        /// </summary>
        public Cursors Cursor
        {
            get => this.NativeForm.Cursor;
            set => this.NativeForm.Cursor = value;
        }

        /// <summary>
        /// 更改Ime状态
        /// </summary>
        protected void ImeChangeStatus()
        {
            if (this.NativeForm.CurrentControl is null)
            {
                this.SetImeDisabled();
                return;
            }
            if (this.NativeForm.CurrentControl.IsEditable)
            {
                this.SetImeEnable();
            }
            else
            {
                this.SetImeDisabled();
            }
        }

        /// <summary>
        /// 当前控件
        /// </summary>
        public IControl? CurrentControl
        {
            get => this.NativeForm.CurrentControl;
            set
            {
                // 值为空，当前控件不为空，则赋值
                if (value is null)
                {
                    if (this.NativeForm.CurrentControl is not null)
                    {
                        this.NativeForm.CurrentControl = value;
                        this.IsNeedRepaint = true;
                        // 变更Ime状态
                        this.ImeChangeStatus();
                        return;
                    }
                    return;
                }
                // 当前控件为空，无条件变更
                if (this.NativeForm.CurrentControl is null)
                {
                    this.NativeForm.CurrentControl = value;
                    this.IsNeedRepaint = true;
                    // 变更Ime状态
                    this.ImeChangeStatus();
                    return;
                }
                // 判断句柄是否一样，不同时触发变更
                if (this.NativeForm.CurrentControl.Handle != value.Handle)
                {
                    this.NativeForm.CurrentControl = value;
                    this.IsNeedRepaint = true;
                    // 变更Ime状态
                    this.ImeChangeStatus();
                    return;
                }
            }
        }

        /// <summary>
        /// 窗体
        /// </summary>
        /// <param name="nativeForm"></param>
        public FormBase(INativeForm nativeForm)
        {
            // 初始化工作区域
            this.Workarea = new Workarea(this);
            // 设置原生窗体
            NativeForm = nativeForm;
            // 注册窗体
            Application.RegForm(this);
            // 设置Ime不可用
            this.SetImeDisabled();
        }

        /// <summary>
        /// 窗体
        /// </summary>
        public FormBase()
        {
            // 变量初始化
            _refresh = false;
            // 初始化工作区域
            this.Workarea = new Workarea(this);
            // 创建原生窗口
            this.NativeForm = sy.Form.CreateNativeForm();
            // 注册窗体
            Application.RegForm(this);
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected abstract bool OnMessage(IMessage msg);

        /// <summary>
        /// 发送消息
        /// </summary>
        public bool SendMessage(IMessage msg)
        {
            if (msg.Handle == this.Handle)
            {
                return this.OnMessage(msg);
            }
            else
            {
                return this.Workarea.SendMessage(msg);
            }
        }

        /// <summary>
        /// 提交消息
        /// </summary>
        public void PostMessage(IMessage msg)
        {
            if (msg.Handle == this.Handle)
            {
                this.OnMessage(msg);
            }
            else
            {
                this.Workarea.PostMessage(msg);
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        public void Show()
        {
            // 显示
            this.NativeForm.Show();
            // 触发显示事件
            this.OnShow();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            this.NativeForm.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            // 初始化
            this.NativeForm.Initialize();
            // 触发加载事件
            this.OnLoad();
        }

        /// <summary>
        /// 刷新显示
        /// </summary>
        public void Refresh()
        {
            this.NativeForm.Refresh();
        }

        /// <summary>
        /// 获取样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <returns></returns>
        public T GetStyle<T>(Suyaa.Gui.Enums.Styles style)
            => this.Style.Get<T>(style);

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public IWidget UseStyles(Action<Suyaa.Gui.Drawing.StyleCollection> action)
        {
            action(this.Style);
            return this;
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IWidget UseStyles<T>()
        {
            this.Style.SetStyles<T>();
            return this;
        }

        /// <summary>
        /// 界面重绘
        /// </summary>
        /// <param name="force"></param>
        public bool Repaint(bool force)
        {
            if (Application.UpdateFrameTime > 0)
            {
                _refresh = true;
                return true;
            }
            else
            {
                return this.NativeForm.Repaint(force);
            }
        }

        /// <summary>
        /// 获取样式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="style"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetStyle<T>(Suyaa.Gui.Enums.Styles style, T defaultValue)
            => this.Style.Get<T>(style, defaultValue);
    }
}
