using System.Threading.Tasks;
using Clay.DAL;
using Clay.WebApi;

namespace IdentityServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebApiDbContext dbContext;

        public UnitOfWork(WebApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveChanges() =>
            dbContext.SaveChanges();

        public async Task SaveChangesAsync() =>
            await dbContext.SaveChangesAsync();
    }
}