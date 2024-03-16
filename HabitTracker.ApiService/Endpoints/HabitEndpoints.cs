using Microsoft.EntityFrameworkCore;
using HabitTracker.DataAccess;
using HabitTracker.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace HabitTracker.ApiService.Endpoints;

public static class HabitEndpoints
{
    public static void MapHabitEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Habit").WithTags(nameof(Habit));

        group.MapGet("/", async (PubContext db) =>
        {
            return await db.Habits.ToListAsync();
        })
        .WithName("GetAllHabits")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Habit>, NotFound>> (int habitid, PubContext db) =>
        {
            return await db.Habits.AsNoTracking()
                .FirstOrDefaultAsync(model => model.HabitId == habitid)
                is Habit model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetHabitById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int habitid, Habit habit, PubContext db) =>
        {
            var affected = await db.Habits
                .Where(model => model.HabitId == habitid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.HabitId, habit.HabitId)
                    .SetProperty(m => m.Name, habit.Name)
                    .SetProperty(m => m.CategoryId, habit.CategoryId)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateHabit")
        .WithOpenApi();

        group.MapPost("/", async (Habit habit, PubContext db) =>
        {
            db.Habits.Add(habit);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Habit/{habit.HabitId}",habit);
        })
        .WithName("CreateHabit")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int habitid, PubContext db) =>
        {
            var affected = await db.Habits
                .Where(model => model.HabitId == habitid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteHabit")
        .WithOpenApi();
    }
}
