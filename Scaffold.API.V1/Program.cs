using Microsoft.EntityFrameworkCore;
using Scaffold.API.V1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddDbContext<NetIdentityContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySqlDatabase");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();