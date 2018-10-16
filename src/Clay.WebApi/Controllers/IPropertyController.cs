namespace Clay.WebApi
{
    public interface IPropertyController
    {
        /// <summary>Get all properties that belongs to an authenticated user</summary>
        /// <returns>Successfull</returns>
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Property>> GetUserPropertiesAsync(System.Threading.CancellationToken cancellationToken);

        /// <summary>Create a property associated to the current an authenticated user</summary>
        /// <returns>Property registererd successfully</returns>
        System.Threading.Tasks.Task CreatePropertyAsync(object body, System.Threading.CancellationToken cancellationToken);

        /// <summary>Get a specific property by its ID</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Successfull</returns>
        System.Threading.Tasks.Task<Property> GetPropertyByIdAsync(long propertyId, System.Threading.CancellationToken cancellationToken);

        /// <summary>Get all the locks of a property</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Ok</returns>
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Lock>> GetLocksOfPropertyIdAsync(long propertyId, System.Threading.CancellationToken cancellationToken);

        /// <summary>Add a lock or group of locks to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Locks registererd successfully</returns>
        System.Threading.Tasks.Task AddLockToPropertyAsync(long propertyId, object body, System.Threading.CancellationToken cancellationToken);

        /// <summary>Get all the cards of a property</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Ok</returns>
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Card>> GetCardsOfPropertyAllAsync(long propertyId, System.Threading.CancellationToken cancellationToken);

        /// <summary>Add a card or group of cards to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Card registererd successfully</returns>
        System.Threading.Tasks.Task AddCardToPropertyAsync(long propertyId, object body, System.Threading.CancellationToken cancellationToken);

        /// <summary>Get all the card groups belonging to a property</summary>
        /// <param name="propertyId">ID of property</param>
        /// <returns>Ok</returns>
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CardGroup>> GetCardsGroupsOfPropertyAsync(long propertyId, System.Threading.CancellationToken cancellationToken);

        /// <summary>Add a card group to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Card group registererd successfully</returns>
        System.Threading.Tasks.Task AddCardGroupToPropertyAsync(long propertyId, object body, System.Threading.CancellationToken cancellationToken);

        /// <summary>Get all the events of a property</summary>
        /// <param name="propertyId">ID of property</param>
        /// <returns>Ok</returns>
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LockEvent>> GetCardsOfPropertyAsync(long propertyId, System.Threading.CancellationToken cancellationToken);

    }
}