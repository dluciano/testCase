using Microsoft.AspNetCore.Mvc;

namespace Clay.WebApi
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0))")]
    [Route("api/[controller]")]
    public partial class PropertyController : ControllerBase
    {
        private IPropertyController _implementation;

        public PropertyController(IPropertyController implementation)
        {
            _implementation = implementation;
        }

        /// <summary>Get all properties that belongs to an authenticated user</summary>
        /// <returns>Successfull</returns>
        [HttpGet, Route("property/me")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Property>> GetUserProperties(System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.GetUserPropertiesAsync(cancellationToken);
        }

        /// <summary>Create a property associated to the current an authenticated user</summary>
        /// <returns>Property registererd successfully</returns>
        [HttpPost, Route("property/me")]
        public System.Threading.Tasks.Task CreateProperty([FromBody] object body, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.CreatePropertyAsync(body, cancellationToken);
        }

        /// <summary>Get a specific property by its ID</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Successfull</returns>
        [HttpGet, Route("property/{propertyId}")]
        public System.Threading.Tasks.Task<Property> GetPropertyById(long propertyId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.GetPropertyByIdAsync(propertyId, cancellationToken);
        }

        /// <summary>Get all the locks of a property</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("property/{propertyId}/lock")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Lock>> GetLocksOfPropertyId(long propertyId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.GetLocksOfPropertyIdAsync(propertyId, cancellationToken);
        }

        /// <summary>Add a lock or group of locks to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Locks registererd successfully</returns>
        [HttpPost, Route("property/{propertyId}/lock")]
        public System.Threading.Tasks.Task AddLockToProperty(long propertyId, [FromBody] object body, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.AddLockToPropertyAsync(propertyId, body, cancellationToken);
        }

        /// <summary>Get all the cards of a property</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("property/{propertyId}/card")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Card>> GetCardsOfPropertyAll(long propertyId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.GetCardsOfPropertyAllAsync(propertyId, cancellationToken);
        }

        /// <summary>Add a card or group of cards to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Card registererd successfully</returns>
        [HttpPost, Route("property/{propertyId}/card")]
        public System.Threading.Tasks.Task AddCardToProperty(long propertyId, [FromBody] object body, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.AddCardToPropertyAsync(propertyId, body, cancellationToken);
        }

        /// <summary>Get all the card groups belonging to a property</summary>
        /// <param name="propertyId">ID of property</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("property/{propertyId}/cardgroup")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<CardGroup>> GetCardsGroupsOfProperty(long propertyId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.GetCardsGroupsOfPropertyAsync(propertyId, cancellationToken);
        }

        /// <summary>Add a card group to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Card group registererd successfully</returns>
        [HttpPost, Route("property/{propertyId}/cardgroup")]
        public System.Threading.Tasks.Task AddCardGroupToProperty(long propertyId, [FromBody] object body, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.AddCardGroupToPropertyAsync(propertyId, body, cancellationToken);
        }

        /// <summary>Get all the events of a property</summary>
        /// <param name="propertyId">ID of property</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("property/{propertyId}/events")]
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LockEvent>> GetCardsOfProperty(long propertyId, System.Threading.CancellationToken cancellationToken)
        {
            return _implementation.GetCardsOfPropertyAsync(propertyId, cancellationToken);
        }

    }
}