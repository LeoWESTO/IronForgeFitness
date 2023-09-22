using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Implementation;
using IronForgeFitness.Domain.Entities;
using Moq;

namespace Application.UnitTests.Services
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IRepository<Employee>> _mockRepository;
        private readonly EmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            _mockRepository = new Mock<IRepository<Employee>>();
            _employeeService = new EmployeeService(_mockRepository.Object);
        }

        [Fact]
        public async Task FireEmployeeAsync_ShouldDeleteEmployee()
        {
            // Arrange
            var employeeId = Guid.NewGuid();

            // Act
            await _employeeService.FireEmployeeAsync(employeeId);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync(employeeId), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeAsync_ShouldReturnEmployee()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var expectedEmployee = new Employee { Id = employeeId };
            _mockRepository.Setup(repo => repo.GetByIdAsync(employeeId)).ReturnsAsync(expectedEmployee);

            // Act
            var result = await _employeeService.GetEmployeeAsync(employeeId);

            // Assert
            Assert.Equal(expectedEmployee, result);
        }

        [Fact]
        public async Task GetEmployeesAsync_ShouldReturnEmployees()
        {
            // Arrange
            var page = 1;
            var itemsPerPage = 10;
            var expectedEmployees = new List<Employee> 
            { 
                new Employee { Id = Guid.NewGuid(), FirstName = "John" },
                new Employee { Id = Guid.NewGuid(), FirstName = "Den" },
            };

            _mockRepository.Setup(repo => repo.GetByPageAsync(page, itemsPerPage))
                           .ReturnsAsync(expectedEmployees);

            // Act
            var result = await _employeeService.GetEmployeesAsync(page, itemsPerPage);

            // Assert
            Assert.Equal(expectedEmployees, result);
        }

        [Fact]
        public async Task HireEmployeeAsync_ShouldHireEmployee()
        {
            // Arrange
            var employee = new Employee { FirstName = "Jane" };

            // Act
            await _employeeService.HireEmployeeAsync(employee);

            // Assert
            Assert.NotEqual(default, employee.DateOfHire);
            _mockRepository.Verify(repo => repo.AddAsync(employee), Times.Once);
        }

        [Fact]
        public async Task TotalCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var totalCount = 10;
            _mockRepository.Setup(repo => repo.CountAsync()).ReturnsAsync(totalCount);

            // Act
            var result = await _employeeService.TotalCount();

            // Assert
            Assert.Equal(totalCount, result);
        }

        [Fact]
        public async Task UpdateEmployeeAsync_UpdatesEmployee()
        {
            // Arrange
            var employee = new Employee { Id = Guid.NewGuid(), FirstName = "John" };

            // Act
            await _employeeService.UpdateEmployeeAsync(employee);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync(employee), Times.Once);
        }
    }
}
