using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;

namespace vega_application.Domain.Repositories
{
    public interface IVehicleRepository
    {
        public Task<Vehicle> GetVehicle(int Id, bool IsIncludeRelated=true);
        public Task<IEnumerable<Vehicle>> GetVehicle();
        public void CreateVehicle(Vehicle vehicle);
        public void Remove(Vehicle vehicle);
        public void Add(Vehicle vehicle);
    }
}
