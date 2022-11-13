using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.Controllers
{
    /// <summary>
    /// Контроллер UserController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly CuratorMagazineContext _db;

        /// <summary>
        /// Конструктор класса UserController
        /// </summary>
        /// <param name="context"></param>
        public UserController(CuratorMagazineContext context)
        {
            _db = context;
            if (_db.Users.Any()) return;
        }

        // GET: api/user 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var list = await _db.Users.ToListAsync();
            return await _db.Users.ToListAsync();
        }


        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/user
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/user/
        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (!_db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            _db.Update(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
