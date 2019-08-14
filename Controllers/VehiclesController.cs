using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;
using vega_application.Domain.Repositories;
using vega_application.Domain.Services;
using vega_application.Persistence.Contexts;
using vega_application.Resources;

namespace vega_application.Controllers
{
    [Route("/api/Vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IVehicleService vehicleService;

        public VehiclesController(IMapper mapper, IVehicleService vehicleService, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.vehicleService = vehicleService;
        }
        [HttpPost()]
        public async Task<IActionResult> CreateVehicle([FromBody]SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var model = await dBContext.Models.FindAsync(vehicleResource.ModelId);
            //if (model == null)
            //{
            //    ModelState.AddModelError("ModelId", "Invalid Model Id");
            //    return BadRequest(ModelState);
            //}
            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now.Date;
            vehicleService.CreateVehicle(vehicle);
            await unitOfWork.CompleteAsync();
            vehicle = await vehicleService.GetVehicle(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpateVehicle(int id, [FromBody]SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var vehicle = await vehicleService.GetVehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now.Date;
            await unitOfWork.CompleteAsync();
            vehicle = await vehicleService.GetVehicle(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await vehicleService.GetVehicle(id, IsIncludeRelated: false);
            if (vehicle == null)
            {
                return NotFound();
            }
            vehicleService.Remove(vehicle);
            await unitOfWork.CompleteAsync();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await vehicleService.GetVehicle(id, IsIncludeRelated: true);
            if (vehicle == null)
            {
                return NotFound();
            }
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetVehicle()
        {
            var vehicle = await vehicleService.GetVehicle();
           
            var result = mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicle);
            return Ok(result);
        }
    }
}
