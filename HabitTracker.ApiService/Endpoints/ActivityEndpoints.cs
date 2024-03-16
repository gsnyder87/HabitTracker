using Microsoft.EntityFrameworkCore;
using HabitTracker.DataAccess;
using HabitTracker.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace HabitTracker.ApiService.Endpoints;

public static class ActivityEndpoints
{
    public static void MapActivityEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Activity").WithTags(nameof(Activity));

        group.MapGet("/", async (PubContext db) =>
        {
            return await db.Activitys
            .Include(a => a.Habit)
            .ThenInclude(category => category.Category)
            .Include(b => b.User)
            
            .ToListAsync()
            ;
        })
        .WithName("GetAllActivities")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Activity>, NotFound>> (int activityid, PubContext db) =>
        {
            return await db.Activitys.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ActivityId == activityid)
                is Activity model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetActivityById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int activityid, Activity activity, PubContext db) =>
        {
            var affected = await db.Activitys
                .Where(model => model.ActivityId == activityid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.ActivityId, activity.ActivityId)
                    .SetProperty(m => m.HabitId, activity.HabitId)
                    .SetProperty(m => m.UserId, activity.UserId)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateActivity")
        .WithOpenApi();

        group.MapPost("/", async (Activity activity, PubContext db) =>
        {
            db.Activitys.Add(activity);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Activity/{activity.ActivityId}",activity);
        })
        .WithName("CreateActivity")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int activityid, PubContext db) =>
        {
            var affected = await db.Activitys
                .Where(model => model.ActivityId == activityid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteActivity")
        .WithOpenApi();
    }
}
