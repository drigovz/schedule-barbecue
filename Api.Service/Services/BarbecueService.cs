using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.BarbecueService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class BarbecueService : IBarbecueService
    {
        private readonly IRepository<Barbecue> _repository;

        public BarbecueService(IRepository<Barbecue> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Barbecue>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Barbecue> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Barbecue> PostAsync(Barbecue barbecue)
        {
            return await _repository.AddAsync(barbecue);
        }

        public async Task<Barbecue> PutAsync(Barbecue barbecue)
        {
            return await _repository.UpdateAsync(barbecue);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
