using CuratorMagazineWebAPI.Models.Entities.Repositories.Entities;

namespace CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;

/// <summary>
/// Interface IUnitOfWork
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Gets the division repository.
    /// </summary>
    /// <value>The division repository.</value>
    IDivisionRepository DivisionRepository { get; }
    /// <summary>
    /// Gets the group repository.
    /// </summary>
    /// <value>The group repository.</value>
    IGroupRepository GroupRepository { get; }
    /// <summary>
    /// Gets the parent repository.
    /// </summary>
    /// <value>The parent repository.</value>
    IParentRepository ParentRepository { get; }
    /// <summary>
    /// Gets the role repository.
    /// </summary>
    /// <value>The role repository.</value>
    IRoleRepository RoleRepository { get; }
    /// <summary>
    /// Gets the user repository.
    /// </summary>
    /// <value>The user repository.</value>
    UserRepository UserRepository { get; }
    /// <summary>
    /// Completes this instance.
    /// </summary>
    /// <returns>System.Int32.</returns>
    int Complete();
}