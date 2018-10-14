using System;
using System.Linq;
using System.Threading.Tasks;
using Clay.DAL;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Mappers;

namespace IdentityServer
{
    public class Seed : ISeed
    {
        public Seed(IRepository<Client> clientsRepo,
            IRepository<ApiResource> apiResourceRepo,
            IRepository<IdentityResource> identityResourceRepo,
            ConfigurationDbContext configurationDbContext,
            PersistedGrantDbContext persistedGrantDbContext,
            ApplicationDbContext applicationDbContext,
            IUnitOfWork uof)
        {
            ClientsRepo = clientsRepo;
            ApiResourceRepo = apiResourceRepo;
            IdentityResourceRepo = identityResourceRepo;
            ConfigurationDbContext = configurationDbContext;
            PersistedGrantDbContext = persistedGrantDbContext;
            ApplicationDbContext = applicationDbContext;
            UnitOfWork = uof;
        }

        private IRepository<Client> ClientsRepo { get; }
        private IRepository<ApiResource> ApiResourceRepo { get; }
        private IRepository<IdentityResource> IdentityResourceRepo { get; }
        private ConfigurationDbContext ConfigurationDbContext { get; }
        private ApplicationDbContext ApplicationDbContext { get; }
        private PersistedGrantDbContext PersistedGrantDbContext { get; }
        private IUnitOfWork UnitOfWork { get; }

        public async Task EnsureSeedDataAsync()
        {
            Console.WriteLine("Seeding database...");
            await EnsureSeedData();
            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }

        private async Task EnsureSeedData()
        {
            if (!ClientsRepo.Any())
            {
                Console.WriteLine("Clients being populated");
                await ClientsRepo.AddRangeAsync(ClientsRepo.InitialEntities().Select(c => c.ToEntity()).ToArray());
            }
            else
            {
                Console.WriteLine("Clients already populated");
            }

            if (!IdentityResourceRepo.Any())
            {
                Console.WriteLine("IdentityResources being populated");
                await IdentityResourceRepo.AddRangeAsync(IdentityResourceRepo.InitialEntities()
                    .Select(c => c.ToEntity()).ToArray());
            }
            else
            {
                Console.WriteLine("IdentityResources already populated");
            }

            if (!ApiResourceRepo.Any())
            {
                Console.WriteLine("ApiResources being populated");
                await ApiResourceRepo.AddRangeAsync(ApiResourceRepo.InitialEntities().Select(c => c.ToEntity())
                    .ToArray());
            }
            else
            {
                Console.WriteLine("ApiResources already populated");
            }

            //TODO: Async stop unexpectely
            UnitOfWork.SaveChanges();
        }
    }
}