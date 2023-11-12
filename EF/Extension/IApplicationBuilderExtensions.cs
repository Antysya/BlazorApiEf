using ServerDb.Data;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace ServerDb.Extension
{
    public static class IApplicationBuilderExtensions
    {
        public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/products", (AppDbContext dbContext) =>
            {
                return dbContext.Product.ToListAsync();
            });
            app.MapPost("/api/products/add",async ([FromServices]AppDbContext dbContext, [FromBody]Product product) =>
            {
                await dbContext.Product.AddAsync(product);
                await dbContext.SaveChangesAsync();
            });
            return app;
        }
    }
}
