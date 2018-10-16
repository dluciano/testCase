using System.Collections.Generic;
using System.Threading.Tasks;
using Clay.DAL;

namespace Clay.WebApi.UnitTests
{
    internal class TestUnitOfWork : IUnitOfWork
    {
        public TestUnitOfWork()
        {
        }

        public List<Property> Properties { get; } = new List<Property>();
        public List<Lock> Locks { get; } = new List<Lock>();
        public List<CardGroup> CardGroups { get; } = new List<CardGroup>();

        public void SaveChanges()
        {
            //DO Nothihng
        }

        public async Task SaveChangesAsync() =>
            //DO Nothihng
            await Task.CompletedTask;
    }
}