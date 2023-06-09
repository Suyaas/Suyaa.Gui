using Forms.Helpers;
using SkiaSharp;
using Suyaa;
using Suyaa.Gui;
using Suyaa.Gui.Controls;
using Suyaa.Gui.Drawing;
using Suyaa.Gui.Forms;
using Suyaa.Gui.Messages;
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
    public abstract partial class FormBase : IForm<Control>
    {
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
        public Styles Styles => NativeForm.Styles;

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
        public IControlContainer<Control> Controls => this.Workarea.Controls;

        /// <summary>
        /// 窗体
        /// </summary>
        /// <param name="nativeForm"></param>
        public FormBase(INativeForm nativeForm)
        {
            // 设置原生窗体
            NativeForm = nativeForm;
            // 注册窗体
            Application.RegForm(this);
            // 初始化工作区域
            this.Workarea = new Workarea(this);
            // 应用反射特性
        }

        /// <summary>
        /// 窗体
        /// </summary>
        /// <param name="type"></param>
        public FormBase(Type type)
        {
            // 创建原生窗口
            this.NativeForm = type.CreateNativeForm();
            // 注册窗体
            Application.RegForm(this);
            // 初始化工作区域
            this.Workarea = new Workarea(this);
        }

        // 处理消息
        private bool MessageProc(IMessage msg)
        {
            // 处理消息
            switch (msg)
            {
                case PaintMessage pm: // 处理绘制命令
                    // 重绘界面
                    this.RePaint(pm.Canvas);
                    break;
            }
            return true;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        public bool SendMessage(IMessage msg)
        {
            return MessageProc(msg);
        }

        /// <summary>
        /// 提交消息
        /// </summary>
        public void PostMessage(IMessage msg)
        {
            MessageProc(msg);
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
    }
}
