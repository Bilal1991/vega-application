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
    public class MakeRepository : BaseRepository, IMakeRepository
    {
        public MakeRepository(VegaDBContext dBContext):base(dBContext)
        {

        }
        public async Task<IEnumerable<Make>> ListAsync()
        {
            return await dBContext.Makes.Include(m => m.Models).ToListAsync();
        }
    }
}
