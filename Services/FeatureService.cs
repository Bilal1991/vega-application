using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;
using vega_application.Domain.Repositories;
using vega_application.Domain.Services;

namespace vega_application.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }
        public async Task<IEnumerable<Feature>> ListAsync()
        {
            return await featureRepository.ListAsync();
        }
    }
}
