using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;
using vega_application.Domain.Repositories;
using vega_application.Persistence.Contexts;

namespace vega_application.Persistence.Repositories
{
    public class FeatureRepository : BaseRepository, IFeatureRepository
    {
        public FeatureRepository(VegaDBContext dBContext):base(dBContext)
        {

        }
        public async Task<IEnumerable<Feature>> ListAsync()
        {
           return await dBContext.Features.ToListAsync();
        }
    }
}
