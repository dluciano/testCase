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

        public Task CreatePropertyAsync(object body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
