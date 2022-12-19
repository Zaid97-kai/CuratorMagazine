using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;

namespace CuratorMagazineWebAPI.Models.Entities.Repositories.Entities;

/// <summary>
/// Class UserRepository.
/// Implements the <see cref="CuratorMagazineWebAPI.Models.Entities.Repositories.Entities.GenericRepository{CuratorMagazineWebAPI.Models.Entities.User}" />
/// </summary>
/// <seealso cref="CuratorMagazineWebAPI.Models.Entities.Repositories.Entities.GenericRepository{CuratorMagazineWebAPI.Models.Entities.User}" />
public class UserRepository : GenericRepository<User>, IUserRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public UserRepository(CuratorMagazineContext context) : base(context)
    {
    }
}