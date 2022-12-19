using CuratorMagazineBlazorApp.Data.Common;
using CuratorMagazineBlazorApp.Models.Bases;
using CuratorMagazineWebAPI.Models.Entities;

namespace CuratorMagazineBlazorApp.Data.Services;

/// <summary>
/// Class UserService.
/// Implements the <see cref="BaseService" />
/// </summary>
/// <seealso cref="BaseService" />
public class UserService : BaseService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public UserService(IHttpClientFactory httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Get cards as an asynchronous operation.
    /// </summary>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    public async Task<OperationResult<List<User>>> GetCardsAsync()
    {
        var dto = await SendAsync<List<User>>("", HttpMethod.Get);
        return dto;
    }

    /// <summary>
    /// Get card as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    public async Task<OperationResult<User>> GetCardAsync(int id)
    {
        var dto = await SendAsync<User>($"{id}", HttpMethod.Get);
        return dto;
    }

    /// <summary>
    /// Create card as an asynchronous operation.
    /// </summary>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    public async Task<OperationResult<User>> CreateCardAsync()
    {
        var dto = await SendAsync<User>("Create", HttpMethod.Post);
        return dto;
    }

    /// <summary>
    /// Put card as an asynchronous operation.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    public async Task<OperationResult<User>> PutCardAsync(User model)
    {
        var dto = await SendAsync<User>("", HttpMethod.Put, model);
        return dto;
    }

    /// <summary>
    /// Delete card as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    public async Task<OperationResult<User>> DeleteCardAsync(int id)
    {
        var dto = await SendAsync<User>($"{id}", HttpMethod.Delete);
        return dto;
    }

    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath { get; }
}