global using Xunit;
using Moq;
using WholesBrew.DataAccess.Abstractions;
using WholesBrew.Model.Entities;
using WholesBrew.DataAccess.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;
using WholesBrew.DataAccess;
using System.Linq.Expressions;

namespace WholesBrew.Business.Tests
{
    public class WholesalerServiceTests
    {
        [Fact]
        public async Task CreateWholesalerAsync_ValidWholesaler_ReturnsWholesaler()
        {
            // Arrange
            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();
            var unitOfWorkMock = new Mock<IWholesBrewUnitOfWork>();
            unitOfWorkMock.Setup(u => u.WholesalerRepository).Returns(wholesalerRepositoryMock.Object);

            var wholesalerService = new WholesalerService(unitOfWorkMock.Object);
            var newWholesaler = new WholesalerEntity();

            // Act
            var result = await wholesalerService.CreateWholesalerAsync(newWholesaler);

            // Assert
            Assert.NotNull(result);
            Assert.Same(newWholesaler, result);
        }

        [Fact]
        public async Task UpdateBeerQuantityAsync_ExistingStock_UpdatesQuantity()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IWholesBrewUnitOfWork>();
            var wholesalerStockRepositoryMock = new Mock<IWholesalerStockRepository>();
            var beerRepositoryMock = new Mock<IBeerRepository>();
            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();

            unitOfWorkMock.Setup(u => u.WholesalerStockRepository).Returns(wholesalerStockRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.BeerRepository).Returns(beerRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.WholesalerRepository).Returns(wholesalerRepositoryMock.Object);

            var wholesalerService = new WholesalerService(unitOfWorkMock.Object);
            var wholesalerId = 1;
            var beerId = 2;
            var initialQuantity = 10;
            var newQuantity = 5;

            // Mock the existing wholesaler stock
            var existingWholesalerStock = new WholesalerStockEntity
            {
                WholesalerId = wholesalerId,
                BeerId = beerId,
                Quantity = initialQuantity
            };

            // Mock the repository to return the expected data
            wholesalerStockRepositoryMock
                .Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<WholesalerStockEntity, bool>>>()))
                .ReturnsAsync((Expression<Func<WholesalerStockEntity, bool>> predicate) =>
                {
                    var entities = ExpectedWholesalerStockEntities();
                    return entities.FirstOrDefault(predicate.Compile());
                });

            // Act
            var updatedStock = await wholesalerService.UpdateBeerQuantityAsync(wholesalerId, beerId, newQuantity);

            // Assert
            Assert.NotNull(updatedStock);
            // Ensure that the expected stock quantity is calculated correctly
            var expectedQuantity = initialQuantity + newQuantity;
            Assert.Equal(expectedQuantity, updatedStock.Quantity);
        }

        [Fact]
        public async Task UpdateBeerQuantityAsync_NonExistingStock_AddsNewStockItem()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IWholesBrewUnitOfWork>();
            var wholesalerStockRepositoryMock = new Mock<IWholesalerStockRepository>();
            var beerRepositoryMock = new Mock<IBeerRepository>();
            var wholesalerRepositoryMock = new Mock<IWholesalerRepository>();

            unitOfWorkMock.Setup(u => u.WholesalerStockRepository).Returns(wholesalerStockRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.BeerRepository).Returns(beerRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.WholesalerRepository).Returns(wholesalerRepositoryMock.Object);

            var wholesalerService = new WholesalerService(unitOfWorkMock.Object);
            var wholesalerId = 1;
            var beerId = 2;
            var newQuantity = 5;

            // Mock that the existing wholesaler stock is not found
            wholesalerStockRepositoryMock.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<WholesalerStockEntity>());

            // Mock that the beer and wholesaler exist
            beerRepositoryMock.Setup(r => r.GetByIdAsync(beerId)).ReturnsAsync(new BeerEntity());
            wholesalerRepositoryMock.Setup(r => r.GetByIdAsync(wholesalerId)).ReturnsAsync(new WholesalerEntity());

            // Act
            var addedStock = await wholesalerService.UpdateBeerQuantityAsync(wholesalerId, beerId, newQuantity);

            // Assert
            Assert.NotNull(addedStock);
            Assert.Equal(newQuantity, addedStock.Quantity);
        }

        private static IEnumerable<WholesalerStockEntity> ExpectedWholesalerStockEntities()
        {
            return new List<WholesalerStockEntity>
            {
                new WholesalerStockEntity
                {
                    Id = 1,
                    WholesalerId = 2,
                    BeerId = 1,
                    Quantity = 100,
                    Price = 5.99m,
                },
                new WholesalerStockEntity
                {
                    Id = 2,
                    WholesalerId = 1,
                    BeerId = 2, 
                    Quantity = 10,
                    Price = 4.49m,
                },
            };
        }

    }
}