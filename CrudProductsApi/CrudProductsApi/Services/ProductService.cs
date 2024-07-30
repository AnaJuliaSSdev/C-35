using CrudProductsApi.Dto;
using CrudProductsApi.Models;
using CrudProductsApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrudProductsApi.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IActionResult> CreateProductAsync(CreateProductDto productDto)
    {
        try
        {
            int newProductId = await _productRepository.CreateProductAsync(productDto);
            var createdProduct = await _productRepository.GetProductByIdAsync(newProductId);

            if (createdProduct != null) return new OkObjectResult(createdProduct);

            return new BadRequestObjectResult("Failed to create product.");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }

    }

    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        try
        {
            Product? product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return new NotFoundObjectResult("Product not found.");

            await _productRepository.DeleteProductAsync(id);
            return new NoContentResult();
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }

    }

    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        try
        {
            Product? product = await _productRepository.GetProductByIdAsync(id);
            if (product != null)
                return new OkObjectResult(product);

            return new NotFoundObjectResult("Product not found.");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    public async Task<IActionResult> UpdateProductAsync(UpdateProductDto productDto)
    {
        try
        {
            Product? productToUpdate = await _productRepository.GetProductByIdAsync(productDto.Id);
            if (productToUpdate == null) return new NotFoundObjectResult("Product not found.");

            await _productRepository.UpdateProductAsync(productDto);
            return new OkObjectResult(productDto);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    public async Task<IActionResult> FilterProductsAsync(FilterProductsDto filterProductsDto)
    {
        try
        {
            var products = await _productRepository.FilterProductsAsync(filterProductsDto);
            if (!products.Any())
                return new NotFoundObjectResult("No products found matching the criteria.");

            return new OkObjectResult(products);

        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}
