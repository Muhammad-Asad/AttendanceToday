using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AttendanceToday.Model;

namespace WebServices.Controllers
{
    [Produces("application/json")]
    [Route("api/Classes1")]
    public class Classes1Controller : Controller
    {
        private readonly Db _context;

        public Classes1Controller(Db context)
        {
            _context = context;
        }

        // GET: api/Classes1
        [HttpGet]
        public IEnumerable<Class> GetClasses()
        {
            return _context.Classes;
        }

        // GET: api/Classes1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClass([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @class = await _context.Classes.SingleOrDefaultAsync(m => m.ID == id);

            if (@class == null)
            {
                return NotFound();
            }

            return Ok(@class);
        }

        // PUT: api/Classes1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass([FromRoute] long id, [FromBody] Class @class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @class.ID)
            {
                return BadRequest();
            }

            _context.Entry(@class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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

        // POST: api/Classes1
        [HttpPost]
        public async Task<IActionResult> PostClass([FromBody] Class @class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Classes.Add(@class);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClass", new { id = @class.ID }, @class);
        }

        // DELETE: api/Classes1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @class = await _context.Classes.SingleOrDefaultAsync(m => m.ID == id);
            if (@class == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();

            return Ok(@class);
        }

        private bool ClassExists(long id)
        {
            return _context.Classes.Any(e => e.ID == id);
        }
    }
}