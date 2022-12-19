using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CuratorMagazineWebAPI.Controllers;

/// <summary>
/// Class DivisionController.
/// Implements the <see cref="Controller" />
/// </summary>
/// <seealso cref="Controller" />
[ApiController]
[Route("api/[controller]")]
public class DivisionController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="DivisionController"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public DivisionController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Gets this instance.
    /// </summary>
    /// <returns>ActionResult&lt;IEnumerable&lt;Division&gt;&gt;.</returns>
    [HttpGet]
    public async Task<IEnumerable<Division>> Get()
    {
        return await _unitOfWork.DivisionRepository.GetAll();
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;Division&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Division>> Get(int id)
    {
        var division = await _unitOfWork.DivisionRepository.GetById(id);
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

        _unitOfWork.DivisionRepository.Add(division);
        _unitOfWork.Complete();
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
        
        _unitOfWork.DivisionRepository.Update(division);
        _unitOfWork.Complete();
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
        var division = _unitOfWork.DivisionRepository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (division == null) return NotFound();
        _unitOfWork.DivisionRepository.Remove(division);
        _unitOfWork.Complete();
        return Ok(division);
    }
}