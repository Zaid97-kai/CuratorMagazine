using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private readonly CuratorMagazineContext _db;

        public GroupController(CuratorMagazineContext context)
        {
            _db = context;
            if (_db.Groups.Any()) return;
            _db.Groups.Add(new Group() { Name = "Test" });
            _db.SaveChanges();
        }

        // GET: api/group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> Get()
        {
            return await _db.Groups.ToListAsync();
        }

        // GET: api/group/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> Get(int id)
        {
            var group = await _db.Groups.FirstOrDefaultAsync(x => x.Id == id);
            if (group == null)
                return NotFound();
            return new ObjectResult(group);
        }
        // POST api/group
        [HttpPost]
        public async Task<ActionResult<Group>> Post(Group group)
        {
            if (group == null)
            {
                return BadRequest();
            }

            _db.Groups.Add(group);
            await _db.SaveChangesAsync();
            return Ok(group);
        }

        // PUT api/group/
        [HttpPut]
        public async Task<ActionResult<Group>> Put(Group group)
        {
            if (group == null)
            {
                return BadRequest();
            }

            if (!_db.Users.Any(x => x.Id == group.Id))
            {
                return NotFound();
            }

            _db.Update(group);
            await _db.SaveChangesAsync();
            return Ok(group);
        }

        // DELETE api/group/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var group = _db.Groups.FirstOrDefault(x => x.Id == id);
            if (group == null)
            {
                return NotFound();
            }

            _db.Groups.Remove(group);
            await _db.SaveChangesAsync();
            return Ok(group);
        }
    }
}
