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
    public class UserRoleMappingsController : ControllerBase
    {
        private readonly NSTDbContext _context;

        public UserRoleMappingsController(NSTDbContext context)
        {
            _context = context;
        }

        // GET: api/UserRoleMappings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoleMapping>>> GetUserRoleMappings()
        {
          if (_context.UserRoleMappings == null)
          {
              return NotFound();
          }
            return await _context.UserRoleMappings.ToListAsync();
        }

        // GET: api/UserRoleMappings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleMapping>> GetUserRoleMapping(int id)
        {
          if (_context.UserRoleMappings == null)
          {
              return NotFound();
          }
            var userRoleMapping = await _context.UserRoleMappings.FindAsync(id);

            if (userRoleMapping == null)
            {
                return NotFound();
            }

            return userRoleMapping;
        }

        // PUT: api/UserRoleMappings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRoleMapping(int id, UserRoleMapping userRoleMapping)
        {
            if (id != userRoleMapping.Id)
            {
                return BadRequest();
            }

            _context.Entry(userRoleMapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoleMappingExists(id))
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

        // POST: api/UserRoleMappings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRoleMapping>> PostUserRoleMapping(UserRoleMapping userRoleMapping)
        {
          if (_context.UserRoleMappings == null)
          {
              return Problem("Entity set 'NSTDbContext.UserRoleMappings'  is null.");
          }
            _context.UserRoleMappings.Add(userRoleMapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRoleMapping", new { id = userRoleMapping.Id }, userRoleMapping);
        }

        // DELETE: api/UserRoleMappings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRoleMapping(int id)
        {
            if (_context.UserRoleMappings == null)
            {
                return NotFound();
            }
            var userRoleMapping = await _context.UserRoleMappings.FindAsync(id);
            if (userRoleMapping == null)
            {
                return NotFound();
            }

            _context.UserRoleMappings.Remove(userRoleMapping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRoleMappingExists(int id)
        {
            return (_context.UserRoleMappings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
