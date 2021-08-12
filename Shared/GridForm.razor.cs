using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLogin.Shared
{
    public partial class GridForm<TItem> where TItem : class
    {
    }
    public enum GridFormEditMode
    {
        Edit, Create, None
    }

}
