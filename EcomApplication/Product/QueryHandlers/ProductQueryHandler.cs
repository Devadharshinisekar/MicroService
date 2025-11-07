
using EcomApplication.Product.Queries;
using EcomDomain.IRepository;

namespace EcomApplication.Product.QueryHandlers;

public class ProductQueryHandler : IProductQueryHandler
{
    private readonly IProductRepository _productRespository;
    public ProductQueryHandler(IProductRepository productRepository)
    {
        _productRespository = productRepository;
    }
    public async Task<List<EcomDomain.Aggregate.Product>> GetProducts()
    {
        var products = await _productRespository.GetAllProducts();
        if (products == null || products.Count == 0)
        {
            throw new Exception("No product Found");
        }
        return products;
    }
    public async Task<EcomDomain.Aggregate.Product> GetProductById(GetProductByProductIdQuery query)
    {
        if (query.ProductId <= 0)
        {
            throw new Exception("Invalid Product");
        }
        var product =await _productRespository.GetProductById(query.ProductId);
        if (product == null)
        {
            throw new Exception("Not Found");
        }
        return product;
    }
}
