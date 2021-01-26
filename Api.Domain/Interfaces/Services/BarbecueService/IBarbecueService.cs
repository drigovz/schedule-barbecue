using Api.Domain.DTOs.Barbecues;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.BarbecueService
{
    public interface IBarbecueService
    {
        Task<IEnumerable<BarbecueDTO>> GetAllAsync();
        Task<BarbecueDTO> GetAsync(int id);
        Task<BarbecueDTO> PostAsync(BarbecueDTO category);
        Task<BarbecueDTO> PutAsync(BarbecueDTO category);
        Task<bool> DeleteAsync(int id);
    }
}
