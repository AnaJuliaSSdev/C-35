using CrudProductsApiEF.Repository.Interfaces;
using CrudProductsApiEF.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Dto.Product;
using Models.Dto.Subcategory;
using Models.Models;
using StockApp.Models.Models;

namespace CrudProductsApiEF.Service;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;
    private readonly IProductSubCategoryService _productSubCategoryService;
    private readonly IProductSubCategoryRepository _productSubCategoryRepository;

    public ProductService(IProductRepository productRepository, IProductSubCategoryService productSubCategoryService, IProductSubCategoryRepository productSubCategoryRepository)
    {
        _productRepository = productRepository;
        _productSubCategoryService = productSubCategoryService;
        _productSubCategoryRepository = productSubCategoryRepository;
    }

    public async Task<IActionResult> CreateProductAsync(CreateProductDto productDto)
    {
        try
        {
            Product product = new()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                Category = productDto.Category,
                Perishable = productDto.Perishable
            };

            Product createdProduct = await _productRepository.CreateProductAsync(product);
            await _productSubCategoryService.CreateProductSubCategoryAsync(createdProduct, productDto.SubCategories);

            ListProductDTO listProductDto = new()
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Price = createdProduct.Price,
                Description = createdProduct.Description,
                Category = createdProduct.Category,
                Perishable = createdProduct.Perishable,
                SubCategories = createdProduct.ProductSubCategories.Select(sub => new ListSubcategoryDto
                {
                    Id = sub.SubCategory.Id,
                    Name = sub.SubCategory.Name
                }).ToList()
            };

            return new OkObjectResult(listProductDto);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    public async Task<IActionResult> GetAllProductsAsync(int skip, int take)
    {
        try
        {
            IEnumerable<Product> products = await _productRepository.GetAllProductsAsync(skip, take);

            List<ListProductDTO> productDTOs = products.Select(product => new ListProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category,
                Perishable = product.Perishable,
                SubCategories = product.ProductSubCategories.Select(sub => new ListSubcategoryDto
                {
                    Id = sub.SubCategory.Id,
                    Name = sub.SubCategory.Name
                }).ToList()
            }).ToList();

            return new OkObjectResult(productDTOs);
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
            if (product == null) return new NotFoundObjectResult("Product not found.");

            ListProductDTO productDto = new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category,
                Perishable = product.Perishable,
                SubCategories = product.ProductSubCategories.Select(sub => new ListSubcategoryDto
                {
                    Id = sub.SubCategory.Id,
                    Name = sub.SubCategory.Name
                }).ToList()
            };

            return new OkObjectResult(productDto);
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
            Product? product = await _productRepository.GetProductByIdAsync(productDto.Id);
            if (product == null) return new NotFoundObjectResult("Product not found.");

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Description = productDto.Description;
            product.Category = productDto.Category;
            product.Perishable = productDto.Perishable;

            Product updatedProduct = await _productRepository.UpdateProductAsync(product);

            var listProductDto = new ListProductDTO
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                Price = updatedProduct.Price,
                Description = updatedProduct.Description,
                Category = updatedProduct.Category,
                Perishable = updatedProduct.Perishable
            };

            return new OkObjectResult(listProductDto);

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

            await _productRepository.DeleteProductAsync(product);

            return new NoContentResult();
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}
