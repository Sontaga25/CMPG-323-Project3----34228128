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

        //This method removes the a specific intity class with the id parsed after the delete is confirmed 
        public void DeleteConfirmed(Guid id)
        {
            var entity = GetById(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }
    // This method checks if an entity instance exists, removes the reptition of code in all the controllers

        public bool Object_Exists(Guid id )
        {
            var search_object = GetById(id);
            if (search_object != null)
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
        //This method returns the dataset of the specified class 'Z' that is parsed. This method is used in the controllers to generate views
        public IEnumerable<Z> GetSet<Z>() where Z : class
        {
            return _context.Set<Z>().ToList();

        }    

        
    }
}
