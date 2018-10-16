using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Clay.WebApi
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.20.1.0 (NJsonSchema v9.11.0.0 (Newtonsoft.Json v9.0.0.0))")]
    [Route("api/[controller]")]
    [ApiController]
    public partial class PropertyController : ControllerBase
    {
        private IPropertyServices _implementation;

        public PropertyController(IPropertyServices implementation)
        {
            _implementation = implementation;
        }

        /// <summary>Get all properties that belongs to an authenticated user</summary>
        /// <returns>Successfull</returns>
        [HttpGet, Route("me")]
        public async Task<ObservableCollection<Property>> GetUserProperties(CancellationToken cancellationToken) =>
            await _implementation.GetUserPropertiesAsync(cancellationToken);

        /// <summary>Create a property associated to the current an authenticated user</summary>
        /// <returns>Property registererd successfully</returns>
        [HttpPost, Route("me")]
        public async Task<IActionResult> CreateProperty([FromBody] CreatePropertyViewModel body, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _implementation.CreatePropertyAsync(new Property { Name = body.Name }, cancellationToken);
            return Ok(result);
        }

        /// <summary>Get a specific property by its ID</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Successfull</returns>
        [HttpGet, Route("{propertyId}")]
        public async Task<Property> GetPropertyById(long propertyId, CancellationToken cancellationToken) =>
            await _implementation.GetPropertyByIdAsync(propertyId, cancellationToken);

        /// <summary>Get all the locks of a property</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("{propertyId}/lock")]
        public async Task<ObservableCollection<Lock>> GetLocksOfPropertyId(long propertyId, CancellationToken cancellationToken) =>
            await _implementation.GetLocksOfPropertyIdAsync(propertyId, cancellationToken);

        /// <summary>Add a lock or group of locks to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Locks registererd successfully</returns>
        [HttpPost, Route("{propertyId}/lock")]
        public async Task AddLockToProperty(long propertyId, [FromBody] object body, CancellationToken cancellationToken) =>
            await _implementation.AddLockToPropertyAsync(propertyId, body, cancellationToken);

        /// <summary>Get all the cards of a property</summary>
        /// <param name="propertyId">ID of property to return</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("{propertyId}/card")]
        public async Task<ObservableCollection<Card>> GetCardsOfPropertyAll(long propertyId, CancellationToken cancellationToken) =>
            await _implementation.GetCardsOfPropertyAllAsync(propertyId, cancellationToken);

        /// <summary>Add a card or group of cards to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Card registererd successfully</returns>
        [HttpPost, Route("{propertyId}/card")]
        public async Task AddCardToProperty(long propertyId, [FromBody] object body, CancellationToken cancellationToken) =>
            await _implementation.AddCardToPropertyAsync(propertyId, body, cancellationToken);

        /// <summary>Get all the card groups belonging to a property</summary>
        /// <param name="propertyId">ID of property</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("{propertyId}/cardgroup")]
        public async Task<ObservableCollection<CardGroup>> GetCardsGroupsOfProperty(long propertyId, CancellationToken cancellationToken) =>
            await _implementation.GetCardsGroupsOfPropertyAsync(propertyId, cancellationToken);

        /// <summary>Add a card group to a property</summary>
        /// <param name="propertyId">ID of the property</param>
        /// <returns>Card group registererd successfully</returns>
        [HttpPost, Route("{propertyId}/cardgroup")]
        public async Task AddCardGroupToProperty(long propertyId, [FromBody] object body, CancellationToken cancellationToken) =>
            await _implementation.AddCardGroupToPropertyAsync(propertyId, body, cancellationToken);

        /// <summary>Get all the events of a property</summary>
        /// <param name="propertyId">ID of property</param>
        /// <returns>Ok</returns>
        [HttpGet, Route("{propertyId}/events")]
        public async Task<ObservableCollection<LockEvent>> GetCardsOfProperty(long propertyId, CancellationToken cancellationToken) =>
            await _implementation.GetCardsOfPropertyAsync(propertyId, cancellationToken);

    }
}