using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Model;

namespace Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeGroupController : ControllerBase
    {
        private readonly EwayPortalDbContext _context;

        public EmployeeGroupController(EwayPortalDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeGroup>>> GetEmployeeGroups()
        {
            return await _context.EmployeeGroups.ToListAsync();
        }

        // GET: api/EmployeeGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeGroup>> GetEmployeeGroup(Guid id)
        {
            var employeeGroup = await _context.EmployeeGroups.FindAsync(id);

            if (employeeGroup == null)
            {
                return NotFound();
            }

            return employeeGroup;
        }

        // PUT: api/EmployeeGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeGroup(Guid id, EmployeeGroup employeeGroup)
        {
            if (id != employeeGroup.EmployeeGroupId)
            {
                return BadRequest();
            }

            if (_context.EmployeeGroups.Any(x => string.Equals(x.EmployeeGroupName, employeeGroup.EmployeeGroupName, StringComparison.OrdinalIgnoreCase) &&
                                            x.EmployeeGroupId != id))
                return Conflict("Employee group already exists!");

            _context.Entry(employeeGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeGroupExists(id))
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

        // POST: api/EmployeeGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeGroup>> PostEmployeeGroup(EmployeeGroup employeeGroup)
        {
            if (_context.EmployeeGroups.Any(x => string.Equals(x.EmployeeGroupName, employeeGroup.EmployeeGroupName, StringComparison.OrdinalIgnoreCase)))
                return Conflict("Employee group already exists!");

            _context.EmployeeGroups.Add(employeeGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeGroupExists(employeeGroup.EmployeeGroupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeGroup", new { id = employeeGroup.EmployeeGroupId }, employeeGroup);
        }

        // DELETE: api/EmployeeGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeGroup(Guid id)
        {
            var employeeGroup = await _context.EmployeeGroups.FindAsync(id);
            if (employeeGroup == null)
            {
                return NotFound();
            }

            _context.EmployeeGroups.Remove(employeeGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeGroupExists(Guid id)
        {
            return _context.EmployeeGroups.Any(e => e.EmployeeGroupId == id);
        }
    }
}
