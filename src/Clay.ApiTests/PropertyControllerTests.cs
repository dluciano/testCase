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

namespace Clay.WebApi.UnitTests
{
    public class PropertyControllerTests
    {
        [Fact]
        public void CreateProperty_OK()
        {
            // Arrange
            var dataset = new List<Property>();
            var mockPropertyRepo = new RepositoryTest<Property>(dataset);
            var mockUoWRepo = new TestUnitOfWork();
            var mockService = new PropertyServices(mockPropertyRepo, mockUoWRepo);
            var controller = new PropertyController(mockService);

            // Act
            var name = "Clay";//Data of the test
            var result = controller.CreateProperty(new CreatePropertyViewModel { Name = name }, System.Threading.CancellationToken.None).Result;

            //// Assert
            result.ShouldBeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            var propertyOutput = (Property)okResult.Value;
            propertyOutput.Name.ShouldBe(name);
        }
    }
}
