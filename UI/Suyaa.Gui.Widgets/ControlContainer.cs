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
        /// 清理控件
        /// </summary>
        public void Clear()
            => _controls.Clear();

        public bool Contains(Control item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Control[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Control> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(Control item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Control item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Control item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
