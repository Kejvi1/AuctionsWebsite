using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        internal DbSet<T> dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity, params Expression<Func<T, object>>[] propsToUpdate)
        {
            dbSet.Attach(entity);
            var entry = _context.Entry(entity);

            foreach (var prop in propsToUpdate)
                entry.Property(prop).IsModified = true;
        }

        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}