using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IProductService{
    List<ProductDto> GetProductsService();
    Product CreateProductService(CreateProductDto createProduct);
    bool DeleteProductByIdService(Guid id);
    ProductDto? GetProductByIdService(Guid id);
    
} 
public class ProductService: IProductService
{
    private static readonly List<Product> _products = new List<Product>();

    public List<ProductDto> GetProductsService()
    {
        // products => Id, Name, Price, Description, CreatedAt 
        // ProductDto => Id, Name, Price
        var products = _products.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        }).ToList();

        return products;
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
