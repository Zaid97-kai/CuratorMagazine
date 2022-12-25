using CuratorMagazineWebAPI.Models.Bases.ActionResults;
using CuratorMagazineWebAPI.Models.Bases.Filters;
using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Bases.Dtos.BaseHelpers;

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
    /// The repository
    /// </summary>
    private readonly IUserRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;User&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<BaseResponseActionResult<User>> Get(int id)
    {
        var user = await _repository.GetById(id);
        if (user == null)
            return new BaseNotFound();
        
        return user;
    }

    /// <summary>
    /// Gets the list.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns>BaseResponseActionResult&lt;BaseDtoListResult&gt;.</returns>
    [HttpPost("GetList")]
    public async Task<BaseResponseActionResult<BaseDtoListResult>> GetList([FromBody] BaseFilterGetList data)
    {
        var ret = await _repository.GetList(data);
        return ret;
    }

    /// <summary>
    /// Posts the specified user.
    /// </summary>
    /// <param name="User">The user.</param>
    /// <returns>ActionResult&lt;User&gt;.</returns>
    [HttpPost]
    public async Task<ActionResult<User>> Post([FromBody] User? User)
    {
        if (User == null)
            return new BaseBadRequest();

        await _repository.Add(User);
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

        _repository.Update(User);
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
        var User = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (User == null) return NotFound();
        _repository.Remove(User);
        return Ok(User);
    }
}