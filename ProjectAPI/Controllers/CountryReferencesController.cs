using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Context;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryReferencesController : ControllerBase
    {
        private readonly NSTDbContext _context;

        public CountryReferencesController(NSTDbContext context)
        {
            _context = context;
        }

        // GET: api/CountryReferences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryReference>>> GetCountryReferences()
        {
          if (_context.CountryReferences == null)
          {
              return NotFound();
          }
            return await _context.CountryReferences.ToListAsync();
        }

        // GET: api/CountryReferences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryReference>> GetCountryReference(int id)
        {
          if (_context.CountryReferences == null)
          {
              return NotFound();
          }
            var countryReference = await _context.CountryReferences.FindAsync(id);

            if (countryReference == null)
            {
                return NotFound();
            }

            return countryReference;
        }

        // PUT: api/CountryReferences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryReference(int id, CountryReference countryReference)
        {
            if (id != countryReference.Id)
            {
                return BadRequest();
            }

            _context.Entry(countryReference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryReferenceExists(id))
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

        // POST: api/CountryReferences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryReference>> PostCountryReference(CountryReference countryReference)
        {
          if (_context.CountryReferences == null)
          {
              return Problem("Entity set 'NSTDbContext.CountryReferences'  is null.");
          }
            _context.CountryReferences.Add(countryReference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryReference", new { id = countryReference.Id }, countryReference);
        }

        // DELETE: api/CountryReferences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryReference(int id)
        {
            if (_context.CountryReferences == null)
            {
                return NotFound();
            }
            var countryReference = await _context.CountryReferences.FindAsync(id);
            if (countryReference == null)
            {
                return NotFound();
            }

            _context.CountryReferences.Remove(countryReference);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryReferenceExists(int id)
        {
            return (_context.CountryReferences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
