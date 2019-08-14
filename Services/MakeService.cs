using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;
using vega_application.Domain.Repositories;
using vega_application.Domain.Services;

namespace vega_application.Services
{
    public class MakeService : IMakeService
    {
        private readonly IMakeRepository repository;

        public MakeService(IMakeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Make>> ListAsync()
        {
            return await repository.ListAsync();
        }
    }
}
