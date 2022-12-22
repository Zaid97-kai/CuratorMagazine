using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CuratorMagazineWebAPI.Controllers;

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
    /// The repository
    /// </summary>
    private readonly IParentRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParentController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public ParentController(IParentRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;Parent&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Parent>> Get(int id)
    {
        var Parent = await _repository.GetById(id);
        if (Parent == null)
            return NotFound();
        return new ObjectResult(Parent);
    }

    /// <summary>
    /// Posts the specified parent.
    /// </summary>
    /// <param name="Parent">The parent.</param>
    /// <returns>ActionResult&lt;Parent&gt;.</returns>
    [HttpPost]
    public async Task<ActionResult<Parent>> Post(Parent? Parent)
    {
        if (Parent == null)
        {
            return BadRequest();
        }

        _repository.Add(Parent);
        return Ok(Parent);
    }

    /// <summary>
    /// Puts the specified parent.
    /// </summary>
    /// <param name="Parent">The parent.</param>
    /// <returns>ActionResult&lt;Parent&gt;.</returns>
    [HttpPut]
    public async Task<ActionResult<Parent>> Put(Parent? Parent)
    {
        if (Parent == null)
        {
            return BadRequest();
        }

        _repository.Update(Parent);
        return Ok(Parent);
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;Parent&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Parent>> Delete(int id)
    {
        var Parent = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (Parent == null) return NotFound();
        _repository.Remove(Parent);
        return Ok(Parent);
    }
}