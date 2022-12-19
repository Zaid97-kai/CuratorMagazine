using System.Linq.Expressions;

namespace CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;

/// <summary>
/// Interface IGenericRepository
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenericRepository<T> where T : class
{
    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>T.</returns>
    Task<T?> GetById(int id);
    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    Task<IEnumerable<T>> GetAll();
    /// <summary>
    /// Finds the specified expression.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    /// <summary>
    /// Adds the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    void Add(T entity);
    /// <summary>
    /// Adds the range.
    /// </summary>
    /// <param name="entities">The entities.</param>
    void AddRange(IEnumerable<T> entities);
    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    void Update(T entity);
    /// <summary>
    /// Removes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    void Remove(T entity);
    /// <summary>
    /// Removes the range.
    /// </summary>
    /// <param name="entities">The entities.</param>
    void RemoveRange(IEnumerable<T> entities);
}