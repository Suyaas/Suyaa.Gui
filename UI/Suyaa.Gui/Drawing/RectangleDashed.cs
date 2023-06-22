using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Drawing
{
    /// <summary>
    /// 矩形虚线描述
    /// </summary>
    public struct RectangleDashed
    {
        /// <summary>
        /// 开始标识
        /// </summary>
        public readonly float Start;
        /// <summary>
        /// 开始到结束的距离
        /// </summary>
        public readonly float Distance;
        /// <summary>
        /// 实线长度
        /// </summary>
        public readonly int Solid;
        /// <summary>
        /// 空白长度
        /// </summary>
        public readonly int Space;

        // 线段长度
        public int Length => this.Solid + this.Space;
        // 开始标识
        public float End => this.Start + this.Distance;
        // 初始偏移量
        public float Offset => this.GetOffset();

        /// <summary>
        /// 矩形虚线描述
        /// </summary>
        public RectangleDashed()
        {
            Start = 0;
            Distance = 0;
            Solid = 0;
            Space = 0;
        }

        /// <summary>
        /// 矩形虚线描述
        /// </summary>
        public RectangleDashed(float start, float dist, int solid, int space)
        {
            Start = start;
            Distance = dist;
            Solid = solid;
            Space = space;
        }

        /// <summary>
        /// 获取偏移量
        /// </summary>
        /// <returns></returns>
        public float GetOffset(float adjust = 0)
        {
            // 计算绘制偏移和绘制长度
            var offset = (this.Start + adjust) % this.Length;
            if (offset < this.Solid)
            {
                offset = 0 - offset;
            }
            else
            {
                offset = this.Length - offset;
            }
            return offset;
        }
    }
}
