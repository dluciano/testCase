using Clay.DAL;
using Clay.WebApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clay.Services
{
    public class PropertyServices : IPropertyServices
    {
        private readonly IRepository<Property> _properties;
        private readonly IUnitOfWork _uow;

        public PropertyServices(IRepository<Property> properties, IUnitOfWork uow)
        {
            _properties = properties;
            _uow = uow;
        }
        public Task AddCardGroupToPropertyAsync(long propertyId, object body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddCardToPropertyAsync(long propertyId, object body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddLockToPropertyAsync(long propertyId, object body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Property> CreatePropertyAsync(Property entity, CancellationToken cancellationToken)
        {
            await _properties.AddAsync(entity);
            await _uow.SaveChangesAsync();
            return entity;
        }

        public Task<ObservableCollection<CardGroup>> GetCardsGroupsOfPropertyAsync(long propertyId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Card>> GetCardsOfPropertyAllAsync(long propertyId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<LockEvent>> GetCardsOfPropertyAsync(long propertyId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Lock>> GetLocksOfPropertyIdAsync(long propertyId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Property> GetPropertyByIdAsync(long propertyId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Property>> GetUserPropertiesAsync(CancellationToken cancellationToken) =>
            Task.FromResult(new ObservableCollection<Property>() { new Property {
                Name="Clay Office"
                } });
    }
}
