using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Persistence.Contexts;

namespace vega_application.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly VegaDBContext dBContext;

        public BaseRepository(VegaDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
    }
}
