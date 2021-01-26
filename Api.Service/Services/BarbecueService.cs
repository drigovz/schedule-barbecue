using Api.Domain.DTOs.Barbecues;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.BarbecueService;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class BarbecueService : IBarbecueService
    {
        private readonly IRepository<Barbecue> _repository;
        private readonly IMapper _mapper;

        public BarbecueService(IRepository<Barbecue> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BarbecueDTO>> GetAllAsync()
        {
            var barbecues = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<BarbecueDTO>>(barbecues);
        }

        public async Task<BarbecueDTO> GetAsync(int id)
        {
            var barbecue = await _repository.GetByIdAsync(id);
            return _mapper.Map<BarbecueDTO>(barbecue);
        }

        public async Task<BarbecueDTO> PostAsync(BarbecueDTO barbecue)
        {
            var entity = _mapper.Map<Barbecue>(barbecue);
            var result = await _repository.AddAsync(entity);

            return _mapper.Map<BarbecueDTO>(result);
        }

        public async Task<BarbecueDTO> PutAsync(BarbecueDTO barbecue)
        {
            var entity = _mapper.Map<Barbecue>(barbecue);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<BarbecueDTO>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
