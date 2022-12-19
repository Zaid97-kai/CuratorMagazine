using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CuratorMagazineWebAPI.Controllers;

/// <summary>
/// Class UserController.
/// Implements the <see cref="Controller" />
/// </summary>
/// <seealso cref="Controller" />
[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    /// <summary>
    /// The unit of work
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work.</param>
    public UserController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Gets this instance.
    /// </summary>
    /// <returns>IEnumerable&lt;User&gt;.</returns>
    [HttpGet]
    public async Task<IEnumerable<User>> Get()
    {
        return await _unitOfWork.UserRepository.GetAll();
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;User&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var User = await _unitOfWork.UserRepository.GetById(id);
        if (User == null)
            return NotFound();
        return new ObjectResult(User);
    }

    /// <summary>
    /// Posts the specified user.
    /// </summary>
    /// <param name="User">The user.</param>
    /// <returns>ActionResult&lt;User&gt;.</returns>
    [HttpPost]
    public async Task<ActionResult<User>> Post(User? User)
    {
        if (User == null)
        {
            return BadRequest();
        }

        _unitOfWork.UserRepository.Add(User);
        _unitOfWork.Complete();
        return Ok(User);
    }

    /// <summary>
    /// Puts the specified user.
    /// </summary>
    /// <param name="User">The user.</param>
    /// <returns>ActionResult&lt;User&gt;.</returns>
    [HttpPut]
    public async Task<ActionResult<User>> Put(User? User)
    {
        if (User == null)
        {
            return BadRequest();
        }

        _unitOfWork.UserRepository.Update(User);
        _unitOfWork.Complete();
        return Ok(User);
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;User&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> Delete(int id)
    {
        var User = _unitOfWork.UserRepository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (User == null) return NotFound();
        _unitOfWork.UserRepository.Remove(User);
        _unitOfWork.Complete();
        return Ok(User);
    }
}