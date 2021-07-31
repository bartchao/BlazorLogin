using BlazorLogin.Data;
using BlazorLogin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLogin.Service
{
    public class FunctionService
    {
        private readonly TEMPLATE20Context _context;
        public FunctionService(TEMPLATE20Context context)
        {
            _context = context;
        }
        public List<Function> Get()
        {
            var list = _context.Function.AsNoTracking().ToList();
            return list;
        }
        public void Delete(Function function)
        {
            var original = _context.Function.FirstOrDefault(x => x.FunctionId == function.FunctionId);
            _context.Function.Remove(original);
            SaveChanges();
        }
        public void Update(Function function)
        {
            var original = _context.Function.FirstOrDefault(x => x.FunctionId == function.FunctionId);
            original.FunctionNo = function.FunctionNo;
            original.Description = function.Description;
            original.SecurityGroupId = function.SecurityGroupId;
            original.SysState = function.SysState;
                
            _context.Function.Update(original);
            SaveChanges();
        }
        public void Insert(Function function)
        {
            _context.Function.Add(function);
            SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
