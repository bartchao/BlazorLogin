using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLogin.Shared
{
    public partial class GridForm<TItem> where TItem : class
    {
        private static TItem CloneObject(TItem obj)
        {
            if (obj == null) return null;
            System.Reflection.MethodInfo inst = obj.GetType().GetMethod("MemberwiseClone",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (inst != null)
                return (TItem)inst.Invoke(obj, null);
            else
                return null;
        }
    }
    public enum GridFormEditMode
    {
        Edit, Create, None
    }

}
