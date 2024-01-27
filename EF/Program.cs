using MyShop.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
//using ServerDb.Extension;
using MyShop.WebAPI.Data.Repositories;
using MyShop.Domain.RepositoryInterfaces;
using MyShop.Domain.Services;
using FrontendBlazor;
using MyShop.Domain.Services.Interfaces;
using MyShop.AspNetCorePasswordHasherLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb"));
});

builder.Services.AddScoped<IProductRepository, ProductRepositoryEF>();
builder.Services.AddSingleton<IAppPasswordHasher, AspNetCorePasswordHasher>();
builder.Services.AddScoped<IAccountRepository, AccountRepositoryEF>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddCors();
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy =>
{
    policy
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin();
});


app.UseMiddleware<OnlyEdgeMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
