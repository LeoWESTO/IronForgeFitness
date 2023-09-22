using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Implementation;
using IronForgeFitness.Domain.Entities;
using Moq;

namespace Application.UnitTests.Services
{
    public class GymServiceTests
    {
        private readonly Mock<IRepository<Gym>> _mockRepository;
        private readonly GymService _gymService;

        public GymServiceTests()
        {
            _mockRepository = new Mock<IRepository<Gym>>();
            _gymService = new GymService(_mockRepository.Object);
        }

        [Fact]
        public async Task CloseGymAsync_ShouldDeletesGym()
        {
            // Arrange
            var gymId = Guid.NewGuid();

            // Act
            await _gymService.CloseGymAsync(gymId);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(gymId), Times.Once);
        }

        [Fact]
        public async Task GetGymAsync_ShouldReturnGym()
        {
            // Arrange
            var gymId = Guid.NewGuid();
            var expectedGym = new Gym { Id = gymId };
            _mockRepository.Setup(repo => repo.GetByIdAsync(gymId)).ReturnsAsync(expectedGym);

            // Act
            var result = await _gymService.GetGymAsync(gymId);

            // Assert
            Assert.Equal(expectedGym, result);
        }

        [Fact]
        public async Task GetGymsAsync_ShouldReturnGyms()
        {
            // Arrange
            var expectedGyms = new List<Gym> { new Gym(), new Gym() };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedGyms);

            // Act
            var gyms = await _gymService.GetGymsAsync();

            // Assert
            Assert.Equal(expectedGyms, gyms);
        }

        [Fact]
        public async Task OpenGymAsync_ShouldAddGym()
        {
            // Arrange
            var gym = new Gym();

            // Act
            await _gymService.OpenGymAsync(gym);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(gym), Times.Once);
        }

        [Fact]
        public async Task TotalCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var expectedCount = 5;
            _mockRepository.Setup(repo => repo.CountAsync()).ReturnsAsync(expectedCount);

            // Act
            var count = await _gymService.TotalCount();

            // Assert
            Assert.Equal(expectedCount, count);
        }

        [Fact]
        public async Task UpdateGymAsync_ShouldUpdateGym()
        {
            // Arrange
            var gym = new Gym() { Id = Guid.NewGuid() };

            // Act
            await _gymService.UpdateGymAsync(gym);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync(gym), Times.Once);
        }
    }
}
