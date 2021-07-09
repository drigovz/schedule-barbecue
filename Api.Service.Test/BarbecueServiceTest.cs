using Api.Domain.Interfaces.Services.BarbecueService;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test
{
   public class BarbecueServiceTest : BarbecueFake
   {
      private IBarbecueService _service;
      private Mock<IBarbecueService> _serviceMock;

      [Fact(DisplayName = "Should be possivel to execute GET method")]
      public async Task Should_be_possivel_to_execute_GET_method()
      {
         // Act
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.GetAsync(Id))
                     .ReturnsAsync(barbecueDetailsDto);
         _service = _serviceMock.Object;

         // Arrange
         var result = await _service.GetAsync(Id);

         // Assert
         Assert.NotNull(result);
         Assert.True(result.Id == Id);
         Assert.Equal(Description, result.Description);
      }
   }
}