namespace CuratorMagazineWebAPI.Models.Bases.Filters;

/// <summary>
/// Class BaseFilterGetList.
/// </summary>
public class BaseFilterGetList
{
    /// <summary>
    /// The page
    /// </summary>
    private int? _page;
    /// <summary>
    /// Gets or sets the query.
    /// </summary>
    /// <value>The query.</value>
    public string query { get; set; }

    /// <summary>
    /// Gets or sets the page.
    /// </summary>
    /// <value>The page.</value>
    public int page
    {
        get => _page ?? 1;
        set => _page = value;
    }
}