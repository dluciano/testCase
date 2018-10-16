using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Clay.WebApi
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0))")]
    public interface ILockServices
    {
        /// <summary>Get all information about a specific lock</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Ok</returns>
        Task<ObservableCollection<Lock>> GetLockByIdAsync(long lockId, CancellationToken cancellationToken);

        /// <summary>Get all events for a specific lock</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Ok</returns>
        Task<ObservableCollection<LockEvent>> GetEventsOfLockIdAsync(long lockId, CancellationToken cancellationToken);

        /// <summary>Add an event related to a lock</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Event registererd successfully</returns>
        Task AddEventsOfLockIdAsync(long lockId, object body, CancellationToken cancellationToken);

        /// <summary>Get all cards with permission</summary>
        /// <param name="lockId">ID of the lock</param>
        /// <returns>Ok</returns>
        Task<ObservableCollection<Card>> GetCardsOfLockIdAsync(long lockId, CancellationToken cancellationToken);

        /// <summary>Grant permission to a card</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Card permission granted</returns>
        Task<LockCard> AddCardToLockIdAsync(long lockId, object body, CancellationToken cancellationToken);

        /// <summary>Get all cards groups with permission</summary>
        /// <param name="lockId">ID of the lock</param>
        /// <returns>Ok</returns>
        Task<ObservableCollection<CardGroup>> GetLockCardGroupsAsync(long lockId, CancellationToken cancellationToken);

        /// <summary>Grant permission to a card group</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Card permission granted</returns>
        Task<CardGroupLock> AddCardgroupToLockAsync(long lockId, object body, CancellationToken cancellationToken);

        /// <summary>Revoke permission to cards</summary>
        /// <param name="lockId">ID of lock</param>
        /// <param name="cardId">Card id to revoke permission</param>
        /// <returns>Card permission revoked successfully</returns>
        Task RemoveCardLockPermissionAsync(long lockId, System.Collections.Generic.IEnumerable<long> cardId, CancellationToken cancellationToken);

        /// <summary>Revoke permission to card groups</summary>
        /// <param name="lockId">ID of lock</param>
        /// <param name="cardGroupId">Card Group ids to revoke permission</param>
        /// <returns>Card group permission revoked successfully</returns>
        Task RemoveCardGroupLockPermissionAsync(long lockId, System.Collections.Generic.IEnumerable<long> cardGroupId, CancellationToken cancellationToken);

        /// <summary>Execute a command on a lock</summary>
        /// <param name="id">ID of lock</param>
        /// <param name="commandId">ID of the command</param>
        /// <param name="cardId">ID of the card that wants to execute the command. If this command is run by an user then the cardId will be null and the userId will be in the Audit information</param>
        /// <returns>Lock command executed successfully</returns>
        Task ExecuteCommandsForLockIdAsync(long id, long commandId, long? cardId, CancellationToken cancellationToken);

    }
}