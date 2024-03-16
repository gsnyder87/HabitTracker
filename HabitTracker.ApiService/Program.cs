
using HabitTracker.DataAccess;
using HabitTracker.Domain;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using HabitTracker.ApiService.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PubContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PubConnection"))
    .EnableSensitiveDataLogging()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





//testing
// Configure the HTTP request pipeline.
app.UseExceptionHandler();









app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.MapUserEndpoints();

app.MapCategoryEndpoints();

app.MapHabitEndpoints();

app.MapActivityEndpoints();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
