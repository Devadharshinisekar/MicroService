
using EcomDomain.Aggregate;
namespace EcomDomain.IRepository;

public interface IProductRepository
{
   
    Task<Product> GetProductById(int productid);
    Task<List<Product>> GetAllProducts();
    

}
