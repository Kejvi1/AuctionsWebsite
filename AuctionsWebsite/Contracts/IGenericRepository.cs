using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        void Add(T entity);

        void Update(T entity, params Expression<Func<T, object>>[] propsToUpdate);

        void Remove(T entity);
    }
}