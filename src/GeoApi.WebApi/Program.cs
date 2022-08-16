using FluentValidation;
using Geo.Api.Controllers.Models;
using GeoApi.Application;
using GeoApi.WebApi.Controllers.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEarthCalculationApplicationService, EarthCalculationApplicationService>();
builder.Services.AddScoped<IValidator<EarthSurfaceDistanceRequest>, EarthSurfaceDistanceRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
