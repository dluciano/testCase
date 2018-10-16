using System.Threading.Tasks;
using Clay.DAL;

namespace Clay.WebApi.UnitTests
{
    internal class TestUnitOfWork : IUnitOfWork
    {
        public TestUnitOfWork()
        {
        }

        public void SaveChanges()
        {
            //DO Nothihng
        }

        public async Task SaveChangesAsync() =>
            //DO Nothihng
            await Task.CompletedTask;
    }
}