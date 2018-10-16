using Clay.Services;
using Moq;
using Xunit;
using Clay.WebApi;
using Clay.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Shouldly;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;

namespace Clay.WebApi.UnitTests
{
    public class PropertyControllerTests
    {
        [Fact]
        public void CreateProperty_OK()
        {
            // Data
            var name = "Clay";

            // Arrange
            var controller = Arrange(new TestUnitOfWork());

            // Act
            var result = controller.CreateProperty(
                new CreatePropertyDto { Name = name },
                System.Threading.CancellationToken.None).Result;

            // Assert
            result.ShouldBeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            var propertyOutput = (Property)okResult.Value;
            propertyOutput.Name.ShouldBe(name);
        }

        private PropertyController Arrange(TestUnitOfWork uof)
        {
            uof = uof ?? new TestUnitOfWork();
            var dataset = new List<Property>();
            var mockPropertyRepo = new RepositoryTest<Property>(uof.Properties);
            var mockLockRepo = new RepositoryTest<Lock>(uof.Locks);

            var propertySrv = new PropertyServices(mockPropertyRepo, mockLockRepo, uof);
            var lockService = new LockServices();
            return new PropertyController(propertySrv, lockService);
        }

        [Fact]
        public void CreateLocks_OK()
        {
            // Data
            var identifier = Guid.NewGuid().ToString();
            var description = "Clay";
            var propertyId = 1;
            var mockUoWRepo = new TestUnitOfWork();
            mockUoWRepo.Properties.Add(new Property() { Id = 1 });

            // Arrange
            var controller = Arrange(mockUoWRepo);

            // Act
            var result = controller.AddLockToProperty(propertyId, new CreateLockForPropertyDto
            {
                Identifier = identifier,
                Description = description
            }, System.Threading.CancellationToken.None).Result;

            // Assert
            result.ShouldBeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            var lockCreated = (Lock)okResult.Value;
            lockCreated.Identifier.ShouldBe(identifier);
            lockCreated.Description.ShouldBe(description);
            lockCreated.Property.Id.ShouldBe(propertyId);
        }
    }
}
