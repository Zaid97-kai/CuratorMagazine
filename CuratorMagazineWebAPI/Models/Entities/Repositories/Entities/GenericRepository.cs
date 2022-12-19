using CuratorMagazineWebAPI.Models.Context;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;
using System.Linq.Expressions;

namespace CuratorMagazineWebAPI.Models.Entities.Repositories.Entities;

/// <summary>
/// Class GenericRepository.
/// Implements the <see cref="IGenericRepository{T}" />
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="IGenericRepository{T}" />
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    /// <summary>
    /// The context
    /// </summary>
    protected readonly CuratorMagazineContext Context;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{T}" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public GenericRepository(CuratorMagazineContext context)
    {
        Context = context;
    }

    /// <summary>
    /// Adds the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public async void Add(T entity)
    {
        Context.Set<T>().Add(entity);
    }

    /// <summary>
    /// Adds the range.
    /// </summary>
    /// <param name="entities">The entities.</param>
    public async void AddRange(IEnumerable<T> entities)
    {
        Context.Set<T>().AddRange(entities);
    }

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <exception cref="System.NotImplementedException"></exception>
    public async void Update(T entity)
    {
        Context.Set<T>().Update(entity);
    }

    /// <summary>
    /// Finds the specified expression.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
    {
        return Context.Set<T>().Where(expression);
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    public async Task<IEnumerable<T>> GetAll()
    {
        return Context.Set<T>().ToList();
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>T.</returns>
    public async Task<T?> GetById(int id)
    {
        return Context.Set<T>().Find(id);
    }

    /// <summary>
    /// Removes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public async void Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
    }

    /// <summary>
    /// Removes the range.
    /// </summary>
    /// <param name="entities">The entities.</param>
    public async void RemoveRange(IEnumerable<T> entities)
    {
        Context.Set<T>().RemoveRange(entities);
    }
}