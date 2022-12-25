using CuratorMagazineWebAPI.Controllers.Bases;
using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CuratorMagazineWebAPI.Controllers;

/// <summary>
/// Class DivisionController.
/// Implements the <see cref="BaseController" />
/// </summary>
/// <seealso cref="BaseController" />
public class DivisionController : BaseController
{
    /// <summary>
    /// The repository
    /// </summary>
    private readonly IDivisionRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DivisionController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public DivisionController(IDivisionRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;Division&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Division>> Get(int id)
    {
        var division = await _repository.GetById(id);
        if (division == null)
            return NotFound();
        return new ObjectResult(division);
    }

    /// <summary>
    /// Posts the specified division.
    /// </summary>
    /// <param name="division">The division.</param>
    /// <returns>ActionResult&lt;Division&gt;.</returns>
    [HttpPost]
    public async Task<ActionResult<Division>> Post(Division? division)
    {
        if (division == null)
        {
            return BadRequest();
        }

        _repository.Add(division);
        return Ok(division);
    }

    /// <summary>
    /// Puts the specified division.
    /// </summary>
    /// <param name="division">The division.</param>
    /// <returns>ActionResult&lt;Division&gt;.</returns>
    [HttpPut]
    public async Task<ActionResult<Division>> Put(Division? division)
    {
        if (division == null)
        {
            return BadRequest();
        }
        
        _repository.Update(division);
        return Ok(division);
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;User&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Division>> Delete(int id)
    {
        var division = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (division == null) return NotFound();
        _repository.Remove(division);
        return Ok(division);
    }
}