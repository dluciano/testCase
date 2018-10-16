using System.Collections.Generic;
using System.Threading.Tasks;
using Clay.DAL;

namespace Clay.WebApi.UnitTests
{
    internal class TestUnitOfWork : IUnitOfWork
    {
        public List<Property> Properties { get; } = new List<Property>();
        public List<Lock> Locks { get; } = new List<Lock>();
        public List<CardGroup> CardGroups { get; } = new List<CardGroup>();
        public List<Card> Cards { get; } = new List<Card>();
        public List<LockCard> LockCards { get; } = new List<LockCard>();
        public List<LockEvent> LockEvents { get; } = new List<LockEvent>();
        public List<CardGroupLock> CardGroupLogs { get; } = new List<CardGroupLock>();

        public void SaveChanges()
        {
            //DO Nothihng
        }

        public async Task SaveChangesAsync() =>
            //DO Nothihng
            await Task.CompletedTask;
    }
}