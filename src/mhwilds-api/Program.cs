using mhwilds_api;
using mhwilds_api.Interfaces;
using mhwilds_api.Repository;
using mhwilds_api.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// configuration
builder.Configuration.AddUserSecrets<Program>();
var connectionString = builder.Configuration.GetConnectionString("Database")
    ?? throw new InvalidOperationException("Connection string 'Database' not found.");

// database setup
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)
);

// repository layer:
builder.Services.AddScoped<IWeaponRepository, WeaponRepository>();
builder.Services.AddScoped<IArmourRepository, ArmourRepository>();

// service layer:
// this is an extension to the Irepository factories,
// it handles error checking and any additional functionalities that,
// is inappropriate for repository models.
builder.Services.AddScoped<IWeaponService, WeaponService>();
builder.Services.AddScoped<IArmourService, ArmourService>();

// setup mapster
MapsterConfig.Configure();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        // remove $type fields
        options.SerializerSettings.TypeNameHandling = TypeNameHandling.None;        
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

        // convert enums to strings
        options.SerializerSettings.Converters.Add(new StringEnumConverter());     
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using IServiceScope scope = app.Services.CreateScope();
    ApplyMigration<ApplicationDbContext>(scope);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

static void ApplyMigration<TDbContext>(IServiceScope scope) 
    where TDbContext : DbContext
{
    using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();
    context.Database.Migrate();
}