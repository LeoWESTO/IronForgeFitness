using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Implementation;
using IronForgeFitness.Domain.Entities;
using Moq;

namespace Application.UnitTests.Services
{
    public class TransactionServiceTests
    {
        private readonly Mock<IRepository<Transaction>> _mockRepository;
        private readonly TransactionService _transactionService;

        public TransactionServiceTests()
        {
            _mockRepository = new Mock<IRepository<Transaction>>();
            _transactionService = new TransactionService(_mockRepository.Object);
        }

        [Fact]
        public async Task AddTransactionAsync_ShouldAddAsync()
        {
            // Arrange
            var transaction = new Transaction();

            // Act
            await _transactionService.AddTransactionAsync(transaction);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(transaction), Times.Once);
        }

        [Fact]
        public async Task DeleteTransactionAsync_ShouldDeleteAsync()
        {
            // Arrange
            var transactionId = Guid.NewGuid();

            // Act
            await _transactionService.DeleteTransactionAsync(transactionId);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(transactionId), Times.Once);
        }

        [Fact]
        public async Task GetTransactionAsync_ShouldReturnTransaction()
        {
            // Arrange
            var transactionId = Guid.NewGuid();

            // Act
            await _transactionService.GetTransactionAsync(transactionId);

            // Assert
            _mockRepository.Verify(repo => repo.GetByIdAsync(transactionId), Times.Once);
        }

        [Fact]
        public async Task GetTransactionsAsync_ShouldReturnTransactions()
        {
            // Arrange
            var page = 1;
            var itemsPerPage = 10;

            // Act
            await _transactionService.GetTransactionsAsync(page, itemsPerPage);

            // Assert
            _mockRepository.Verify(repo => repo.GetByPageAsync(page, itemsPerPage), Times.Once);
        }

        [Fact]
        public async Task TotalCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var expectedTotalCount = 10;
            _mockRepository.Setup(repo => repo.CountAsync())
                          .ReturnsAsync(expectedTotalCount);

            // Act
            var result = await _transactionService.TotalCount();

            // Assert
            Assert.Equal(expectedTotalCount, result);
        }

        [Fact]
        public async Task UpdateTransactionAsync_ShouldUpdateAsync()
        {
            // Arrange
            var transaction = new Transaction();

            // Act
            await _transactionService.UpdateTransactionAsync(transaction);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync(transaction), Times.Once);
        }
    }
}
