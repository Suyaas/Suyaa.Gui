using Suyaa;
using Suyaa.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Helpers
{
    /// <summary>
    /// 类型助手
    /// </summary>
    public static class TypeHelper
    {
        /// <summary>
        /// 创建原生窗体对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static INativeForm CreateNativeForm(this Type type)
        {
            if (!type.HasInterface<INativeForm>()) throw new GuiException("Interface 'INativeForm' not implemented.");
            var obj = type.Create();
            if (obj is null) throw new GuiException($"Type '{type.FullName}' instance fail.");
            return (INativeForm)obj;
        }
    }
}
