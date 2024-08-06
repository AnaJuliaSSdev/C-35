using CrudProductsApiEF.Context;
using CrudProductsApiEF.Repository.Interfaces;
using CrudProductsApiEF.Repository;
using CrudProductsApiEF.Service.Interfaces;
using CrudProductsApiEF.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
builder.Services.AddScoped<ISubcategoryService, SubcategoryService>();

builder.Services.AddScoped<IProductSubCategoryRepository, ProductSubCategoryRepository>();
builder.Services.AddScoped<IProductSubCategoryService, ProductSubcategoryService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

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
