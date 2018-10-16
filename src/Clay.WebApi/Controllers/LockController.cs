using Microsoft.AspNetCore.Mvc;

namespace Clay.WebApi
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0))")]
    [Route("api/[controller]")]
    public class LockController : ControllerBase
    {
        private ILockController _implementation;

        public LockController(ILockController implementation)
        {
            _implementation = implementation;
        }
        /// <summary>Get all information about a specific lock</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("lock/{lockId}")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Lock>> GetLockById(long lockId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.GetLockByIdAsync(lockId, cancellationToken);
        }

        /// <summary>Get all events for a specific lock</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("lock/{lockId}/event")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LockEvent>> GetEventsOfLockId(long lockId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.GetEventsOfLockIdAsync(lockId, cancellationToken);
        }

        /// <summary>Add an event related to a lock</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Event registererd successfully</returns>
        [HttpPost, Route("lock/{lockId}/event")]
        public System.Threading.Tasks.Task AddEventsOfLockId(long lockId, [FromBody] object body, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.AddEventsOfLockIdAsync(lockId, body, cancellationToken);
        }

        /// <summary>Get all cards with permission</summary>
        /// <param name="lockId">ID of the lock</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("lock/{lockId}/card")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Card>> GetCardsOfLockId(long lockId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.GetCardsOfLockIdAsync(lockId, cancellationToken);
        }

        /// <summary>Grant permission to a card</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Card permission granted</returns>
        [HttpPost, Route("lock/{lockId}/card")]
        public System.Threading.Tasks.Task<LockCard> AddCardToLockId(long lockId, [FromBody] object body, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.AddCardToLockIdAsync(lockId, body, cancellationToken);
        }

        /// <summary>Get all cards groups with permission</summary>
        /// <param name="lockId">ID of the lock</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("lock/{lockId}/cardGroups")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CardGroup>> GetLockCardGroups(long lockId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.GetLockCardGroupsAsync(lockId, cancellationToken);
        }

        /// <summary>Grant permission to a card group</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Card permission granted</returns>
        [HttpPost, Route("lock/{lockId}/cardGroups")]
        public System.Threading.Tasks.Task<CardGroupLock> AddCardgroupToLock(long lockId, [FromBody] object body, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.AddCardgroupToLockAsync(lockId, body, cancellationToken);
        }

        /// <summary>Revoke permission to cards</summary>
        /// <param name="lockId">ID of lock</param>
        /// <param name="cardId">Card id to revoke permission</param>
        /// <returns>Card permission revoked successfully</returns>
        [HttpDelete, Route("lock/{lockId}/card/{cardId}")]
        public System.Threading.Tasks.Task RemoveCardLockPermission(long lockId, System.Collections.Generic.IEnumerable<long> cardId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.RemoveCardLockPermissionAsync(lockId, cardId, cancellationToken);
        }

        /// <summary>Revoke permission to card groups</summary>
        /// <param name="lockId">ID of lock</param>
        /// <param name="cardGroupId">Card Group ids to revoke permission</param>
        /// <returns>Card group permission revoked successfully</returns>
        [HttpDelete, Route("lock/{lockId}/cardGroup/{cardGroupId}")]
        public System.Threading.Tasks.Task RemoveCardGroupLockPermission(long lockId, System.Collections.Generic.IEnumerable<long> cardGroupId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.RemoveCardGroupLockPermissionAsync(lockId, cardGroupId, cancellationToken);
        }

        /// <summary>Execute a command on a lock</summary>
        /// <param name="id">ID of lock</param>
        /// <param name="commandId">ID of the command</param>
        /// <param name="cardId">ID of the card that wants to execute the command. If this command is run by an user then the cardId will be null and the userId will be in the Audit information</param>
        /// <returns>Lock command executed successfully</returns>
        [HttpPost, Route("lock/{id}/command")]
        public System.Threading.Tasks.Task ExecuteCommandsForLockId(long id, long commandId, long? cardId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.ExecuteCommandsForLockIdAsync(id, commandId, cardId, cancellationToken);
        }

    }
}