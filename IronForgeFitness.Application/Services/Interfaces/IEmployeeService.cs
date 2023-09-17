using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int itemsPerPage);
        Task<Employee> GetEmployeeAsync(Guid id);
        Task HireEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task FireEmployeeAsync(Guid id);
        Task<int> TotalCount();
    }
}
