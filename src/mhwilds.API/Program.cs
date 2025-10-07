using mhwilds.Application;
using mhwilds.Infrastructure;
using mhwilds.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// add configuration
// contains db connection string
builder.Configuration.AddUserSecrets<Program>();

// add layers
builder.Services.AddApplication();                              
builder.Services.AddInfrastructure(builder.Configuration);      

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
    using var scope = app.Services.CreateScope();

    // apply migrations directly (no need for service)
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
