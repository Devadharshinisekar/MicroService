using EcomApplication.Product.Commands;

namespace EcomApplication.Product.CommandHandelers;

public interface IProductCommandHandler
{
    Task<string> AddProduct(CreateProductCommand command);
    Task<string> UpdateProduct(UpdateProductCommand command);
}
