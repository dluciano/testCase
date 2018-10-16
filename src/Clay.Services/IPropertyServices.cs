using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Clay.WebApi
{
    public interface IPropertyServices
    {
        /// <summary>Get all properties that belongs to an authenticated user</summary>
        /// <returns>Successfull</returns>
        Task<ObservableCollection<Property>> GetUserPropertiesAsync(CancellationToken cancellationToken);

        /// <summary>Create a property associated to the current an authenticated user</summary>
        /// <returns>Property registererd successfully</returns>
        Task<Property> CreatePropertyAsync(Property body, CancellationToken cancellationToken);

        /// <summary>Get a specific property by its ID</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Successfull</returns>
        Task<Property> GetPropertyByIdAsync(int propertyId, CancellationToken cancellationToken);

        /// <summary>Get all the locks of a property</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Ok</returns>
        Task<ObservableCollection<Lock>> GetLocksOfPropertyIdAsync(int propertyId, CancellationToken cancellationToken);

        /// <summary>Add a lock or group of locks to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Locks registererd successfully</returns>
        Task<ResultDto> AddLockToPropertyAsync(int propertyId, CreateLockForPropertyDto dto, CancellationToken cancellationToken);
        
        /// <summary>Get all the cards of a property</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Ok</returns>
        Task<ObservableCollection<Card>> GetCardsOfPropertyAllAsync(int propertyId, CancellationToken cancellationToken);

        /// <summary>Add a card or group of cards to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Card registererd successfully</returns>
        Task AddCardToPropertyAsync(int propertyId, object body, CancellationToken cancellationToken);

        /// <summary>Get all the card groups belonging to a property</summary>
        /// <param name="propertyId">ID of property</param>
        /// <returns>Ok</returns>
        Task<ResultDto> GetCardsGroupsOfPropertyAsync(int propertyId, CancellationToken cancellationToken);

        /// <summary>Add a card group to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Card group registererd successfully</returns>
        Task AddCardGroupToPropertyAsync(int propertyId, object body, CancellationToken cancellationToken);

        /// <summary>Get all the events of a property</summary>
        /// <param name="propertyId">ID of property</param>
        /// <returns>Ok</returns>
        Task<ObservableCollection<LockEvent>> GetCardsOfPropertyAsync(int propertyId, CancellationToken cancellationToken);
    }
}