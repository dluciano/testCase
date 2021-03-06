﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Clay.WebApi
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0))")]
    [Route("api/[controller]")]
    [ApiController]
    public class LockController : ClayBaseController
    {
        private ILockServices _implementation;

        public LockController(ILockServices implementation)
        {
            _implementation = implementation;
        }
        /// <summary>Get all information about a specific lock</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("{lockId}")]
        public Task<ObservableCollection<Lock>> GetLockById(long lockId, CancellationToken cancellationToken)
        {
            return _implementation.GetLockByIdAsync(lockId, cancellationToken);
        }

        /// <summary>Get all events for a specific lock</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("{lockId}/event")]
        public async Task<IActionResult> GetEventsOfLockId(int? lockId, CancellationToken cancellationToken)
        {
            //Validate the request
            if (lockId == null)
            {
                ModelState.AddModelError("lockId", "The lockId cannot be null");
                return BadRequest(ModelState);
            }
            var result = await _implementation
                .GetEventsOfLockIdAsync(lockId.Value, cancellationToken);
            return RenderResult(result);
        }

        /// <summary>Add an event related to a lock</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Event registererd successfully</returns>
        [HttpPost, Route("{lockId}/event")]
        public Task AddEventsOfLockId(long lockId, [FromBody] object body, CancellationToken cancellationToken)
        {
            return _implementation.AddEventsOfLockIdAsync(lockId, body, cancellationToken);
        }

        /// <summary>Get all cards with permission</summary>
        /// <param name="lockId">ID of the lock</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("{lockId}/card")]
        public Task<ObservableCollection<Card>> GetCardsOfLockId(long lockId, CancellationToken cancellationToken)
        {
            return _implementation.GetCardsOfLockIdAsync(lockId, cancellationToken);
        }

        /// <summary>Grant permission to a card</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Card permission granted</returns>
        [HttpPost, Route("{lockId}/card")]
        public Task<LockCard> AddCardToLockId(long lockId, [FromBody] object body, CancellationToken cancellationToken)
        {
            return _implementation.AddCardToLockIdAsync(lockId, body, cancellationToken);
        }

        /// <summary>Get all cards groups with permission</summary>
        /// <param name="lockId">ID of the lock</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("{lockId}/cardGroups")]
        public Task<ObservableCollection<CardGroup>> GetLockCardGroups(long lockId, CancellationToken cancellationToken)
        {
            return _implementation.GetLockCardGroupsAsync(lockId, cancellationToken);
        }

        /// <summary>Grant permission to a card group</summary>
        /// <param name="lockId">ID of lock</param>
        /// <returns>Card permission granted</returns>
        [HttpPost, Route("{lockId}/cardGroups")]
        public Task<CardGroupLock> AddCardgroupToLock(long lockId, [FromBody] object body, CancellationToken cancellationToken)
        {
            return _implementation.AddCardgroupToLockAsync(lockId, body, cancellationToken);
        }

        /// <summary>Revoke permission to cards</summary>
        /// <param name="lockId">ID of lock</param>
        /// <param name="cardId">Card id to revoke permission</param>
        /// <returns>Card permission revoked successfully</returns>
        [HttpDelete, Route("{lockId}/card/{cardId}")]
        public Task RemoveCardLockPermission(long lockId, System.Collections.Generic.IEnumerable<long> cardId, CancellationToken cancellationToken)
        {
            return _implementation.RemoveCardLockPermissionAsync(lockId, cardId, cancellationToken);
        }

        /// <summary>Revoke permission to card groups</summary>
        /// <param name="lockId">ID of lock</param>
        /// <param name="cardGroupId">Card Group ids to revoke permission</param>
        /// <returns>Card group permission revoked successfully</returns>
        [HttpDelete, Route("{lockId}/cardGroup/{cardGroupId}")]
        public Task RemoveCardGroupLockPermission(long lockId, System.Collections.Generic.IEnumerable<long> cardGroupId, CancellationToken cancellationToken)
        {
            return _implementation.RemoveCardGroupLockPermissionAsync(lockId, cardGroupId, cancellationToken);
        }

        /// <summary>Execute a command on a lock</summary>
        /// <param name="lockId">ID of lock</param>
        /// <param name="commandId">ID of the command</param>
        /// <param name="cardId">ID of the card that wants to execute the command. If this command is run by an user then the cardId will be null and the userId will be in the Audit information</param>
        /// <returns>Lock command executed successfully</returns>
        [HttpPost, Route("{lockId}/command")]
        public async Task<IActionResult> ExecuteCommandsForLockId(int? lockId, LockState? commandId, int? cardId, CancellationToken cancellationToken)
        {
            //Validate the request
            var isCorrectRequest = true;
            if (lockId == null)
            {
                isCorrectRequest = false;
                ModelState.AddModelError("lockId", "The lockId cannot be null");
            }
            if (commandId == null)
            {
                isCorrectRequest = false;
                ModelState.AddModelError("commandId", "The commandId cannot be null");
            }

            if (!isCorrectRequest)
            {
                return BadRequest(ModelState);
            }
            var result = await _implementation
                .ExecuteCommandsForLockIdAsync(lockId.Value, commandId.Value, cardId, cancellationToken);
            return RenderResult(result);
        }

    }
}