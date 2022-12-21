using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;

namespace CuratorMagazineWebAPI.Models.Entities.Repositories.Entities;

/// <summary>
/// Class ParentRepository.
/// Implements the <see cref="BaseRepository{T}.Models.Entities.Parent}" />
/// Implements the <see cref="IParentRepository" />
/// </summary>
/// <seealso cref="BaseRepository{T}.Models.Entities.Parent}" />
/// <seealso cref="IParentRepository" />
public class ParentRepository : BaseRepository<Parent>, IParentRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ParentRepository" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public ParentRepository(CuratorMagazineContext context) : base(context)
    {
    }
}