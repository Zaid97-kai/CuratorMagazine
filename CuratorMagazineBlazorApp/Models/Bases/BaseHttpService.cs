using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace CuratorMagazineBlazorApp.Models.Bases;

/// <summary>
/// Class BaseHttpService.
/// </summary>
public abstract class BaseHttpService
{
    /// <summary>
    /// The client
    /// </summary>
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseHttpService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    protected BaseHttpService(HttpClient httpClient)
    {
        _client = httpClient;
        _client.Timeout = TimeSpan.FromMinutes(5);
    }

    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected abstract string BasePath { get; }

    /// <summary>
    /// Creates the content.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>HttpContent.</returns>
    private static HttpContent CreateContent(object model)
    {
        if (model is HttpContent cont)
            return cont;

        var content = new ByteArrayContent(model == null
            ? Array.Empty<byte>()
            : Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        content.Headers.ContentEncoding.Add("UTF-8");
        return content;
    }

    /// <summary>
    /// Creates the message.
    /// </summary>
    /// <param name="uri">The URI.</param>
    /// <param name="method">The method.</param>
    /// <param name="model">The model.</param>
    /// <returns>HttpRequestMessage.</returns>
    private static HttpRequestMessage CreateMessage(string uri, HttpMethod method, object model)
    {
        var message = new HttpRequestMessage(method, uri);
        if (method != HttpMethod.Post && method != HttpMethod.Put)
            return message;

        message.Content = CreateContent(model);
        return message;
    }
}