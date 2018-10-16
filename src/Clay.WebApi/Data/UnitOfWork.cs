using System.Threading.Tasks;
using Clay.DAL;
using Clay.WebApi;
using Microsoft.EntityFrameworkCore;

namespace Clay.WebApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveChanges() =>
            dbContext.SaveChanges();

        public async Task SaveChangesAsync() =>
            await dbContext.SaveChangesAsync();
    }
}