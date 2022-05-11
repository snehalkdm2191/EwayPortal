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
    public class EmployeeContentController : ControllerBase
    {
        private readonly EwayPortalDbContext _context;

        public EmployeeContentController(EwayPortalDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeContent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeContent>>> GetEmployeeContents()
        {
            return await _context.EmployeeContents.ToListAsync();
        }

        // GET: api/EmployeeContent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeContent>> GetEmployeeContent(Guid id)
        {
            var employeeContent = await _context.EmployeeContents.FindAsync(id);

            if (employeeContent == null)
            {
                return NotFound();
            }

            return employeeContent;
        }
        
        [HttpGet("EmployeeContent/{employeeid}")]
        public async Task<ActionResult> GetEmployeeContentByEmployeeId(Guid employeeid)
        {
            var employeeInfo = await _context.Employees.FindAsync(employeeid);

            var employeeContentData = _context.EmployeeContents.Where(x => x.Employeeid == employeeid).Select(x => new
            {
                ContentId = x.ContentGroup.ContentId,
                ContentGroupId = x.ContentGroup.ContentGroupId,
                EmployeeContentId = x.EmployeeContentId,
                ContentHeader = x.ContentGroup.Content.ContentHeader,
                ContentValue = x.Content
            });

            var existingContentId = employeeContentData.Select(x => x.ContentId);

            var contentMasterData = _context.ContentGroups.Where(x => !existingContentId.Contains(x.ContentId) && x.EmployeeGroupId == employeeInfo.EmployeeGroupId).Select(x => new
            {
                ContentHeader = x.Content.ContentHeader,
                ContentGroupId = x.ContentGroupId
            });

            return Ok(new
            {
                EmployeeContent = employeeContentData,
                ContentList = contentMasterData
            });
        }

        // PUT: api/EmployeeContent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeContent(Guid id, EmployeeContent employeeContent)
        {
            if (id != employeeContent.EmployeeContentId)
            {
                return BadRequest();
            }

            _context.Entry(employeeContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeContentExists(id))
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

        // POST: api/EmployeeContent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeContent>> PostEmployeeContent(EmployeeContent employeeContent)
        {
            if (_context.EmployeeContents.Any(x => x.Employeeid == employeeContent.Employeeid && x.ContentGroupId == employeeContent.ContentGroupId))
                return Conflict("Content already exists for employee!");

            _context.EmployeeContents.Add(employeeContent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeContentExists(employeeContent.EmployeeContentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeContent", new { id = employeeContent.EmployeeContentId }, employeeContent);
        }

        // DELETE: api/EmployeeContent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeContent(Guid id)
        {
            var employeeContent = await _context.EmployeeContents.FindAsync(id);
            if (employeeContent == null)
            {
                return NotFound();
            }

            _context.EmployeeContents.Remove(employeeContent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeContentExists(Guid id)
        {
            return _context.EmployeeContents.Any(e => e.EmployeeContentId == id);
        }
    }
}
