using ClassLibrary1.Services;
using Core.Abstractions;
using Core.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using DbContext = DataAccess.DbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IAircraftsDatumService, AircraftsDatumService>();
builder.Services.AddScoped<IAircraftsDatumRepository, AircraftsDatumRepository>();
builder.Services.AddDbContext<DbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DbContext)));
    });

var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();