using EcomApplication.Product.Queries;

namespace EcomApplication.Product.QueryHandlers;

public interface IProductQueryHandler
{
    Task<List<EcomDomain.Aggregate.Product>> GetProducts();
    Task<EcomDomain.Aggregate.Product> GetProductById(GetProductByProductIdQuery query);
}
