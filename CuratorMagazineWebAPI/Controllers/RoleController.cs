using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CuratorMagazineWebAPI.Controllers;

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
    /// The unit of work
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleController"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work.</param>
    public RoleController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Gets this instance.
    /// </summary>
    /// <returns>IEnumerable&lt;Role&gt;.</returns>
    [HttpGet]
    public async Task<IEnumerable<Role>> Get()
    {
        return await _unitOfWork.RoleRepository.GetAll();
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;Role&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Role>> Get(int id)
    {
        var Role = await _unitOfWork.RoleRepository.GetById(id);
        if (Role == null)
            return NotFound();
        return new ObjectResult(Role);
    }

    /// <summary>
    /// Posts the specified role.
    /// </summary>
    /// <param name="Role">The role.</param>
    /// <returns>ActionResult&lt;Role&gt;.</returns>
    [HttpPost]
    public async Task<ActionResult<Role>> Post(Role? Role)
    {
        if (Role == null)
        {
            return BadRequest();
        }

        _unitOfWork.RoleRepository.Add(Role);
        _unitOfWork.Complete();
        return Ok(Role);
    }

    /// <summary>
    /// Puts the specified role.
    /// </summary>
    /// <param name="Role">The role.</param>
    /// <returns>ActionResult&lt;Role&gt;.</returns>
    [HttpPut]
    public async Task<ActionResult<Role>> Put(Role? Role)
    {
        if (Role == null)
        {
            return BadRequest();
        }

        _unitOfWork.RoleRepository.Update(Role);
        _unitOfWork.Complete();
        return Ok(Role);
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;Role&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Role>> Delete(int id)
    {
        var Role = _unitOfWork.RoleRepository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (Role == null) return NotFound();
        _unitOfWork.RoleRepository.Remove(Role);
        _unitOfWork.Complete();
        return Ok(Role);
    }
}