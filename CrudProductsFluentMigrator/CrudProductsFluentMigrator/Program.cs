using CrudProductsFluentMigrator.Middleware;
using CrudProductsFluentMigrator.Models.Dto;
using CrudProductsFluentMigrator.Repository;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IProductRepository, ProductRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/products", async (CreateProductDto createProductDto, IProductRepository productRepository) =>
{
    var product = await productRepository.CreateProductAsync(createProductDto);
    return Results.Created($"/products/{product.Id}", product);
}).WithName("CreateProduct");

app.MapGet("/products", async (IProductRepository productRepository) =>
{
    var products = await productRepository.GetAllProductsAsync();
    return Results.Ok(products);
}).WithName("GetProducts");

app.MapGet("/products/{id}", async (int id, IProductRepository productRepository) =>
{
    var product = await productRepository.GetProductByIdAsync(id);
    if (product == null)
        return Results.NotFound();
    return Results.Ok(product);
}).WithName("GetProductById");

app.MapPut("/products", async (UpdateProductDto updateProductDto, IProductRepository productRepository) =>
{
    var updatedProduct = await productRepository.UpdateProductAsync(updateProductDto);
    return Results.Ok(updatedProduct);
}).WithName("UpdateProduct");

app.MapDelete("/products/{id}", async (int id, IProductRepository productRepository) =>
{
    await productRepository.DeleteProductAsync(id);
    return Results.NoContent();
}).WithName("DeleteProduct");

app.UseHttpsRedirection();


app.Run();