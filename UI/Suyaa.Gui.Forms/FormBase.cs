using Forms.Helpers;
using SkiaSharp;
using Suyaa;
using Suyaa.Gui;
using Suyaa.Gui.Attributes;
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
    public abstract partial class FormBase : IForm
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
        public IControlCollection<IControl> Controls => this.Workarea.Controls;

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
        }

        /// <summary>
        /// 窗体
        /// </summary>
        public FormBase()
        {
            // 初始化工作区域
            this.Workarea = new Workarea(this);
            // 创建原生窗口
            this.NativeForm = sy.Gui.CreateNativeForm();
            // 注册窗体
            Application.RegForm(this);
        }

        // 处理消息
        private bool MessageProc(IMessage msg)
        {
            // 处理消息
            switch (msg)
            {
                // 初始化
                case InitMessage _:
                    this.Workarea.Resize();
                    break;
                // 绘制
                case PaintMessage pm:
                    // 重绘工作区域
                    using (PaintMessage msgSink = new(this.Workarea.Handle, pm.Canvas, pm.Rectangle))
                    {
                        this.Workarea.PostMessage(msgSink);
                    }
                    break;
            }
            return true;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        public bool SendMessage(IMessage msg)
        {
            if (msg.Handle == this.Handle)
            {
                return MessageProc(msg);
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
                MessageProc(msg);
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
            => this.NativeForm.Refresh();
    }
}
