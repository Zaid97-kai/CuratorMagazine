using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.Controllers
{
    /// <summary>
    /// Class RoleController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        /// <summary>
        /// The database
        /// </summary>
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

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>ActionResult&lt;IEnumerable&lt;Role&gt;&gt;.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            return await _db.Roles.ToListAsync();
        }

        // GET api/role/5
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult&lt;Role&gt;.</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            var role = await _db.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null)
                return NotFound();
            return new ObjectResult(role);
        }

        // POST api/role
        /// <summary>
        /// Posts the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>ActionResult&lt;Role&gt;.</returns>
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
        /// <summary>
        /// Puts the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>ActionResult&lt;Role&gt;.</returns>
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
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult&lt;User&gt;.</returns>
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