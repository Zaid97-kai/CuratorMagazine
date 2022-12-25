using CuratorMagazineWebAPI.Controllers.Bases;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CuratorMagazineWebAPI.Controllers;

/// <summary>
/// Class GroupController.
/// Implements the <see cref="BaseController" />
/// </summary>
/// <seealso cref="BaseController" />
public class GroupController : BaseController
{
    /// <summary>
    /// The unit of work
    /// </summary>
    private readonly IGroupRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GroupController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public GroupController(IGroupRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;Group&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Group>> Get(int id)
    {
        var Group = await _repository.GetById(id);
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

        _repository.Add(Group);
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

        _repository.Update(Group);
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
        var Group = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (Group == null) return NotFound();
        _repository.Remove(Group);
        return Ok(Group);
    }
}