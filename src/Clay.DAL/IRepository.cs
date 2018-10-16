using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clay.DAL
{
    public interface IRepository<TEntity> :
        IQueryable<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(params TEntity[] entity);
        IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> expression);
    }
}