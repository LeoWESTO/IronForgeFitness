using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Implementation;
using IronForgeFitness.Domain.Entities;
using Moq;

namespace Application.UnitTests.Services
{
    public class ServiceServiceTests
    {
        private readonly Mock<IRepository<Service>> _mockRepository;
        private readonly ServiceService _serviceService;

        public ServiceServiceTests()
        {
            _mockRepository = new Mock<IRepository<Service>>();
            _serviceService = new ServiceService(_mockRepository.Object);
        }

        [Fact]
        public async Task AddServiceAsync_ShouldAddService()
        {
            // Arrange
            var service = new Service();

            // Act
            await _serviceService.AddServiceAsync(service);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(service), Times.Once);
        }

        [Fact]
        public async Task DeleteServiceAsync_ShouldDeleteService()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await _serviceService.DeleteServiceAsync(id);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(id), Times.Once);
        }

        [Fact]
        public async Task GetServiceAsync_ShouldReturnService()
        {
            // Arrange
            var id = Guid.NewGuid();
            var service = new Service();
            _mockRepository.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(service);

            // Act
            var result = await _serviceService.GetServiceAsync(id);

            // Assert
            Assert.Equal(service, result);
        }

        [Fact]
        public async Task GetServicesAsync_ShouldReturnServices()
        {
            // Arrange
            var expectedServices = new List<Service> 
            {
                new Service() { Id = Guid.NewGuid() },
                new Service() { Id = Guid.NewGuid() },
            };
            _mockRepository.Setup(repo => repo.GetByPageAsync(It.IsAny<int>(), It.IsAny<int>()))
                          .ReturnsAsync(expectedServices);

            // Act
            var result = await _serviceService.GetServicesAsync(1, 10);

            // Assert
            Assert.Equal(expectedServices, result);
        }

        [Fact]
        public async Task TotalCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var expectedTotalCount = 10;
            _mockRepository.Setup(repo => repo.CountAsync())
                          .ReturnsAsync(expectedTotalCount);

            // Act
            var result = await _serviceService.TotalCount();

            // Assert
            Assert.Equal(expectedTotalCount, result);
        }

        [Fact]
        public async Task UpdateServiceAsync_ShouldUpdateService()
        {
            // Arrange
            var serviceToUpdate = new Service() { Id = Guid.NewGuid() };

            // Act
            await _serviceService.UpdateServiceAsync(serviceToUpdate);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync(serviceToUpdate), Times.Once());
        }
    }
}
