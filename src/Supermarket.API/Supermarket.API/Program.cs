using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Repositories;
using Supermarket.Core.Repositories.Categories;
using Supermarket.Core.Services.Categories;
using Supermarket.Persistence.Contexts;
using Supermarket.Persistence.Repositories.Categories;
using Supermarket.Persistence.Repositories;
using DotNetEnv;
using Supermarket.Core.Repositories.Products;
using Supermarket.Core.Services.Products;
using Supermarket.Persistence.Repositories.Products;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SupermarketContext>(options => 
    {
        Env.Load();
        var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
        options.UseSqlServer(connectionString);
    }
);

builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly(),
    Assembly.Load("Supermarket.Handlers")
));

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
