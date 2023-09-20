using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;
using System;

namespace IronForgeFitness.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task FireEmployeeAsync(Guid id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<Employee> GetEmployeeAsync(Guid id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int itemsPerPage)
        {
            return await _employeeRepository.GetByPageAsync(page, itemsPerPage);
        }

        public async Task HireEmployeeAsync(Employee employee)
        {
            employee.DateOfHire = DateOnly.FromDateTime(DateTime.UtcNow);
            await _employeeRepository.AddAsync(employee);
        }

        public async Task<int> TotalCount()
        {
            return await _employeeRepository.CountAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }
    }
}
