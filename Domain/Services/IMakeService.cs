﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;

namespace vega_application.Domain.Services
{
    public interface IMakeService
    {
        public Task<IEnumerable<Make>> ListAsync();
    }
}
