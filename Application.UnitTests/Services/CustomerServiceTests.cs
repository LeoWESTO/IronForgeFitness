using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Implementation;
using IronForgeFitness.Domain.Entities;
using Moq;

namespace Application.UnitTests.Services
{
    public class CustomerServiceTests
    {
        private readonly Mock<IRepository<Customer>> _mockRepository;
        private readonly CustomerService _customerService;

        public CustomerServiceTests()
        {
            _mockRepository = new Mock<IRepository<Customer>>();
            _customerService = new CustomerService(_mockRepository.Object);
        }

        [Fact]
        public async Task AddCustomerAsync_ShouldAddCustomer()
        {
            // Arrange
            var customer = new Customer();

            // Act
            await _customerService.AddCustomerAsync(customer);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(customer), Times.Once);
        }

        [Fact]
        public async Task DeleteCustomerAsync_ShouldDeleteCustomer()
        {
            // Arrange
            var customerId = Guid.NewGuid();

            // Act
            await _customerService.DeleteCustomerAsync(customerId);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(customerId), Times.Once);
        }

        [Fact]
        public async Task GetCustomerAsync_ShouldReturnsCustomer()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var expectedCustomer = new Customer();

            _mockRepository.Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync(expectedCustomer);

            // Act
            var result = await _customerService.GetCustomerAsync(customerId);

            // Assert
            Assert.Equal(expectedCustomer, result);
        }

        [Fact]
        public async Task GetCustomersAsync_ShouldReturnsCustomers()
        {
            // Arrange
            var expectedCustomers = new List<Customer> { new Customer(), new Customer() };

            _mockRepository.Setup(repo => repo.GetByPageAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(expectedCustomers);

            // Act
            var result = await _customerService.GetCustomersAsync(1, 10);

            // Assert
            Assert.Equal(expectedCustomers, result);
        }

        [Fact]
        public async Task TotalCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var expectedCount = 10;

            _mockRepository.Setup(repo => repo.CountAsync())
                .ReturnsAsync(expectedCount);

            // Act
            var result = await _customerService.TotalCount();

            // Assert
            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public async Task UpdateCustomerAsync_ShouldUpdateCustomer()
        {
            // Arrange
            var customer = new Customer();

            // Act
            await _customerService.UpdateCustomerAsync(customer);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync(customer), Times.Once);
        }
    }
}
