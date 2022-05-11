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
    public class ContentMasterController : ControllerBase
    {
        private readonly EwayPortalDbContext _context;

        public ContentMasterController(EwayPortalDbContext context)
        {
            _context = context;
        }

        // GET: api/ContentMaster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentMaster>>> GetContentMasters()
        {
            return await _context.ContentMasters.ToListAsync();
        }

        // GET: api/ContentMaster/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentMaster>> GetContentMaster(Guid id)
        {
            var contentMaster = await _context.ContentMasters.FindAsync(id);

            if (contentMaster == null)
            {
                return NotFound();
            }

            return contentMaster;
        }

        // PUT: api/ContentMaster/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentMaster(Guid id, ContentMaster contentMaster)
        {
            if (id != contentMaster.ContentId)
            {
                return BadRequest();
            }

            if (_context.ContentMasters.Any(x => string.Equals(x.ContentHeader, contentMaster.ContentHeader, StringComparison.OrdinalIgnoreCase) &&
                                            x.ContentId != id))
                return Conflict("Content header already exists!");

            _context.Entry(contentMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentMasterExists(id))
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

        // POST: api/ContentMaster
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContentMaster>> PostContentMaster(ContentMaster contentMaster)
        {
            // if (_context.ContentMasters.Any(x => string.Equals(x.ContentHeader, contentMaster.ContentHeader, StringComparison.OrdinalIgnoreCase)))
            //     return Conflict("Content header already exists!");


            _context.ContentMasters.Add(contentMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (ContentMasterExists(contentMaster.ContentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContentMaster", new { id = contentMaster.ContentId }, contentMaster);
        }

        // DELETE: api/ContentMaster/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentMaster(Guid id)
        {
            var contentMaster = await _context.ContentMasters.FindAsync(id);
            if (contentMaster == null)
            {
                return NotFound();
            }

            _context.ContentMasters.Remove(contentMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentMasterExists(Guid id)
        {
            return _context.ContentMasters.Any(e => e.ContentId == id);
        }
    }
}
