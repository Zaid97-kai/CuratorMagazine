using CuratorMagazineWebAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.DependencyInjection;

/// <summary>
/// Class PersistenceServiceCollectionExtensions.
/// </summary>
public static class PersistenceServiceCollectionExtensions
{
    /// <summary>
    /// Adds the persistence.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:DbConnection"];
        services.AddDbContext<CuratorMagazineContext>(options =>
        {
            //options.UseSqlServer(connectionString);
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<ICuratorMagazineContext>(provider => provider.GetService<CuratorMagazineContext>());
        return services;
    }
}