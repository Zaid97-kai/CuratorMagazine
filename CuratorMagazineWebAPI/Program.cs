using Microsoft.AspNetCore.DataProtection;
using CuratorMagazineWebAPI.DependencyInjection;
using CuratorMagazineWebAPI.Models.Context;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "Swagger Demo API",
            Description = "Demo API for showing Swagger",
            Version = "v1"
        });
});

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddDataProtection().PersistKeysToDbContext<CuratorMagazineContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<CuratorMagazineContext>();
    }
    catch (Exception)
    {
        Console.WriteLine("");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
