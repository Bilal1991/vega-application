using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;

namespace vega_application.Domain.Services
{
    public interface IVehicleService
    {
        public void CreateVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicle(int Id, bool IsIncludeRelated = true);
        Task<IEnumerable<Vehicle>> GetVehicle();
        void Remove(Vehicle vehicle);

    }
}
