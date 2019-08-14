using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace vega_application.Resources
{
    public class MakesResource:KeyValueResource
    {
        public ICollection<KeyValueResource> models { get; set; }
        public MakesResource()
        {
            models = new Collection<KeyValueResource>();
        }
    }
}
