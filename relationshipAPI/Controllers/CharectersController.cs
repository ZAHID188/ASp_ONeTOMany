using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relationshipAPI.Data;
using relationshipAPI.Model;

namespace relationshipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharectersController : ControllerBase
    {
        private readonly DataContext _context;

        public CharectersController(DataContext context)
        {
            _context = context;
         }

        [HttpGet]
        public async Task<ActionResult<List<Charecter>>> Get(int user)
        {
            var charecters = await _context.Charecters
                .Where(c => c.UserId == user)
                .ToListAsync();

            return charecters;
        }

        [HttpPost]
        public async Task<ActionResult<List<Charecter>>> Create(CreateCharecterDTO CRDTO)
        {
            var user = await _context.users.FindAsync(CRDTO.userID);
            if(user == null)
            {
                return NotFound();
            }

            var newCharecter = new Charecter
            {
                Name = CRDTO.Name,
                rpgClass = CRDTO.RpgClass,
                User = user,
            };
            _context.Charecters.Add(newCharecter);
            await _context.SaveChangesAsync();
            return await Get(newCharecter.UserId);
        }



        /*
        private readonly DataContext _context;

        public CharectersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Charecters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Charecter>>> GetCharecters()
        {
          if (_context.Charecters == null)
          {
              return NotFound();
          }
            return await _context.Charecters.ToListAsync();
        }

        // GET: api/Charecters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Charecter>> GetCharecter(int id)
        {
          if (_context.Charecters == null)
          {
              return NotFound();
          }
            var charecter = await _context.Charecters.FindAsync(id);

            if (charecter == null)
            {
                return NotFound();
            }

            return charecter;
        }

        // PUT: api/Charecters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharecter(int id, Charecter charecter)
        {
            if (id != charecter.Id)
            {
                return BadRequest();
            }

            _context.Entry(charecter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharecterExists(id))
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

        // POST: api/Charecters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Charecter>> PostCharecter(Charecter charecter)
        {
          if (_context.Charecters == null)
          {
              return Problem("Entity set 'DataContext.Charecters'  is null.");
          }
            _context.Charecters.Add(charecter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharecter", new { id = charecter.Id }, charecter);
        }

        // DELETE: api/Charecters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharecter(int id)
        {
            if (_context.Charecters == null)
            {
                return NotFound();
            }
            var charecter = await _context.Charecters.FindAsync(id);
            if (charecter == null)
            {
                return NotFound();
            }

            _context.Charecters.Remove(charecter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharecterExists(int id)
        {
            return (_context.Charecters?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
