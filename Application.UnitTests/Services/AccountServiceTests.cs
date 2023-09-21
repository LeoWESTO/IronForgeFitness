using Moq;
using IronForgeFitness.Application.Database;
using IronForgeFitness.Domain.Entities;
using IronForgeFitness.Application.Services.Implementation;

namespace Application.UnitTests.Services
{
    public class AccountServiceTests
    {
        private readonly Mock<IRepository<Account>> _mockRepository;
        private readonly AccountService _accountService;

        public AccountServiceTests()
        {
            _mockRepository = new Mock<IRepository<Account>>();
            _accountService = new AccountService(_mockRepository.Object);
        }

        [Fact]
        public async Task DeleteAccountAsync_ShouldDeleteAccount()
        {
            // Arrange
            Guid accountId = Guid.NewGuid();

            // Act
            await _accountService.DeleteAccountAsync(accountId);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(accountId), Times.Once);
        }

        [Fact]
        public async Task GetAccountAsync_ShouldReturnAccount()
        {
            // Arrange
            Guid accountId = Guid.NewGuid();
            Account expectedAccount = new Account { Id = accountId };
            _mockRepository.Setup(repo => repo.GetByIdAsync(accountId)).ReturnsAsync(expectedAccount);

            // Act
            var result = await _accountService.GetAccountAsync(accountId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAccount, result);
        }

        [Fact]
        public async Task GetAccountsAsync_ShouldReturnAccounts()
        {
            // Arrange
            var page = 1;
            var itemsPerPage = 10;
            var expectedAccounts = new List<Account>
            {
                new Account { Id = Guid.NewGuid() },
                new Account { Id = Guid.NewGuid() },
            };

            _mockRepository.Setup(repo => repo.GetByPageAsync(page, itemsPerPage))
                .ReturnsAsync(expectedAccounts);

            // Act
            var result = await _accountService.GetAccountsAsync(page, itemsPerPage);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAccounts, result);
        }

        [Fact]
        public async Task GetByEmail_ValidEmail_ShouldReturnsAccount()
        {
            // Arrange
            string emailToFind = "test@example.com";

            var accounts = new List<Account>
            {
                new Account { Email = "test@example.com" },
                new Account { Email = "another@example.com" }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(accounts);

            // Act
            var result = await _accountService.GetByEmail(emailToFind);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(emailToFind, result.Email);
        }

        [Fact]
        public async Task SignUpAsync_ShouldAddsAccount()
        {
            // Arrange
            var accountToAdd = new Account { Email = "test@example.com" };

            // Act
            await _accountService.SignUpAsync(accountToAdd);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(accountToAdd), Times.Once());
        }

        [Fact]
        public async Task TotalCount_ShouldReturnCorrectCount()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.CountAsync()).ReturnsAsync(5);

            // Act
            var totalCount = await _accountService.TotalCount();

            // Assert
            Assert.Equal(5, totalCount);
        }

        [Fact]
        public async Task UpdateAccountAsync_ShouldUpdateAccount()
        {
            // Arrange
            var account = new Account { Email = "test@example.com" };
            _mockRepository.Setup(repo => repo.UpdateAsync(account)).Returns(Task.CompletedTask);

            // Act
            await _accountService.UpdateAccountAsync(account);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync(account), Times.Once);
        }
    }
}
