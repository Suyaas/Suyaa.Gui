using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Win32App
{
    /// <summary>
    /// Xlib图标
    /// </summary>
    public class XIcon : IDisposable
    {
        private long[] bytes;

        /// <summary>
        /// 转为数组
        /// </summary>
        /// <returns></returns>
        public long[] ToArray() { return bytes; }

        /// <summary>
        /// 转为内存指针
        /// </summary>
        /// <returns></returns>
        public IntPtr ToIntPtr()
        {
            IntPtr ptr = Marshal.AllocHGlobal(bytes.Length * Marshal.SizeOf<long>());
            Marshal.Copy(bytes, 0, ptr, bytes.Length);
            return ptr;
        }

        /// <summary>
        /// 获取宽度
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// 获取高度
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// 获取存储长度
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Xlib图标
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public XIcon(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Length = width * height + 2;
            bytes = new long[this.Length];
            bytes[0] = width;
            bytes[1] = height;
        }

        /// <summary>
        /// 设置颜色值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixel(int x, int y, long color)
        {
            bytes[y * this.Width + x + 2] = color;
        }

        /// <summary>
        /// 设置颜色值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixel(int x, int y, Color color)
        {
            bytes[y * this.Width + x + 2] = color.ToArgb();
        }

        /// <summary>
        /// 获取颜色值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public Color GetPixel(int x, int y)
        {
            return Color.FromArgb((int)bytes[y * this.Width + x + 2]);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
