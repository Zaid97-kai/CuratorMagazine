namespace CuratorMagazineBlazorApp.Models.Bases;

/// <summary>
/// Class BaseService.
/// Implements the <see cref="CuratorMagazineBlazorApp.Models.Bases.BaseHttpService" />
/// </summary>
/// <seealso cref="CuratorMagazineBlazorApp.Models.Bases.BaseHttpService" />
public abstract class BaseService : BaseHttpService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    protected BaseService(IHttpClientFactory httpClient) : base(httpClient.CreateClient("CuratorMagazineWebAPI"))
    {
    }
}