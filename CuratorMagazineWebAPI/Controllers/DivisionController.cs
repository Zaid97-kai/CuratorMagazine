using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.Controllers
{
    /// <summary>
    /// Class DivisionController.
    /// Implements the <see cref="Controller" />
    /// </summary>
    /// <seealso cref="Controller" />
    [ApiController]
    [Route("api/[controller]")]
    public class DivisionController : Controller
    {
        /// <summary>
        /// The database
        /// </summary>
        private readonly CuratorMagazineContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DivisionController(CuratorMagazineContext context)
        {
            _db = context;
            if (_db.Divisions.Any()) return;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>ActionResult&lt;IEnumerable&lt;Division&gt;&gt;.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Division>>> Get()
        {
            return await _db.Divisions.ToListAsync();
        }

        // GET: api/division/5
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult&lt;Division&gt;.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Division>> Get(int id)
        {
            var division = await _db.Divisions.FirstOrDefaultAsync(x => x.Id == id);
            if (division == null)
                return NotFound();
            return new ObjectResult(division);
        }

        // POST api/division
        /// <summary>
        /// Posts the specified division.
        /// </summary>
        /// <param name="division">The division.</param>
        /// <returns>ActionResult&lt;Division&gt;.</returns>
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
        /// <summary>
        /// Puts the specified division.
        /// </summary>
        /// <param name="division">The division.</param>
        /// <returns>ActionResult&lt;Division&gt;.</returns>
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
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult&lt;User&gt;.</returns>
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
