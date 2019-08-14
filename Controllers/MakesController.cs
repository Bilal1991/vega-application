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
using vega_application.Extensions;

namespace vega_application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : Controller
    {
       // private readonly VegaDBContext _context;
        private readonly IMakeService service;

        public IMapper Mapper { get; }

        public MakesController(IMakeService service, IMapper mapper)
        {
            //_context = context;
            this.service = service;
            Mapper = mapper;
        }

        // GET: api/Makes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MakesResource>>> GetMakes()
        {
            //var makes = await _context.Makes.Include(m => m.Models).ToListAsync();
            var makes = await service.ListAsync();
            return Ok(Mapper.Map<IEnumerable<Make>, IEnumerable<MakesResource>>(makes));
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMake(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var make = await service.ListAsync();
            if (make == null)
            {
                return NotFound();
            }

            return Ok(make);
        }

        // PUT: api/Makes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Make make)
        {
            if (id != make.Id)
            {
                return BadRequest();
            }

           // _context.Entry(make).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MakeExists(id))
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

        // POST: api/Makes
        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Make make)
        {
            //_context.Makes.Add(make);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetMake", new { id = make.Id }, make);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Make>> DeleteMake(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var make = await service.ListAsync();
            if (make == null)
            {
                return NotFound();
            }

           // _context.Makes.Remove(make);
            //await _context.SaveChangesAsync();

            return Ok(make);
        }

        private bool MakeExists(int id)
        {
            return true;
            //return _context.Makes.Any(e => e.Id == id);
        }
    }
}
