using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Clay.DAL
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            Set = DbContext.Set<TEntity>();
            QueryableSet = Set.AsQueryable();
        }

        private DbContext DbContext { get; }
        private DbSet<TEntity> Set { get; }
        private IQueryable<TEntity> QueryableSet { get; }

        public Type ElementType => QueryableSet.ElementType;

        public Expression Expression => QueryableSet.Expression;

        public IQueryProvider Provider => QueryableSet.Provider;

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public async Task AddRangeAsync(params TEntity[] entity)
        {
            await Set.AddRangeAsync(entity);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return Set.AsQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}