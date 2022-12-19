using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Entities;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;

namespace CuratorMagazineWebAPI.Models.Entities.Repositories.UnitOfWork;

/// <summary>
/// Class UnitOfWork.
/// Implements the <see cref="IUnitOfWork" />
/// </summary>
/// <seealso cref="IUnitOfWork" />
public class UnitOfWork : IUnitOfWork
{
    /// <summary>
    /// The context
    /// </summary>
    private readonly CuratorMagazineContext _context;
    /// <summary>
    /// Gets the division repository.
    /// </summary>
    /// <value>The division repository.</value>
    public IDivisionRepository DivisionRepository { get; }
    /// <summary>
    /// Gets the group repository.
    /// </summary>
    /// <value>The group repository.</value>
    public IGroupRepository GroupRepository { get; }
    /// <summary>
    /// Gets the parent repository.
    /// </summary>
    /// <value>The parent repository.</value>
    public IParentRepository ParentRepository { get; }
    /// <summary>
    /// Gets the role repository.
    /// </summary>
    /// <value>The role repository.</value>
    public IRoleRepository RoleRepository { get; }
    /// <summary>
    /// Gets the user repository.
    /// </summary>
    /// <value>The user repository.</value>
    public IUserRepository UserRepository { get; }
    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public UnitOfWork(CuratorMagazineContext context)
    {
        _context = context;
        DivisionRepository = new DivisionRepository(_context);
        GroupRepository = new GroupRepository(_context);
        ParentRepository = new ParentRepository(_context);
        RoleRepository = new RoleRepository(_context);
        UserRepository = new UserRepository(_context);
    }
    /// <summary>
    /// Completes this instance.
    /// </summary>
    /// <returns>System.Int32.</returns>
    public int Complete()
    {
        return _context.SaveChanges();
    }
    /// <summary>
    /// Disposes this instance.
    /// </summary>
    public void Dispose()
    {
        _context.Dispose();
    }
}