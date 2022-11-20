using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.Controllers
{
    /// <summary>
    /// Class GroupController.
    /// Implements the <see cref="Controller" />
    /// </summary>
    /// <seealso cref="Controller" />
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        /// <summary>
        /// The database
        /// </summary>
        private readonly CuratorMagazineContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GroupController(CuratorMagazineContext context)
        {
            _db = context;
            if (_db.Groups.Any()) return;
        }

        // GET: api/group
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>ActionResult&lt;IEnumerable&lt;Group&gt;&gt;.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> Get()
        {
            return await _db.Groups.ToListAsync();
        }

        // GET: api/group/5
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult&lt;Group&gt;.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> Get(int id)
        {
            var group = await _db.Groups.FirstOrDefaultAsync(x => x.Id == id);
            if (group == null)
                return NotFound();
            return new ObjectResult(group);
        }
        // POST api/group
        /// <summary>
        /// Posts the specified group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns>ActionResult&lt;Group&gt;.</returns>
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
        /// <summary>
        /// Puts the specified group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns>ActionResult&lt;Group&gt;.</returns>
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
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult&lt;User&gt;.</returns>
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
