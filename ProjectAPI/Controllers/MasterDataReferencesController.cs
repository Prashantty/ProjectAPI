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
    public class MasterDataReferencesController : ControllerBase
    {
        private readonly NSTDbContext _context;

        public MasterDataReferencesController(NSTDbContext context)
        {
            _context = context;
        }

        // GET: api/MasterDataReferences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterDataReference>>> GetMasterDataReferences()
        {
          if (_context.MasterDataReferences == null)
          {
              return NotFound();
          }
            return await _context.MasterDataReferences.ToListAsync();
        }

        // GET: api/MasterDataReferences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MasterDataReference>> GetMasterDataReference(int id)
        {
          if (_context.MasterDataReferences == null)
          {
              return NotFound();
          }
            var masterDataReference = await _context.MasterDataReferences.FindAsync(id);

            if (masterDataReference == null)
            {
                return NotFound();
            }

            return masterDataReference;
        }

        // PUT: api/MasterDataReferences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterDataReference(int id, MasterDataReference masterDataReference)
        {
            if (id != masterDataReference.Id)
            {
                return BadRequest();
            }

            _context.Entry(masterDataReference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterDataReferenceExists(id))
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

        // POST: api/MasterDataReferences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MasterDataReference>> PostMasterDataReference(MasterDataReference masterDataReference)
        {
          if (_context.MasterDataReferences == null)
          {
              return Problem("Entity set 'NSTDbContext.MasterDataReferences'  is null.");
          }
            _context.MasterDataReferences.Add(masterDataReference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasterDataReference", new { id = masterDataReference.Id }, masterDataReference);
        }

        // DELETE: api/MasterDataReferences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterDataReference(int id)
        {
            if (_context.MasterDataReferences == null)
            {
                return NotFound();
            }
            var masterDataReference = await _context.MasterDataReferences.FindAsync(id);
            if (masterDataReference == null)
            {
                return NotFound();
            }

            _context.MasterDataReferences.Remove(masterDataReference);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasterDataReferenceExists(int id)
        {
            return (_context.MasterDataReferences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
