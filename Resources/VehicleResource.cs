using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace vega_application.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public KeyValueResource model { get; set; }
        public bool isRegistered { get; set; }
        public ContactResource contact{ get; set; }
        public DateTime lastUpdate { get; set; }
        public KeyValueResource make { get; set; }
        public ICollection<KeyValueResource> feature { get; set; }
        public VehicleResource()
        {
            feature = new Collection<KeyValueResource>();
        }
    }
}
