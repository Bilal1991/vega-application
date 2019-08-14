using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;
using vega_application.Domain.Repositories;
using vega_application.Domain.Services;

namespace vega_application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public void CreateVehicle(Vehicle vehicle)
        {
            vehicleRepository.CreateVehicle(vehicle);
        }
        public async Task<Vehicle> GetVehicle(int Id,bool IsIncludeRelated =true)
        {
            return await vehicleRepository.GetVehicle(Id, IsIncludeRelated);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicle()
        {
            return await vehicleRepository.GetVehicle();
        }

        public void Remove(Vehicle vehicle)
        {
            vehicleRepository.Remove(vehicle);
        }
    }
}
