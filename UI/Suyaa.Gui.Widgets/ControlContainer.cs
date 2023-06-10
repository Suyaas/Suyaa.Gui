using System.Collections;

namespace Suyaa.Gui.Controls
{
    /// <summary>
    /// 控件容器
    /// </summary>
    public class ControlContainer : IControlCollection<IControl>
    {
        // 控件集合
        private readonly List<IControl> _controls;
        // 父控件
        private readonly IContainerControl _parent;

        /// <summary>
        /// 控件容器
        /// </summary>
        /// <param name="control"></param>
        public ControlContainer(IContainerControl control)
        {
            _parent = control;
            _controls = new List<IControl>();
        }

        /// <summary>
        /// 获取或设置控件
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IControl this[int index] { get => _controls[index]; set => _controls[index] = value; }

        /// <summary>
        /// 获取控件数量
        /// </summary>
        public int Count => _controls.Count;

        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="control"></param>
        public void Add(IControl control)
        {
            _controls.Add(control);
            ((Control)control).Parent = _parent;
        }

        /// <summary>
        /// 批量添加控件
        /// </summary>
        /// <param name="controls"></param>
        public void AddRange(params IControl[] controls)
        {
            foreach (var control in controls) Add(control);
        }

        /// <summary>
        /// 清理控件
        /// </summary>
        public void Clear()
            => _controls.Clear();

        /// <summary>
        /// 判断控件是否存在
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool Contains(IControl control)
            => _controls.Contains(control);

        /// <summary>
        /// 复制到数组
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(IControl[] array, int arrayIndex)
            => _controls.CopyTo(array, arrayIndex);

        /// <summary>
        /// 获取枚举器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IControl> GetEnumerator()
            => _controls.GetEnumerator();

        /// <summary>
        /// 获取索引
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public int IndexOf(IControl control)
            => _controls.IndexOf(control);

        /// <summary>
        /// 插入一个控件
        /// </summary>
        /// <param name="index"></param>
        /// <param name="control"></param>
        public void Insert(int index, IControl control)
        {
            _controls.Insert(index, control);
            ((Control)control).Parent = _parent;
        }

        /// <summary>
        /// 移除控件
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool Remove(IControl control)
            => _controls.Remove(control);

        /// <summary>
        /// 移除控件
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
            => _controls.RemoveAt(index);

        /// <summary>
        /// 获取枚举器
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
            => _controls.GetEnumerator();
    }
}
