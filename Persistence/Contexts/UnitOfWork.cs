using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Repositories;

namespace vega_application.Persistence.Contexts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaDBContext vegaDBContext;

        public UnitOfWork(VegaDBContext vegaDBContext)
        {
            this.vegaDBContext = vegaDBContext;
        }
        public async Task CompleteAsync()
        {
            await vegaDBContext.SaveChangesAsync();
        }
    }
}
