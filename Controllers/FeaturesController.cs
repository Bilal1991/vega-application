using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega_application.Domain.Models;
using vega_application.Domain.Services;
using vega_application.Persistence.Contexts;
using vega_application.Resources;

namespace vega_application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : Controller
    {
        private readonly IFeatureService service;
        private readonly IMapper mapper;

        public FeaturesController(IFeatureService Service, IMapper mapper)
        {
            service = Service;
            this.mapper = mapper;
        }

        // GET: api/Features
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feature>>> GetFeatures()
        {
            var Features = await service.ListAsync();
            return Ok(mapper.Map<IEnumerable<Feature>, IEnumerable<KeyValueResource>>(Features));
        }

        // GET: api/Features/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            // var feature = await _context.Features.FindAsync(id);
            var feature = await service.ListAsync();
            if (feature == null)
            {
                return NotFound();
            }

            return Ok( feature);
        }

        // PUT: api/Features/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeature(int id, Feature feature)
        {
            if (id != feature.Id)
            {
                return BadRequest();
            }

            //_context.Entry(feature).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Features
        [HttpPost]
        public async Task<ActionResult<Feature>> PostFeature(Feature feature)
        {
           // _context.Features.Add(feature);
           // await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeature", new { id = feature.Id }, feature);
        }

        // DELETE: api/Features/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feature>> DeleteFeature(int id)
        {
            //var feature = await _context.Features.FindAsync(id);
            var feature = await service.ListAsync();
            if (feature == null)
            {
                return NotFound();
            }

            //_context.Features.Remove(feature);
            //await _context.SaveChangesAsync();

            return Ok(feature);
        }

        private bool FeatureExists(int id)
        {
            return true;
            //return _context.Features.Any(e => e.Id == id);
        }
    }
}
