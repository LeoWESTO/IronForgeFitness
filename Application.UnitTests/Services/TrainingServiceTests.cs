using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Implementation;
using IronForgeFitness.Domain.Entities;
using Moq;

namespace Application.UnitTests.Services
{
    public class TrainingServiceTests
    {
        private readonly Mock<IRepository<Training>> _mockRepository;
        private readonly TrainingService _trainingService;

        public TrainingServiceTests()
        {
            _mockRepository = new Mock<IRepository<Training>>();
            _trainingService = new TrainingService(_mockRepository.Object);
        }

        [Fact]
        public async Task DeleteTrainingAsync_ShouldDeleteAsync()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await _trainingService.DeleteTrainingAsync(id);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(id), Times.Once);
        }

        [Fact]
        public async Task GetTrainingAsync_ShouldReturnTraining()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedTraining = new Training { Id = id };

            _mockRepository.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(expectedTraining);

            // Act
            var result = await _trainingService.GetTrainingAsync(id);

            // Assert
            _mockRepository.Verify(repo => repo.GetByIdAsync(id), Times.Once);
            Assert.Equal(expectedTraining, result);
        }

        [Fact]
        public async Task GetTrainingsAsync_ShouldReturnTrainings()
        {
            // Arrange
            var page = 1;
            var itemsPerPage = 10;
            var expectedTrainings = new List<Training>
            {
                new Training() { DateTime = DateTime.Now, Id = Guid.NewGuid() },
                new Training() { DateTime = DateTime.Now, Id = Guid.NewGuid() },
            };

            _mockRepository.Setup(repo => repo.GetByPageAsync(page, itemsPerPage)).ReturnsAsync(expectedTrainings);

            // Act
            var result = await _trainingService.GetTrainingsAsync(page, itemsPerPage);

            // Assert
            _mockRepository.Verify(repo => repo.GetByPageAsync(page, itemsPerPage), Times.Once);
            Assert.Equal(expectedTrainings, result);
        }

        [Fact]
        public async Task ScheduleTrainingAsync_ShouldAddAsync()
        {
            // Arrange
            var training = new Training();

            // Act
            await _trainingService.ScheduleTrainingAsync(training);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(training), Times.Once);
        }

        [Fact]
        public async Task TotalCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var expectedCount = 42;

            _mockRepository.Setup(repo => repo.CountAsync()).ReturnsAsync(expectedCount);

            // Act
            var result = await _trainingService.TotalCount();

            // Assert
            _mockRepository.Verify(repo => repo.CountAsync(), Times.Once);
            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public async Task UpdateTrainingAsync_ShouldUpdateAsync()
        {
            // Arrange
            var training = new Training();

            // Act
            await _trainingService.UpdateTrainingAsync(training);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync(training), Times.Once);
        }
    }
}
