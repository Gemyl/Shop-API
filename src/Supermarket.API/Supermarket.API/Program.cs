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
using MediatR;
using Supermarket.Commands.Categories;
using Supermarket.Queries.Categories;
using Supermarket.Handlers.Categories;
using Supermarket.Core.Services.Communication.Categories;
using Supermarket.Core.Dtos.Categories;
using Supermarket.Queries.Products;
using Supermarket.Core.Services.Communication.Products;
using Supermarket.Core.Dtos.Products;
using Supermarket.Handlers.Products;
using Supermarket.Commands.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SupermarketContext>(options => 
    {
        Env.Load();

        var server = Environment.GetEnvironmentVariable("SERVER");
        var database = Environment.GetEnvironmentVariable("DATABASE");
        var user = Environment.GetEnvironmentVariable("USER");
        var password = Environment.GetEnvironmentVariable("PASSWORD");

        var connectionString = $"Server={server};Database={database};User={user};Password={password};Trusted_Connection=True;TrustServerCertificate=True;";
        options.UseSqlServer(connectionString);
    }
);

builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddTransient<IRequestHandler<GetAllCategories, IEnumerable<CategoryDto>>, GetAllCategoriesHandler>();
builder.Services.AddTransient<IRequestHandler<CreateCategory, CategoryResponse>, CreateCategoryHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateCategory, CategoryResponse>, UpdateCategoryHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteCategory, CategoryResponse>, DeleteCategoryHandler>();

builder.Services.AddTransient<IRequestHandler<GetAllProducts, IEnumerable<ProductDto>>, GetAllProductsHandler>();
builder.Services.AddTransient<IRequestHandler<CreateProduct, ProductResponse>, CreateProductHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateProduct, ProductResponse>, UpdateProductHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteProduct, ProductResponse>, DeleteProductHandler>();

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
