using BlazorLogin.Data;
using BlazorLogin.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorLogin.Service
{
    public class ForeignKeyModel
    {
        public long Id { get; set; }
        public string Text { get; set; }
    }
    public interface IDataServiceFactory
    {
        public DataService<T> Get<T>() where T : class;
    }

    public class DataServiceFactory : IDataServiceFactory
    {
        private readonly TEMPLATE20Context _context;
        public DataServiceFactory(TEMPLATE20Context context)
        {
            _context = context;
        }
        public DataService<T> Get<T>() where T:class
        {
            //.. your own logic of creating DataService
            return new DataService<T>(_context);
        }
    }
    public interface IDataService<T>
    {
        void Insert(T Entity);
        void Delete(T Entity);
        IQueryable<T> GetAll();
        T Read(Expression<Func<T, bool>> predicate);
        void Update(T Entity);
        void SaveChanges();
        IList<ForeignKeyModel> GetForeignKeys();
    }
    public class DataService<T>: IDataService<T> where T:class
    {
        private readonly TEMPLATE20Context _context;
        public DataService(TEMPLATE20Context context)
        {
            _context = context;
        }

        public void Delete(T Entity)
        {
            var obj = FindByID(Entity);
            _context.Set<T>().Remove(obj);
            SaveChanges();
        }


        public IQueryable<T> GetAll()
        {
            var set = _context.Set<T>();
            return set.AsQueryable().AsNoTracking();
        }


        public void Insert(T Entity)
        {
            _context.Set<T>().Add(Entity);
            SaveChanges();
        }

        public T Read(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public void SaveChanges()
        {
            Console.WriteLine(_context.SaveChanges());
            //_context.SaveChanges();
        }

        public void Update(T Entity)
        {
            var PK = typeof(T).Name + "Id";
            var obj = FindByID(Entity);
            var t = Entity.GetType();
            foreach (var propInfo in t.GetProperties())
            {
                if(propInfo.Name == PK)
                {
                    continue;
                }
                var set = propInfo.GetValue(Entity);
                propInfo.SetValue(obj, set, null);
            }
            try
            {
                //_context.Set<T>().Update(Entity);
                SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            
        }
        public T FindByID(T Entity)
        {
            var PK = typeof(T).Name + "Id";
            var id = Entity.GetType().GetProperty(PK).GetValue(Entity);
            var obj = _context.Set<T>().Find(id);
            return obj;
        }

        public IList<ForeignKeyModel> GetForeignKeys()
        {
            var list = new List<ForeignKeyModel>();
            var data = this.GetAll();
            var classname = typeof(T).Name;
            foreach (var item in data)
            {
                var model = new ForeignKeyModel
                {
                    Id = (long)typeof(T).GetProperty(classname + "Id").GetValue(item),
                    Text = (string)typeof(T).GetProperty(classname + "No").GetValue(item)
                };
                list.Add(model);
            }
            return list;
        }
    }
}
