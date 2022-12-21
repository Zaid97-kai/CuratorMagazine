﻿using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;

namespace CuratorMagazineWebAPI.Models.Entities.Repositories.Entities;

/// <summary>
/// Class GroupRepository.
/// Implements the <see cref="BaseRepository{T}.Models.Entities.Group}" />
/// Implements the <see cref="IGroupRepository" />
/// </summary>
/// <seealso cref="BaseRepository{T}.Models.Entities.Group}" />
/// <seealso cref="IGroupRepository" />
public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GroupRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public GroupRepository(CuratorMagazineContext context) : base(context)
    {
    }
}