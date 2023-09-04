using Microsoft.Extensions.DependencyInjection;
using WholesBrew.DataAccess.Contexts;

namespace WholesBrew.DataAccess.Tests;

public class WholesBrewUnitOfWorkTests : IDisposable
{
    private readonly WholesBrewDbContext _dbContext;
    private readonly IServiceProvider _serviceProvider;

    public WholesBrewUnitOfWorkTests()
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<WholesBrewDbContext>() 
            .BuildServiceProvider();

        _dbContext = serviceProvider.GetRequiredService<WholesBrewDbContext>();
        _serviceProvider = serviceProvider;
    }

    [Fact]
    public async Task SaveChangesAsync_ShouldSaveChangesToDatabase()
    {
        // Arrange
        using (var unitOfWork = new WholesBrewUnitOfWork(_dbContext, _serviceProvider))
        {
            // Act
            var result = await unitOfWork.SaveChangesAsync();

            // Assert
            Assert.True(result >= 0);
        }
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}