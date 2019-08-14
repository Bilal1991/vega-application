using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;
using vega_application.Domain.Repositories;
using vega_application.Persistence.Contexts;

namespace vega_application.Persistence.Repositories
{
    public class ModelRepository : BaseRepository,IModelRepository
    {
        public ModelRepository(VegaDBContext dbContext):base(dbContext)
        {

        }
        public Task<IEnumerable<Model>> ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
