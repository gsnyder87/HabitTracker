using Microsoft.EntityFrameworkCore;
using HabitTracker.DataAccess;
using HabitTracker.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace HabitTracker.ApiService.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Category").WithTags(nameof(Category));

        group.MapGet("/", async (PubContext db) =>
        {
            return await db.Categories.ToListAsync();
        })
        .WithName("GetAllCategories")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Category>, NotFound>> (int categoryid, PubContext db) =>
        {
            return await db.Categories.AsNoTracking()
                .FirstOrDefaultAsync(model => model.CategoryId == categoryid)
                is Category model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCategoryById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int categoryid, Category category, PubContext db) =>
        {
            var affected = await db.Categories
                .Where(model => model.CategoryId == categoryid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.CategoryId, category.CategoryId)
                    .SetProperty(m => m.Name, category.Name)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCategory")
        .WithOpenApi();

        group.MapPost("/", async (Category category, PubContext db) =>
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Category/{category.CategoryId}",category);
        })
        .WithName("CreateCategory")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int categoryid, PubContext db) =>
        {
            var affected = await db.Categories
                .Where(model => model.CategoryId == categoryid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCategory")
        .WithOpenApi();
    }
}
