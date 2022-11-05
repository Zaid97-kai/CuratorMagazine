using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DivisionController : Controller
    {
        private readonly CuratorMagazineContext _db;

        public DivisionController(CuratorMagazineContext context)
        {
            _db = context;
            if (_db.Divisions.Any()) return;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Division>>> Get()
        {
            return await _db.Divisions.ToListAsync();
        }

        // GET: api/division/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Division>> Get(int id)
        {
            var division = await _db.Divisions.FirstOrDefaultAsync(x => x.Id == id);
            if (division == null)
                return NotFound();
            return new ObjectResult(division);
        }

        // POST api/division
        [HttpPost]
        public async Task<ActionResult<Division>> Post(Division division)
        {
            if (division == null)
            {
                return BadRequest();
            }

            _db.Divisions.Add(division);
            await _db.SaveChangesAsync();
            return Ok(division);
        }

        // PUT api/division/
        [HttpPut]
        public async Task<ActionResult<Division>> Put(Division division)
        {
            if (division == null)
            {
                return BadRequest();
            }

            if (!_db.Users.Any(x => x.Id == division.Id))
            {
                return NotFound();
            }

            _db.Update(division);
            await _db.SaveChangesAsync();
            return Ok(division);
        }

        // DELETE api/division/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var division = _db.Divisions.FirstOrDefault(x => x.Id == id);
            if (division == null)
            {
                return NotFound();
            }

            _db.Divisions.Remove(division);
            await _db.SaveChangesAsync();
            return Ok(division);
        }
    }
}
