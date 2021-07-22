using BlazorLogin.Data;
using BlazorLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLogin.Service
{
    public class MenuTree
    {
        public string Name { get; set; }
        public List<MenuTree> Child { get; set; }
        public MenuTree(string name="Root")
        {
            Name = name;
            Child = new List<MenuTree>();
        }
    }
    
    public class NavMenuBuilder
    {
        private readonly TEMPLATE20Context _context;
        public NavMenuBuilder(TEMPLATE20Context context)
        {
            _context = context;
        }
        public MenuTree GetNavLinks()
        {
            MenuTree menuTree = new MenuTree();
            var func = from f in _context.Function select f.FunctionNo;
            var funcList = new List<string>();
            foreach (var f in func)
            {
                if (f.Contains('*') == true)
                    continue;
                var tmps = f.Split('/').ToList();
                tmps = tmps.Take(tmps.Count - 1).ToList();
                TreeToList(menuTree, tmps);
            }
            return menuTree;

        }

        private void TreeToList(MenuTree parent, List<string> tmps)
        {
            MenuTree find = parent.Child.FirstOrDefault(x => x.Name == tmps[0]);
            if (find == null)
            {
                MenuTree tree1 = new MenuTree() { Name = tmps[0] };
                tree1.Child = new List<MenuTree>();
                find = tree1;
                parent.Child.Add(find);
            }
            tmps.RemoveAt(0);
            if (tmps.Count == 0)
                return;
            TreeToList(find, tmps);
        }


       
        
    }
}
