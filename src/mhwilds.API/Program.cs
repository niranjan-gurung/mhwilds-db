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

// add repo and service layers:
// @service layer:
//      this is an extension to the Irepository factories,
//      it handles error checking and any additional functionalities that,
//      is inappropriate for repository models.
builder.Services.AddApplication();                              // service
builder.Services.AddInfrastructure(builder.Configuration);      // repository

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
