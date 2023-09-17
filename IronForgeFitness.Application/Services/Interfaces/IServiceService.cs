using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetServicesAsync(int page, int itemsPerPage);
        Task<Service> GetServiceAsync(Guid id);
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(Guid id);
        Task<int> TotalCount();
    }
}
