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
    public class PropertyServices : IPropertyServices
    {
        private readonly IRepository<Property> _properties;
        private readonly IRepository<Lock> _locks;
        private readonly IRepository<CardGroup> _cardGroups;
        private readonly IUnitOfWork _uow;

        public PropertyServices(IRepository<Property> properties,
            IRepository<Lock> locks,
            IRepository<CardGroup> cardGroups,
            IUnitOfWork uow)
        {
            _properties = properties;
            _locks = locks;
            _cardGroups = cardGroups;
            _uow = uow;
        }
        public Task AddCardGroupToPropertyAsync(int propertyId, object body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddCardToPropertyAsync(int propertyId, object body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto> AddLockToPropertyAsync(int propertyId, CreateLockForPropertyDto dto, CancellationToken cancellationToken)
        {
            var property = _properties.FirstOrDefault(p => p.Id == propertyId);
            if (property == null)
                return ResultDto.NotFound("Property not found");
            var entity = new Lock
            {
                Property = property,
                Identifier = dto.Identifier,
                Description = dto.Description
            };
            await _locks.AddAsync(entity);
            await _uow.SaveChangesAsync();
            return ResultDto.Ok(entity);
        }

        public async Task<Property> CreatePropertyAsync(Property entity, CancellationToken cancellationToken)
        {
            await _properties.AddAsync(entity);
            await _uow.SaveChangesAsync();
            return entity;
        }

        public async Task<ResultDto> GetCardsGroupsOfPropertyAsync(int propertyId, CancellationToken cancellationToken)
        {
            var property = _properties.FirstOrDefault(p => p.Id == propertyId);
            if (property == null)
                return ResultDto.NotFound("Property not found");
            var cgroups = _cardGroups.Where(c => c.Property.Id == propertyId);
            return ResultDto.Ok(new ObservableCollection<CardGroup>(cgroups));
        }

        public Task<ObservableCollection<Card>> GetCardsOfPropertyAllAsync(int propertyId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<LockEvent>> GetCardsOfPropertyAsync(int propertyId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Lock>> GetLocksOfPropertyIdAsync(int propertyId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Property> GetPropertyByIdAsync(int propertyId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Property>> GetUserPropertiesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
