using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;

namespace CuratorMagazineWebAPI.Models.Entities.Repositories.Entities;

/// <summary>
/// Class DivisionRepository.
/// Implements the <see cref="CuratorMagazineWebAPI.Models.Entities.Repositories.Entities.GenericRepository{CuratorMagazineWebAPI.Models.Entities.Division}" />
/// Implements the <see cref="IDivisionRepository" />
/// </summary>
/// <seealso cref="CuratorMagazineWebAPI.Models.Entities.Repositories.Entities.GenericRepository{CuratorMagazineWebAPI.Models.Entities.Division}" />
/// <seealso cref="IDivisionRepository" />
public class DivisionRepository : GenericRepository<Division>, IDivisionRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DivisionRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public DivisionRepository(CuratorMagazineContext context) : base(context)
    {
    }
}