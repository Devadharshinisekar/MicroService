
using EcomDomain.Aggregate;
namespace EcomDomain.IRepository;
public interface IProductAggregateRepository
{
    Task<string> AddProduct(Product product);
    Task<string> UpdateProduct(Product product);
    Task<string> Restock(Product aggregate);
}
