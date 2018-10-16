using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Clay.Entities;
using Clay.WebApi;
using Microsoft.EntityFrameworkCore;

namespace Clay.DAL
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly ISecurityService _securityService;

        public Repository(DbContext dbContext,
            ISecurityService securityService)
        {
            DbContext = dbContext;
            Set = DbContext.Set<TEntity>();
            QueryableSet = Set.AsQueryable();
            _securityService = securityService;
        }

        private DbContext DbContext { get; }
        private DbSet<TEntity> Set { get; }
        private IQueryable<TEntity> QueryableSet { get; }

        public Type ElementType => QueryableSet.ElementType;

        public Expression Expression => QueryableSet.Expression;

        public IQueryProvider Provider => QueryableSet.Provider;

        public void Add(TEntity entity)
        {
            Audit(entity);
            Set.Add(entity);
        }

        private void Audit(TEntity entity)
        {
            (entity as IAuditable).Audit = new Audit
            {
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
                CreatedBy = _securityService.LogedUserName,
                LastUpdatedBy = _securityService.LogedUserName
            };
        }

        public async Task AddAsync(TEntity entity)
        {
            Audit(entity);
            await Set.AddAsync(entity);
        }

        public async Task AddRangeAsync(params TEntity[] entity) =>
            await Set.AddRangeAsync(entity);

        public IEnumerator<TEntity> GetEnumerator() =>
            Set.AsQueryable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        public IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            var include = Set.Include(expression);
            return include.AsQueryable();
        }
    }
}