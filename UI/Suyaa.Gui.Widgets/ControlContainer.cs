using System.Collections;

namespace Suyaa.Gui.Controls
{
    /// <summary>
    /// 控件容器
    /// </summary>
    public class ControlContainer : IControlContainer<Control>
    {
        // 控件集合
        private readonly List<Control> _controls;
        // 父控件
        private readonly Control _parent;

        /// <summary>
        /// 控件容器
        /// </summary>
        /// <param name="control"></param>
        public ControlContainer(Control control)
        {
            _parent = control;
            _controls = new List<Control>();
        }

        /// <summary>
        /// 获取或设置控件
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Control this[int index] { get => _controls[index]; set => _controls[index] = value; }

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
        public void Add(Control control)
        {
            _controls.Add(control);
            control.Parent = _parent;
        }

        /// <summary>
        /// 批量添加控件
        /// </summary>
        /// <param name="controls"></param>
        public void AddRange(params Control[] controls)
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
        public bool Contains(Control control)
            => _controls.Contains(control);

        /// <summary>
        /// 复制到数组
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(Control[] array, int arrayIndex)
            => _controls.CopyTo(array, arrayIndex);

        /// <summary>
        /// 获取枚举器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Control> GetEnumerator()
            => _controls.GetEnumerator();

        /// <summary>
        /// 获取索引
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public int IndexOf(Control control)
            => _controls.IndexOf(control);

        /// <summary>
        /// 插入一个控件
        /// </summary>
        /// <param name="index"></param>
        /// <param name="control"></param>
        public void Insert(int index, Control control)
        {
            _controls.Insert(index, control);
            control.Parent = _parent;
        }

        /// <summary>
        /// 移除控件
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool Remove(Control control)
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
