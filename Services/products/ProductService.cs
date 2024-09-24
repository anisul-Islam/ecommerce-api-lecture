using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IProductService
{
    PaginatedResult<ProductDto> GetProductsService(int pageNumber, int pageSize, string? searchBy);
    Product CreateProductService(CreateProductDto createProduct);
    bool DeleteProductByIdService(Guid id);
    ProductDto? GetProductByIdService(Guid id);

}
public class ProductService : IProductService
{
    private static readonly List<Product> _products = new List<Product>();

    public PaginatedResult<ProductDto> GetProductsService(int pageNumber, int pageSize, string? searchBy = null)
    {
        // products => Id, Name, Price, Description, CreatedAt 
        // ProductDto => Id, Name, Price


        var filterProducts = _products.Where(p => p.Name.Contains(searchBy, StringComparison.OrdinalIgnoreCase));


        var products = filterProducts.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        }).ToList();

        var paginatedResult = new PaginatedResult<ProductDto>
        {
            PageSize = pageSize,
            pageNumber = pageNumber,
            SearchBy = searchBy,
            TotalItems = products.Count,
            Items = products
        };

        return paginatedResult;
    }

    public Product CreateProductService(CreateProductDto createProduct)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = createProduct.Name,
            Price = createProduct.Price,
            Description = createProduct.Description,
            CreatedAt = DateTime.Now,
        };
        _products.Add(product);
        return product;
    }

    public bool DeleteProductByIdService(Guid id)
    {
        // Find the product 
        var product = _products.FirstOrDefault(product => product.Id == id);

        if (product == null)
        {
            return false;
        }

        _products.Remove(product);
        return true;
    }


    public ProductDto? GetProductByIdService(Guid id)
    {
        var product = _products.FirstOrDefault(product => product.Id == id);

        if (product == null)
        {
            return null;
        }

        // create the return dto 
        var productData = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };

        return productData;

    }
}
