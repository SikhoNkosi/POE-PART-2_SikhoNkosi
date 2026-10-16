using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RaceDay.API.Data;
using RaceDay.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// The tests supply their own in-memory database, so SQL Server is skipped when testing
if (!builder.Environment.IsEnvironment("Testing"))
{
    builder.Services.AddDbContext<RaceDayContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

// Server-side session: the server remembers the logged-in user's ID and role
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(SessionAuthenticationHandler.SchemeName)
    .AddScheme<AuthenticationSchemeOptions, SessionAuthenticationHandler>(
        SessionAuthenticationHandler.SchemeName, null);

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "RaceDay API", Version = "v1" });

    // Show the XML comments from the controllers as endpoint descriptions in Swagger
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }