using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : Controller
    {
        private readonly CuratorMagazineContext _db;

        public ParentController(CuratorMagazineContext context)
        {
            _db = context;
            if (_db.Parents.Any()) return;
        }

        // GET: api/parent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parent>>> Get()
        {
            return await _db.Parents.ToListAsync();
        }

        // GET: api/parent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parent>> Get(int id)
        {
            var parent = await _db.Parents.FirstOrDefaultAsync(x => x.Id == id);
            if (parent == null)
                return NotFound();
            return new ObjectResult(parent);
        }
        // POST api/parent
        [HttpPost]
        public async Task<ActionResult<Parent>> Post(Parent parent)
        {
            if (parent == null)
            {
                return BadRequest();
            }

            _db.Parents.Add(parent);
            await _db.SaveChangesAsync();
            return Ok(parent);
        }

        // PUT api/parent/
        [HttpPut]
        public async Task<ActionResult<Parent>> Put(Parent parent)
        {
            if (parent == null)
            {
                return BadRequest();
            }

            if (!_db.Users.Any(x => x.Id == parent.Id))
            {
                return NotFound();
            }

            _db.Update(parent);
            await _db.SaveChangesAsync();
            return Ok(parent);
        }

        // DELETE api/parent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var parent = _db.Parents.FirstOrDefault(x => x.Id == id);
            if (parent == null)
            {
                return NotFound();
            }

            _db.Parents.Remove(parent);
            await _db.SaveChangesAsync();
            return Ok(parent);
        }
    }
}
