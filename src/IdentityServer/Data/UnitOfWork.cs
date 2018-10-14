using System.Threading.Tasks;
using Clay.DAL;
using IdentityServer4.EntityFramework.DbContexts;

namespace IdentityServer
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext appDbContext,
            ConfigurationDbContext configurationDbContext)
        {
            AppDbContext = appDbContext;
            ConfigurationDbContext = configurationDbContext;
        }

        private ApplicationDbContext AppDbContext { get; }
        private ConfigurationDbContext ConfigurationDbContext { get; }

        public void SaveChanges()
        {
            AppDbContext.SaveChanges();
            ConfigurationDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await AppDbContext.SaveChangesAsync();
            await ConfigurationDbContext.SaveChangesAsync();
        }
    }
}