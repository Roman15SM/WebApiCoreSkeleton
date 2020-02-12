using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApiCore.Repositories.Interfaces
{
    interface IRepository<TEntity> where TEntity : new()
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Edit(TEntity entity);

        void Save();
    }
}
