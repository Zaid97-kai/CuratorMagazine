using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupController"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public GroupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;Group&gt;.</returns>
        [HttpGet]
        public async Task<IEnumerable<Group>> Get()
        {
            return await _unitOfWork.GroupRepository.GetAll();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult&lt;Group&gt;.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> Get(int id)
        {
            var Group = await _unitOfWork.GroupRepository.GetById(id);
            if (Group == null)
                return NotFound();
            return new ObjectResult(Group);
        }

        /// <summary>
        /// Posts the specified group.
        /// </summary>
        /// <param name="Group">The group.</param>
        /// <returns>ActionResult&lt;Group&gt;.</returns>
        [HttpPost]
        public async Task<ActionResult<Group>> Post(Group? Group)
        {
            if (Group == null)
            {
                return BadRequest();
            }

            _unitOfWork.GroupRepository.Add(Group);
            _unitOfWork.Complete();
            return Ok(Group);
        }

        /// <summary>
        /// Puts the specified group.
        /// </summary>
        /// <param name="Group">The group.</param>
        /// <returns>ActionResult&lt;Group&gt;.</returns>
        [HttpPut]
        public async Task<ActionResult<Group>> Put(Group? Group)
        {
            if (Group == null)
            {
                return BadRequest();
            }

            _unitOfWork.GroupRepository.Update(Group);
            _unitOfWork.Complete();
            return Ok(Group);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult&lt;Group&gt;.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Group>> Delete(int id)
        {
            var Group = _unitOfWork.GroupRepository.Find(x => x.Id == id).Result.FirstOrDefault();

            if (Group == null) return NotFound();
            _unitOfWork.GroupRepository.Remove(Group);
            _unitOfWork.Complete();
            return Ok(Group);
        }
    }
}
