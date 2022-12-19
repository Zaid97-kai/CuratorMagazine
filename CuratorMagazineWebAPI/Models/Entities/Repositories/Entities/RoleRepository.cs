using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;

namespace CuratorMagazineWebAPI.Models.Entities.Repositories.Entities;

/// <summary>
/// Class RoleRepository.
/// Implements the <see cref="CuratorMagazineWebAPI.Models.Entities.Repositories.Entities.GenericRepository{CuratorMagazineWebAPI.Models.Entities.Role}" />
/// Implements the <see cref="IRoleRepository" />
/// </summary>
/// <seealso cref="CuratorMagazineWebAPI.Models.Entities.Repositories.Entities.GenericRepository{CuratorMagazineWebAPI.Models.Entities.Role}" />
/// <seealso cref="IRoleRepository" />
public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleRepository" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public RoleRepository(CuratorMagazineContext context) : base(context)
    {
    }
}