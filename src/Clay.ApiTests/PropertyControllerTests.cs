using Clay.Services;
using Moq;
using Xunit;
using Clay.WebApi;
using Clay.DAL;

namespace Clay.WebApi.UnitTests
{
    public class PropertyControllerTests
    {
        [Fact]
        public void CreateProperty_OK()
        {
            // Arrange
            var mockPropertyRepo = new Mock<IRepository<Property>>();
            var mockUoWRepo = new Mock<IUnitOfWork>();
            var mockService = new Mock<IPropertyServices>();
            mockService.Setup(repo => new PropertyServices(mockPropertyRepo.Object, mockUoWRepo.Object));
            var controller = new PropertyController(mockService.Object);

            // Act
            var result = controller.CreateProperty(new CreatePropertyViewModel { Name = "Clay" }, System.Threading.CancellationToken.None);

            //// Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
            //    viewResult.ViewData.Model);
            //Assert.Equal(2, model.Count());
        }
    }
}
