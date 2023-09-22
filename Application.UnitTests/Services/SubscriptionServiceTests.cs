using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Implementation;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using Moq;

namespace Application.UnitTests.Services
{
    public class SubscriptionServiceTests
    {
        private readonly Mock<IRepository<Subscription>> _mockRepository;
        private readonly Mock<ITransactionService> _transactionServiceMock;
        private readonly SubscriptionService _subscriptionService;

        public SubscriptionServiceTests()
        {
            _mockRepository = new Mock<IRepository<Subscription>>();
            _transactionServiceMock = new Mock<ITransactionService>();
            _subscriptionService = new SubscriptionService(_mockRepository.Object, _transactionServiceMock.Object);
        }

        [Fact]
        public async Task CloseSubscriptionAsync_ShouldDeleteAsync()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await _subscriptionService.CloseSubscriptionAsync(id);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(id), Times.Once);
        }

        [Fact]
        public async Task GetSubscriptionAsync_ShouldReturnSubscription()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await _subscriptionService.GetSubscriptionAsync(id);

            // Assert
            _mockRepository.Verify(repo => repo.GetByIdAsync(id), Times.Once);
        }

        [Fact]
        public async Task GetSubscriptionsAsync_ShouldReturnSubscriptions()
        {
            // Arrange
            int page = 1;
            int itemsPerPage = 10;

            // Act
            await _subscriptionService.GetSubscriptionsAsync(page, itemsPerPage);

            // Assert
            _mockRepository.Verify(repo => repo.GetByPageAsync(page, itemsPerPage), Times.Once);
        }

        [Fact]
        public async Task OpenSubscriptionAsync_ShouldAddsTransactionAndSubscription()
        {
            // Arrange
            var subscription = new Subscription { Service = new Service { Price = 50, Title = "Test Service" } };

            // Act
            await _subscriptionService.OpenSubscriptionAsync(subscription);

            // Assert
            _transactionServiceMock.Verify(service => service.AddTransactionAsync(It.IsAny<Transaction>()), Times.Once);
            _mockRepository.Verify(repo => repo.AddAsync(subscription), Times.Once);
        }

        [Fact]
        public async Task TotalCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var expectedCount = 5;
            _mockRepository.Setup(repo => repo.CountAsync()).ReturnsAsync(expectedCount);

            // Act
            var count = await _subscriptionService.TotalCount();

            // Assert
            Assert.Equal(expectedCount, count);
        }

        [Fact]
        public async Task UpdateSubscriptionAsync_ShouldUpdateAsync()
        {
            // Arrange
            var subscription = new Subscription() { Id = Guid.NewGuid() };

            // Act
            await _subscriptionService.UpdateSubscriptionAsync(subscription);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync(subscription), Times.Once);
        }
    }
}
