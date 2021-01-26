using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.BarbecueService
{
    public interface IBarbecueService
    {
        Task<IEnumerable<Barbecue>> GetAllAsync();
        Task<Barbecue> GetAsync(int id);
        Task<Barbecue> PostAsync(Barbecue category);
        Task<Barbecue> PutAsync(Barbecue category);
        Task<bool> DeleteAsync(int id);
    }
}
