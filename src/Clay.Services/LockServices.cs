using Clay.WebApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clay.Services
{
    public class LockServices : ILockServices
    {
        public Task<CardGroupLock> AddCardgroupToLockAsync(long lockId, object body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<LockCard> AddCardToLockIdAsync(long lockId, object body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddEventsOfLockIdAsync(long lockId, object body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteCommandsForLockIdAsync(long id, long commandId, long? cardId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Card>> GetCardsOfLockIdAsync(long lockId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<LockEvent>> GetEventsOfLockIdAsync(long lockId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Lock>> GetLockByIdAsync(long lockId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<CardGroup>> GetLockCardGroupsAsync(long lockId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCardGroupLockPermissionAsync(long lockId, IEnumerable<long> cardGroupId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCardLockPermissionAsync(long lockId, IEnumerable<long> cardId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
