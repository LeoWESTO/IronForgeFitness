using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Implementation;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using IronForgeFitness.Domain.Enums;
using Moq;

namespace Application.UnitTests.Services
{
    public class ItemServiceTests
    {
        private readonly Mock<IRepository<Item>> _mockRepository;
        private readonly Mock<ITransactionService> _transactionServiceMock;
        private readonly ItemService _itemService;

        public ItemServiceTests()
        {
            _mockRepository = new Mock<IRepository<Item>>();
            _transactionServiceMock = new Mock<ITransactionService>();
            _itemService = new ItemService(_mockRepository.Object, _transactionServiceMock.Object);
        }

        [Fact]
        public async Task BuyItemAsync_ShouldAddTransactionAndAddItem()
        {
            // Arrange
            var item = new Item { Id = Guid.NewGuid(), Price = 20000 };

            // Act
            await _itemService.BuyItemAsync(item);

            // Assert
            _transactionServiceMock.Verify(x => x.AddTransactionAsync(It.IsAny<Transaction>()), Times.Once);
            _mockRepository.Verify(x => x.AddAsync(It.IsAny<Item>()), Times.Once);
        }

        [Fact]
        public async Task GetItemAsync_ShouldReturnItem()
        {
            // Arrange
            var itemId = Guid.NewGuid();
            var expectedItem = new Item { Id = itemId, Title = "Test Item", Price = 100.0M };
            _mockRepository.Setup(repo => repo.GetByIdAsync(itemId)).ReturnsAsync(expectedItem);

            // Act
            var result = await _itemService.GetItemAsync(itemId);

            // Assert
            Assert.Equal(expectedItem, result);
        }

        [Fact]
        public async Task GetItemsAsync_ShouldReturnItems()
        {
            // Arrange

            var items = new List<Item> { new Item { Id = Guid.NewGuid(), Title = "Item 1" } };
            _mockRepository.Setup(repo => repo.GetByPageAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(items);

            // Act
            var result = await _itemService.GetItemsAsync(1, 10);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task SellItemAsync_ShouldAddTransactionAndDeleteItem()
        {
            // Arrange
            var itemId = Guid.NewGuid();
            var item = new Item { Id = itemId, Title = "Item 1" };

            _mockRepository.Setup(repo => repo.GetByIdAsync(itemId)).ReturnsAsync(item);
            _mockRepository.Setup(repo => repo.DeleteAsync(itemId)).Returns(Task.CompletedTask);

            // Act
            await _itemService.SellItemAsync(itemId, 100.0m);

            // Assert
            _transactionServiceMock.Verify(
                mock => mock.AddTransactionAsync(It.Is<Transaction>(
                    t => t.Amount == -100.0m && t.Type == TransactionType.Sale)),
                Times.Once);

            _mockRepository.Verify(mock => mock.DeleteAsync(itemId), Times.Once);
        }

        [Fact]
        public async Task TotalCount_ShouldReturnCorrectCount()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.CountAsync()).ReturnsAsync(10);

            // Act
            var result = await _itemService.TotalCount();

            // Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public async Task UpdateItemAsync_ShouldUpdateItem()
        {
            // Arrange
            var item = new Item { Id = Guid.NewGuid(), Title = "Item 1" };
            _mockRepository.Setup(repo => repo.UpdateAsync(item)).Returns(Task.CompletedTask);

            // Act
            await _itemService.UpdateItemAsync(item);

            // Assert
            _mockRepository.Verify(mock => mock.UpdateAsync(item), Times.Once);
        }
    }
}
