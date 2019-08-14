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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDBContext vegaDBContext;

        public VehicleRepository(VegaDBContext vegaDBContext)
        {
            this.vegaDBContext = vegaDBContext;
        }
        public  void CreateVehicle(Vehicle vehicle )
        {
            vegaDBContext.Vehicles.Add(vehicle);
        }
        public void Remove(Vehicle vehicle)
        {
            vegaDBContext.Remove(vehicle);
        }
        public void Add(Vehicle vehicle)
        {
            vegaDBContext.Add(vehicle);
        }
        public async Task<Vehicle> GetVehicle(int Id, bool IsIncludeRelated = true)
        {
            if(!IsIncludeRelated)
                return await vegaDBContext.Vehicles.FindAsync(Id);

            return await vegaDBContext.Vehicles
                .Include(v => v.VehicleFeature)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                .ThenInclude(vm => vm.Make)
                .SingleOrDefaultAsync(v => v.Id == Id);
        }
        public async Task<IEnumerable<Vehicle>> GetVehicle()
        {
            return await vegaDBContext.Vehicles
                .Include(v => v.VehicleFeature)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                .ThenInclude(vm => vm.Make).ToListAsync();
        }
    }
}
