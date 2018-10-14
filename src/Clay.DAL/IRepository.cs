using System.Linq;
using System.Threading.Tasks;

namespace Clay.DAL
{
    public interface IRepository<TEntity> :
        IQueryable<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);
        Task AddRangeAsync(params TEntity[] entity);
    }
}