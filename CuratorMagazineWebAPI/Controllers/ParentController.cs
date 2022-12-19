using CuratorMagazineWebAPI.Models.Entities;
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
    /// The unit of work
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParentController"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work.</param>
    public ParentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Gets this instance.
    /// </summary>
    /// <returns>IEnumerable&lt;Parent&gt;.</returns>
    [HttpGet]
    public async Task<IEnumerable<Parent>> Get()
    {
        return await _unitOfWork.ParentRepository.GetAll();
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;Parent&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Parent>> Get(int id)
    {
        var Parent = await _unitOfWork.ParentRepository.GetById(id);
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

        _unitOfWork.ParentRepository.Add(Parent);
        _unitOfWork.Complete();
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

        _unitOfWork.ParentRepository.Update(Parent);
        _unitOfWork.Complete();
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
        var Parent = _unitOfWork.ParentRepository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (Parent == null) return NotFound();
        _unitOfWork.ParentRepository.Remove(Parent);
        _unitOfWork.Complete();
        return Ok(Parent);
    }
}