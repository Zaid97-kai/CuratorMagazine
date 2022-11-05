using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly CuratorMagazineContext _db;

        /// <summary>
        /// Конструктор класса RoleController
        /// </summary>
        /// <param name="context">Контекст данных CuratorMagazineContext</param>
        public RoleController(CuratorMagazineContext context)
        {
            _db = context;
            if (_db.Roles.Any()) return;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            return await _db.Roles.ToListAsync();
        }

        // GET api/role/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            var role = await _db.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null)
                return NotFound();
            return new ObjectResult(role);
        }

        // POST api/role
        [HttpPost]
        public async Task<ActionResult<Role>> Post(Role role)
        {
            if (role == null)
            {
                return BadRequest();
            }

            _db.Roles.Add(role);
            await _db.SaveChangesAsync();
            return Ok(role);
        }

        // PUT api/role/
        [HttpPut]
        public async Task<ActionResult<Role>> Put(Role role)
        {
            if (role == null)
            {
                return BadRequest();
            }

            if (!_db.Users.Any(x => x.Id == role.Id))
            {
                return NotFound();
            }

            _db.Update(role);
            await _db.SaveChangesAsync();
            return Ok(role);
        }

        // DELETE api/role/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var role = _db.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            _db.Roles.Remove(role);
            await _db.SaveChangesAsync();
            return Ok(role);
        }
    }
}