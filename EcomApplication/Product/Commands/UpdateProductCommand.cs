using EcomDomain.Enities;

namespace EcomApplication.Product.Commands;

public class UpdateProductCommand
{
     public ProductEntities ProductCore{ get; set; }   
    public UpdateProductCommand(ProductEntities product)
    {
        ProductCore = product;
    }
}
