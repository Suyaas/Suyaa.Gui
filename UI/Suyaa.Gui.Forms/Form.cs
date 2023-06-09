using Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Forms
{
    /// <summary>
    /// 指定的原生窗体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Form<T> : FormBase
        where T : INativeForm, new()
    {
        /// <summary>
        /// 窗体
        /// </summary>
        public Form() : base(typeof(T)) { }
    }

    /// <summary>
    /// 标准窗体
    /// </summary>
    public class Form : FormBase
    {
        /// <summary>
        /// 标准窗体
        /// </summary>
        public Form() : base(sy.Gui.GetNativeFormType()) { }
    }
}
