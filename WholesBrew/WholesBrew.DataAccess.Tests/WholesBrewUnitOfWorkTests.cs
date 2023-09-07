global using Xunit;
using Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using WholesBrew.DataAccess.Contexts;
using WholesBrew.Model.Abstractions;

namespace WholesBrew.DataAccess.Tests
{
    public class BrewUnitOfWorkTests
    {
        [Fact]
        public async Task SaveChangesAsync_ShouldCallDbContextSaveChangesAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WholesBrewSqlServerDbContext>()
                .UseMsSqlServerProvider("Server=localhost,1433;Database=WholesBrew;User=sa;Password=OcP2020123;TrustServerCertificate=true");

            var dbContextMock = new Mock<WholesBrewSqlServerDbContext>(options);


            var brewRepositoryMock = new Mock<IServiceProvider>();

            dbContextMock.Setup(d => d.SaveChangesAsync(default)).ReturnsAsync(1); // Simulate a successful save

            var unitOfWork = new WholesBrewUnitOfWork(dbContextMock.Object, brewRepositoryMock.Object);

            // Act
            await unitOfWork.SaveChangesAsync();

            // Assert
            dbContextMock.Verify(d => d.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public void Dispose_ShouldDisposeDbContext()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WholesBrewDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContextMock = new Mock<WholesBrewDbContext>(options);
            var brewRepositoryMock = new Mock<IServiceProvider>();

            var unitOfWork = new WholesBrewUnitOfWork(dbContextMock.Object, brewRepositoryMock.Object);

            // Act
            unitOfWork.Dispose();

            // Assert
            dbContextMock.Verify(d => d.Dispose(), Times.Once);
        }

    }
}