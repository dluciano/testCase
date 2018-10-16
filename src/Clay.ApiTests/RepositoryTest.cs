using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Clay.DAL;

namespace Clay.WebApi.UnitTests
{
    internal class RepositoryTest<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly List<TEntity> _dataset;
        private IQueryable<TEntity> _datasetAsQueryable { get; }

        public RepositoryTest(List<TEntity> dataset)
        {
            _dataset = dataset ?? new List<TEntity>();
            _datasetAsQueryable = _dataset.AsQueryable();
        }

        public Type ElementType => _datasetAsQueryable.ElementType;

        public Expression Expression => _datasetAsQueryable.Expression;

        public IQueryProvider Provider => _datasetAsQueryable.Provider;

        public void Add(TEntity entity) =>
            _dataset.Add(entity);

        public async Task AddAsync(TEntity entity)
        {
            _dataset.Add(entity);
            await Task.CompletedTask;
        }

        public async Task AddRangeAsync(params TEntity[] entity)
        {
            _dataset.AddRange(entity);
            await Task.CompletedTask;
        }

        public IEnumerator<TEntity> GetEnumerator() =>
            _dataset.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }
}