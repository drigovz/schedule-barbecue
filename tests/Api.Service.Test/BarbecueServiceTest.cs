using Api.Domain.DTOs.Barbecues;
using Api.Domain.Interfaces.Services.BarbecueService;
using Api.Service.Test.Fakes;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test
{
   public class BarbecueServiceTest : BarbecueFake
   {
      private IBarbecueService _service;
      private Mock<IBarbecueService> _serviceMock;

      //[Fact(DisplayName = "Should be possivel to execute GET method")]
      [Fact]
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

      [Fact]
      public async Task Should_be_return_null_object()
      { 
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.GetAsync(It.IsAny<int>()))
                     .Returns(Task.FromResult((BarbecueDetailsDTO)null));
         _service = _serviceMock.Object;

         var result = await _service.GetAsync(Id);

         Assert.Null(result);
      }

      [Fact]
      public async Task Should_be_return_list_of_barbecues()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.GetAllAsync())
                     .ReturnsAsync(barbecues);
         _service = _serviceMock.Object;

         var barbecuesList = await _service.GetAllAsync();

         Assert.NotNull(barbecuesList);
         Assert.NotEmpty(barbecuesList);
      }

      [Fact]
      public async Task Should_be_possible_to_create_new_barbecue()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.PostAsync(barbecueDto))
                     .ReturnsAsync(barbecueDto);
         _service = _serviceMock.Object;
         
         var result = await _service.PostAsync(barbecueDto);

         Assert.NotNull(result);
         Assert.Equal(barbecueDto.Description, result.Description);
         Assert.Equal(barbecueDto.AdditionalNotes, result.AdditionalNotes);
      }

      [Fact]
      public async Task Should_be_possible_update_barbecue()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.PutAsync(barbecueDto))
                     .ReturnsAsync(barbecueDto);
         _service = _serviceMock.Object;

         var result = await  _service.PutAsync(barbecueDto);

         Assert.NotNull(result);
         Assert.Equal(barbecueDto.Id, result.Id);
         Assert.Equal(barbecueDto.Description, result.Description);
         Assert.Equal(barbecueDto.AdditionalNotes, result.AdditionalNotes);
      }
   }
}