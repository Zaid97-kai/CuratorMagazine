using CuratorMagazineBlazorApp.Data.Common;
using CuratorMagazineBlazorApp.Models.Bases;
using CuratorMagazineWebAPI.Models.Entities;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Bases;

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
        //var dto = await SendAsync<List<User>>("", HttpMethod.Get);
        //return dto;
        return null;
    }

    /// <summary>
    /// Get card as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<User>> GetAsync(int id)
    {
        var dto = await SendAsync<User>($"{id}", HttpMethod.Get);
        return dto;
    }

    /// <summary>
    /// Create card as an asynchronous operation.
    /// </summary>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<User>> CreateCardAsync()
    {
        var dto = await SendAsync<User>($"Create", HttpMethod.Post);
        return dto;
    }

    /// <summary>
    /// Put card as an asynchronous operation.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    public async Task<OperationResult<User>> PutCardAsync(User model)
    {
        //var dto = await SendAsync<User>("", HttpMethod.Put, model);
        //return dto;
        return null;
    }

    /// <summary>
    /// Delete card as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    public async Task<OperationResult<User>> DeleteCardAsync(int id)
    {
        //var dto = await SendAsync<User>($"{id}", HttpMethod.Delete);
        //return dto;
        return null;
    }

    /// <summary>
    /// Post as an asynchronous operation.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public override async Task<BaseResponse<BaseDtoListResult>> PostAsync(string query = "")
    {
        var parameters = new Dictionary<string, string>
        {
            { "query", query }, 
            { "page", "1" }
        };
        var ret = await SendAsync<BaseDtoListResult>("GetList", HttpMethod.Post, parameters);
        return ret;
    }

    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => "User";
}