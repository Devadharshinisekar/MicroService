using EcomDomain.Enities;

namespace EcomApplication.Product.Commands;

public class CreateProductCommand
{
    public ProductEntities ProductCore{ get; set; }
    public CreateProductCommand(ProductEntities product)
    {
        ProductCore = product;
    }
}
