using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vega_application.Domain.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        [StringLength(100)]
        public string ContactName { get; set; }
        [Required]
        [StringLength(20)]
        public string ContactPhone { get; set; }
        [StringLength(100)]
        public string ContactEmail { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<VehicleFeature> VehicleFeature{ get; set; }
        public Vehicle()
        {
            VehicleFeature = new Collection<VehicleFeature>();
        }
    }
}
