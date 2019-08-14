using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;
using vega_application.Domain.Repositories;
using vega_application.Domain.Services;

namespace vega_application.Services
{
    public class Modelservice : IModelService
    {
        private readonly IModelRepository modelRepository;

        public Modelservice(IModelRepository modelRepository)
        {
            this.modelRepository = modelRepository;
        }
        public async Task<IEnumerable<Model>> ListAsync()
        {
            return await modelRepository.ListAsync();
        }
    }
}
