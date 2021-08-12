using BlazorLogin.Data;
using BlazorLogin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorLogin.Service
{
    public class PropertyList<TItem> where TItem : class
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public List<GridViewModel<TItem>> GetColumn()
        {
            var list = typeof(TItem).GetProperties().Where(p => p.GetMethod.IsVirtual == false && p.GetType().IsInterface == false).ToList();
            var ignore = typeof(TItem).GetProperty("SysState");
            var ignore1 = typeof(TItem).GetProperty("SecurityGroupId");
            var ignore2 = typeof(TItem).GetProperty("TransactionId");
            var ignorePK = typeof(TItem).GetProperty(typeof(TItem).Name + "Id");
            list.Remove(ignore);
            list.Remove(ignore1);
            list.Remove(ignore2);
            list.Remove(ignorePK);
            var returnList = new List<GridViewModel<TItem>>();
            foreach (var item in list)
            {
                var model = new GridViewModel<TItem>
                {
                    Column = item
                };
                if (IsNullable(item.DeclaringType) == false)
                    model.AllowNull = false;
                if (item.Name.EndsWith("Id"))
                {
                    //Has ForeignKey
                    var fkcolumn = GetFKColumn(item.Name);
                    if (fkcolumn != null)
                        model.ForeignKey = fkcolumn;
                }
                returnList.Add(model);
            }

            return returnList;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        private PropertyInfo GetFKColumn(string column)
        {
            string search = column.Substring(0, column.Length - 2);
            var fkcolumn = typeof(TItem).GetProperties().Where(p => p.GetMethod.IsVirtual == true && p.PropertyType.IsGenericType == false).Where(x => x.Name == search).First();

            return fkcolumn;
        }
        bool IsNullable(Type type) => Nullable.GetUnderlyingType(type) != null;
        
    }
    public class GridViewModel<T> where T : class
    {
        public PropertyInfo Column { get; set; }
        public bool Viewable { get; set; } = true;
        public bool EditableOnUpdate { get; set; } = true;
        public bool ViewableOnUpdate { get; set; } = true;
        public bool ViewableOnCreate { get; set; } = true;
        public bool EditableOnCreate { get; set; } = true;

        public bool AllowNull { get; set; } = true;
        public PropertyInfo? ForeignKey { get; set; }
    }

}
