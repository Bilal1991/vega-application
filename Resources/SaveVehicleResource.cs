using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;

namespace vega_application.Resources
{
    public class SaveVehicleResource
    {

        public int id { get; set; }
        public int modelId { get; set; }
        
        public bool isRegistered { get; set; }

        [Required]
        public ContactResource contact{ get; set; }
        public ICollection<int> feature { get; set; }
        public SaveVehicleResource()
        {
            feature = new Collection<int>();
        }
    }
}
