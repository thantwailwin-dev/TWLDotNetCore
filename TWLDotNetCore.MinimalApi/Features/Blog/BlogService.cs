using Microsoft.EntityFrameworkCore;
using TWLDotNetCore.MinimalApi.Db;
using TWLDotNetCore.MinimalApi.Models;


namespace TWLDotNetCore.MinimalApi.Features.Blog
{
    public static class BlogService
    {
        public static IEndpointRouteBuilder MapBlogs(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/Blog", async (AppDbContext db) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync();
                return Results.Ok(lst);
            });

            app.MapPost("api/Blog", (AppDbContext db, BlogModel blog) =>
            {
                db.Blogs.Add(blog);
                var result = db.SaveChanges();

                string message = result > 0 ? "Saving Success!" : "Saving Failed!";
                return Results.Ok(message);
            });

            app.MapPut("api/Blog/{id}", (AppDbContext db, int id, BlogModel blog) =>
            {
                var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found.");
                }

                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;

                var result = db.SaveChanges();
                string message = result > 0 ? "Updating Success!" : "Updating Failed!";
                return Results.Ok(message);
            });

            app.MapDelete("api/Blog/{id}", (AppDbContext db, int id) =>
            {
                var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found.");
                }
                db.Blogs.Remove(item);
                var result = db.SaveChanges();
                string message = result > 0 ? "Deleting Success!" : "Deleting Failed!";
                return Results.Ok(message);
            });

            return app;

        }
    }
}
