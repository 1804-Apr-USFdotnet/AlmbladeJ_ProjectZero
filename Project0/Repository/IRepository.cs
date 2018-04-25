using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        List<TEntity> GetAll();
        List<TEntity> Find(Predicate<TEntity> predicate);

        void Remove(TEntity entity);
        void RemoveRange(int indexAt, int number);
    }
}
