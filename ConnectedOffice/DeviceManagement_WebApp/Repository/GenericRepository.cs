using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Data;
using DeviceManagement_WebApp.Data;
using System.Linq;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConnectedOfficeContext _context;
        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);

            _context.SaveChangesAsync();
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void DeleteConfirmed(Guid id)
        {
            var entity = GetById(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public bool Object_Exists(Guid id)
        {
            var Search_object = _context.Zone.Any(e => e.ZoneId == id); 
            if (Search_object != null)
                return true;
            else
                return false;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(Guid? id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();

        }

        
    }
}
