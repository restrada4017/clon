using ADN.Utilities.Filters;
using ADN.Application;
using ADN.Utilities;
using AISC.Application;
using ADN.Data;
using AISC.Utilities.Filters;
using ADN.Domain.CustomEntities;
using WebApi.Adn.Middleware;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.Configure<ConfigurationAdn>(configuration.GetSection("ConfigurationAdn"));
var keyVaultAdn = configuration.GetSection("KeyVaultAdn");
builder.Services.Configure<KeyVaultAdn>(keyVaultAdn);

builder.Services.AddInfraestructure();
builder.Services.AddApplication();
builder.Services.AddPersistenceSQL();

//configuracion automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
