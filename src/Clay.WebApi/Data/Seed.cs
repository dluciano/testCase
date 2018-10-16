using System;
using System.Linq;
using System.Threading.Tasks;
using Clay.DAL;
using Clay.WebApi;
using IdentityServer;

namespace Clay.WebApi
{
    public class Seed : ISeed
    {
        private readonly IRepository<Card> cards;
        private readonly IRepository<CardGroup> cardGroups;
        private readonly IRepository<CardGroupLock> cardGroupLocks;
        private readonly IRepository<CardOwner> cardOwners;
        private readonly IRepository<Lock> locks;
        private readonly IRepository<LockCard> lockCards;
        private readonly IRepository<LockEvent> lockEvents;
        private readonly IRepository<Property> properties;

        public Seed(IRepository<Property> properties,
            IRepository<Card> cards,
            IRepository<CardOwner> cardOwners,

            IRepository<Lock> locks,
            IRepository<CardGroup> cardGroups,
            IRepository<CardGroupLock> cardGroupLocks,

            IRepository<LockCard> lockCards,

            IRepository<LockEvent> lockEvents,
            IUnitOfWork uof)
        {
            this.cards = cards;
            this.cardGroups = cardGroups;
            this.cardGroupLocks = cardGroupLocks;
            this.cardOwners = cardOwners;
            this.locks = locks;
            this.lockCards = lockCards;
            this.lockEvents = lockEvents;
            this.properties = properties;
            UnitOfWork = uof;
        }

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
            Property property = null;
            if (!properties.Any())
            {
                Console.WriteLine("Properties being populated");
                property = new Property() { Name = "Clay Office" };
                await properties.AddAsync(property);
            }
            else
            {
                property = properties.First();
                Console.WriteLine("Properties already populated");
            }


            Console.WriteLine("Cards being populated");
            Card ctoCard = new Card() { Identitfier = Guid.NewGuid().ToString() };
            Card devCard = null;
            var mainDoorLock = new Lock()
            {
                AutoLockAfter = 9997,
                LockState = LockState.Locked,
                DoorState = LockDoorState.Closed,
                Property = property,
                Description = "Main Door"
            };
            var managersFloorDoor = new Lock()
            {
                AutoLockAfter = 9997,
                LockState = LockState.Locked,
                DoorState = LockDoorState.Closed,
                Property = property,
                Description = "Managers Entrance Door"
            };
            var managerGroup = new CardGroup()
            {
                Description = "Managers",
                Property = property
            };
            var allPeopleGroup = new CardGroup()
            {
                Description = "All People",
                Property = property
            };

            if (!cards.Any())
            {
                ctoCard.Properties.Add(property);
                devCard.Properties.Add(property);

                ctoCard.Owners.Add(new CardOwner()
                {
                    Username = "Cto",
                    FirstName = "Chief",
                    LastName = "Tech Offf"
                });
                ctoCard.Groups.Add(managerGroup);

                devCard.Owners.Add(new CardOwner()
                {
                    Username = "dev",
                    FirstName = "Developer",
                    LastName = "CSharp .NET"
                });

                devCard.Groups.Add(allPeopleGroup);
                devCard.Locks.Add(mainDoorLock);

                cardGroupLocks.Add(new CardGroupLock()
                {
                    CardGroup = managerGroup,
                    Lock = mainDoorLock
                });
                cardGroupLocks.Add(new CardGroupLock()
                {
                    CardGroup = allPeopleGroup,
                    Lock = mainDoorLock
                });
                await cards.AddRangeAsync(ctoCard, devCard);
            }
            else
            {
                Console.WriteLine("Cars and other data already populated");
            }

            //TODO: Async stop unexpectely
            UnitOfWork.SaveChanges();
        }
    }
}