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
builder.Services.AddScoped<IAirportsDatumService, AirportsDatumService>();
builder.Services.AddScoped<IAirportsDatumRepository, AirportsDatumRepository>();
builder.Services.AddDbContext<DbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DbContext)));
    });
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseCors("AllowAll");

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();