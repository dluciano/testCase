using Clay.DAL;
using Clay.WebApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clay.Services
{
    public class LockServices : ILockServices
    {
        private readonly IRepository<Card> _cards;
        private readonly IRepository<Lock> _locks;
        private readonly IRepository<CardGroupLock> _cardGroupLock;
        private readonly IRepository<LockCard> _lockCards;
        private readonly IRepository<LockEvent> _lockEvent;
        private readonly IUnitOfWork _uow;
        private readonly ISecurityService _securityService;

        public LockServices(IRepository<Card> cards,
            IRepository<Lock> locks,
            IRepository<CardGroupLock> cardGroups,
            IRepository<LockCard> lockCards,
            IRepository<LockEvent> lockEvent,
            ISecurityService userService,
            IUnitOfWork uow)
        {
            _cards = cards;
            _locks = locks;
            _cardGroupLock = cardGroups;
            _uow = uow;
            _securityService = userService;
            _lockCards = lockCards;
            _lockEvent = lockEvent;
        }

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

        public async Task<ResultDto> ExecuteCommandsForLockIdAsync(int lockId, LockState commandId, int? cardId, CancellationToken cancellationToken)
        {
            var loc = _locks.FirstOrDefault(l => l.Id == lockId);
            if (loc == null)
                return ResultDto.NotFound("Lock not found");

            //If the rerquest was done by a card
            Card card = null;
            if (cardId != null)
            {
                card = _cards.Include(c => c.PersonData).FirstOrDefault(l => l.Id == cardId.Value);
                if (card == null)
                    return ResultDto.NotFound("Card not found");

                //Verifiy if the card is registered directely to open the lock
                var cardAllowed = false;
                cardAllowed = _lockCards.Any(lc => lc.Lock.Id == lockId && lc.Card.Id == cardId);

                //If there isn't an explicit permission, then look in the groups
                if (!cardAllowed && !_cardGroupLock.Include(c => c.CardGroup)
                        .Where(cgl => cgl.CardGroup.Cards.Any(cg => cg.Id == cardId))
                        .Any(cgl => cgl.Locks.Any(l => l.Id == lockId)))
                {
                    return ResultDto.Deny();
                }
            }
            else
            {
                //If it is a command not executed by a card then check the user permissions
                var userProperties = _securityService.UserProperties();
                if (userProperties == null || !userProperties.Any())
                    return ResultDto.Deny();
            }
            // If the card has permission then exec the action
            var e = new LockEvent
            {
                Card = card,
                CardOwnerWhenEventTrigger = card.PersonData, //TODO: Save how is the current owner
                Details = $"DOOR-COMMAND-EVENT: {loc.Description} was {commandId.ToString()} on ",
                EventType = commandId == LockState.Locked ? EventType.CardLock : EventType.CardUnlock,
                Lock = loc
            };
            await _lockEvent.AddAsync(e);
            //The method AddAsync create the Audit and we can use that creation date to write the descritpion message
            e.Details += $"{e.Audit.CreatedAt} by: {GetIdentifier(card)} owned at the moment of the transaction by {e.CardOwnerWhenEventTrigger.FullName}";
            await _uow.SaveChangesAsync();
            return ResultDto.Ok(e);
        }

        private string GetIdentifier(Card card) =>
            card == null ? $"user {_securityService.LogedUserName}" : $"card {card.Identitfier}";

        public Task<ObservableCollection<Card>> GetCardsOfLockIdAsync(long lockId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto> GetEventsOfLockIdAsync(int lockId, CancellationToken cancellationToken)
        {
            var loc = _locks.FirstOrDefault(l => l.Id == lockId);
            if (loc == null)
                return ResultDto.NotFound("Lock not found");

            return ResultDto.Ok(new ObservableCollection<LockEvent>(_lockEvent.Where(l => l.Lock.Id == lockId)));
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
