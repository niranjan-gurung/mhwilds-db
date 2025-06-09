using Microsoft.EntityFrameworkCore;
using mhwilds.Api.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Configuration.AddUserSecrets<Program>();
    
    //var connectionString = builder.Configuration.GetConnectionString("Database")
    //    ?? throw new InvalidOperationException("Connection string 'Database' not found.");

    //builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //    options.UseNpgsql(connectionString)
    //);

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers().AddNewtonsoftJson();
}

var app = builder.Build();
{
    app.MapControllers();
}

if (app.Environment.IsDevelopment())
{
    //using IServiceScope scope = app.Services.CreateScope();
    //ApplyMigration<ApplicationDbContext>(scope);
}

app.Run();

static void ApplyMigration<TDbContext>(IServiceScope scope) 
    where TDbContext : DbContext
{
    using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();
    context.Database.Migrate();
}