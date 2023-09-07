global using Xunit;
using AutoMapper;
using Moq;
using WholesBrew.Business.Abstractions;
using WholesBrew.Business.Facades;
using WholesBrew.Contracts.Dtos;
using WholesBrew.Model.Entities;

namespace WholesBrew.Facades.Tests
{
    public class WholesalerFacadeTests
    {
        [Fact]
        public async Task GetAllWholesalersAsync_ReturnsExpectedResult()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var wholesalerServiceMock = new Mock<IWholesalerService>();

            // Set up the facade with mocked dependencies
            var facade = new WholesalerFacade(mapperMock.Object, wholesalerServiceMock.Object);

            // Mock the behavior of the wholesalerService to return the expected result
            wholesalerServiceMock.Setup(s => s.GetAllWholesalersAsync()).ReturnsAsync(ExpectedWholesalerStockEntities());

            // Define test data
            var expectedWholesalers = new List<WholesalerEntity>();
            var expectedWholesalerDTOs = new List<WholesalerStockDTO>(); // Adjust the type as needed

            // Mock the mapping behavior
            mapperMock.Setup(m => m.Map<IEnumerable<WholesalerStockDTO>>(expectedWholesalers))
                      .Returns(expectedWholesalerDTOs);

            // Act
            var result = await facade.GetAllWholesalersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<WholesalerStockDTO>>(result);
        }

        private static IEnumerable<WholesalerStockEntity> ExpectedWholesalerStockEntities()
        {
            return new List<WholesalerStockEntity>
        {
            new WholesalerStockEntity
            {
                Id = 1,
                WholesalerId = 1,
                BeerId = 101,
                Quantity = 100,
                Price = 5.99m,
            },
            new WholesalerStockEntity
            {
                Id = 2,
                WholesalerId = 2,
                BeerId = 102,
                Quantity = 150,
                Price = 4.49m,
            },
        };
        }


        [Fact]
        public async Task CreateWholesalerAsync_ReturnsExpectedResult()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var wholesalerServiceMock = new Mock<IWholesalerService>();

            // Set up the facade with mocked dependencies
            var facade = new WholesalerFacade(mapperMock.Object, wholesalerServiceMock.Object);

            // Define test data
            var newWholesalerDTO = new WholesalerDTO
            {
                Id = 1,
                Name = "GeneDrinks",
            };

            var expectedWholesalerEntity = new WholesalerEntity
            {
                Id = 1,
                Name = "GeneDrinks",
            };

            // Mock the behavior of the wholesalerService to return the expected result
            wholesalerServiceMock.Setup(s => s.CreateWholesalerAsync(It.IsAny<WholesalerEntity>()))
                                .ReturnsAsync(expectedWholesalerEntity);

            // Mock the mapping behavior
            mapperMock.Setup(m => m.Map<WholesalerEntity>(newWholesalerDTO))
                      .Returns(expectedWholesalerEntity);

            mapperMock.Setup(m => m.Map<WholesalerDTO>(expectedWholesalerEntity))
                      .Returns(newWholesalerDTO);

            // Act
            var result = await facade.CreateWholesalerAsync(newWholesalerDTO);

            // Assert
            Assert.NotNull(result);
        }
    }
}