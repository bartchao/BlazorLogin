using BlazorLogin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorLogin.Service
{
    interface IDataServiceFactory
    {
        DataService<T> Get<T>() where T : class;
    }

    class DataServiceFactory : IDataServiceFactory
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
    interface IDataService<T>
    {
        void Insert(T Entity);
        void Delete(T Entity);
        IQueryable<T> GetAll();
        T Read(Expression<Func<T, bool>> predicate);
        void Update(T Entity);
        void SaveChanges();
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
            return _context.Set<T>().AsQueryable<T>();
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
            _context.SaveChanges();
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
            SaveChanges();
        }
        public T FindByID(T Entity)
        {
            var PK = typeof(T).Name + "Id";
            var id = Entity.GetType().GetProperty(PK).GetValue(Entity);
            var obj = _context.Set<T>().Find(id);
            return obj;
        }

    }
}
