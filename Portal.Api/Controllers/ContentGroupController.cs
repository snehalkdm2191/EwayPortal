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
    public class ContentGroupController : ControllerBase
    {
        private readonly EwayPortalDbContext _context;

        public ContentGroupController(EwayPortalDbContext context)
        {
            _context = context;
        }

        // GET: api/ContentGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentGroup>>> GetContentGroups()
        {
            return await _context.ContentGroups.ToListAsync();
        }

        // GET: api/ContentGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentGroup>> GetContentGroup(Guid id)
        {
            var contentGroup = await _context.ContentGroups.FindAsync(id);

            if (contentGroup == null)
            {
                return NotFound();
            }

            return contentGroup;
        }

        // PUT: api/ContentGroup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentGroup(Guid id, ContentGroup contentGroup)
        {
            if (id != contentGroup.ContentGroupId)
            {
                return BadRequest();
            }

            _context.Entry(contentGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentGroupExists(id))
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

        // POST: api/ContentGroup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContentGroup>> PostContentGroup(ContentGroup contentGroup)
        {
            if (_context.ContentGroups.Any(x => x.ContentId == contentGroup.ContentId && x.EmployeeGroupId == contentGroup.EmployeeGroupId))
                return Conflict("Content group already exists!");

            _context.ContentGroups.Add(contentGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContentGroupExists(contentGroup.ContentGroupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContentGroup", new { id = contentGroup.ContentGroupId }, contentGroup);
        }

        // DELETE: api/ContentGroup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentGroup(Guid id)
        {
            var contentGroup = await _context.ContentGroups.FindAsync(id);
            if (contentGroup == null)
            {
                return NotFound();
            }

            _context.ContentGroups.Remove(contentGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentGroupExists(Guid id)
        {
            return _context.ContentGroups.Any(e => e.ContentGroupId == id);
        }
    }
}
