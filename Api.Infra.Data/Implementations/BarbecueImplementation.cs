using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Infra.Data.Context;
using Api.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Infra.Data.Implementations
{
    public class BarbecueImplementation : BaseRepository<Barbecue>, IBarbecueRepository
    {
        private readonly DbSet<Barbecue> _dataset;

        public BarbecueImplementation(AppDbContext context)
            : base(context)
        {
            _dataset = context.Set<Barbecue>();
        }

        public async Task<IEnumerable<Participant>> BarbecueParticipants(int barbecueId)
        {
            var barbecue = await _dataset.FirstOrDefaultAsync(x => x.Id == barbecueId);
            return barbecue.Participants;
        }
    }
}
