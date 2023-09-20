using IronForgeFitness.Application.Database;
using IronForgeFitness.Application.Services.Interfaces;
using IronForgeFitness.Domain.Entities;

namespace IronForgeFitness.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepository<Service> _serviceRepository;

        public ServiceService(IRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task AddServiceAsync(Service service)
        {
            await _serviceRepository.AddAsync(service);
        }

        public async Task DeleteServiceAsync(Guid id)
        {
            await _serviceRepository.DeleteAsync(id);
        }

        public async Task<Service> GetServiceAsync(Guid id)
        {
            return await _serviceRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Service>> GetServicesAsync(int page, int itemsPerPage)
        {
            return await _serviceRepository.GetByPageAsync(page, itemsPerPage);
        }

        public async Task<int> TotalCount()
        {
            return await _serviceRepository.CountAsync();
        }

        public async Task UpdateServiceAsync(Service service)
        {
            await _serviceRepository.UpdateAsync(service);
        }
    }
}
