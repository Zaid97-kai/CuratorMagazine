using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.Entities.Domains;
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
    /// The repository
    /// </summary>
    private readonly IRoleRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public RoleController(IRoleRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;Role&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Role>> Get(int id)
    {
        var Role = await _repository.GetById(id);
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

        _repository.Add(Role);
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

        _repository.Update(Role);
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
        var Role = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (Role == null) return NotFound();
        _repository.Remove(Role);
        return Ok(Role);
    }
}