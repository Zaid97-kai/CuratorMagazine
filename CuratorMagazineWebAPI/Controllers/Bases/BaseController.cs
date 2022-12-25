using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CuratorMagazineWebAPI.Controllers.Bases;

/// <summary>
/// Class BaseController.
/// Implements the <see cref="ControllerBase" />
/// </summary>
/// <seealso cref="ControllerBase" />
[Route("api/[controller]")]
public class BaseController : ControllerBase
{

}