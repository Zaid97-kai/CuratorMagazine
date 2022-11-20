using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.Controllers
{
    /// <summary>
    /// Class ParentController.
    /// Implements the <see cref="Controller" />
    /// </summary>
    /// <seealso cref="Controller" />
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : Controller
    {
        /// <summary>
        /// The database
        /// </summary>
        private readonly CuratorMagazineContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParentController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ParentController(CuratorMagazineContext context)
        {
            _db = context;
            if (_db.Parents.Any()) return;
        }

        // GET: api/parent
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>ActionResult&lt;IEnumerable&lt;Parent&gt;&gt;.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parent>>> Get()
        {
            return await _db.Parents.ToListAsync();
        }

        // GET: api/parent/5
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult&lt;Parent&gt;.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Parent>> Get(int id)
        {
            var parent = await _db.Parents.FirstOrDefaultAsync(x => x.Id == id);
            if (parent == null)
                return NotFound();
            return new ObjectResult(parent);
        }
        // POST api/parent
        /// <summary>
        /// Posts the specified parent.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>ActionResult&lt;Parent&gt;.</returns>
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
        /// <summary>
        /// Puts the specified parent.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>ActionResult&lt;Parent&gt;.</returns>
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
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult&lt;User&gt;.</returns>
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
