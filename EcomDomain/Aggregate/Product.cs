using AutoMapper;
using EcomDomain.Enities;

namespace EcomDomain.Aggregate;

public class Product
{
    public Product()
    {
    }
    public Product(ProductEntities productEntities)
    {
        ProductEntity = productEntities;
    }
    public ProductEntities? ProductEntity { get; set; }
    public static Product AddProduct(ProductEntities productEntities,IMapper _mapper)
    {
        var product = new Product(productEntities);
        return product;
    }
    public Product UpdateProduct(ProductEntities productEntities,IMapper _mapper)
    {
        if (ProductEntity == null)
        {
            throw new Exception("Product cannot be null when updating.");
        }
        ProductEntity.ProductName = productEntities.ProductName;
        ProductEntity.Quantity = productEntities.Quantity;
        ProductEntity.Description = productEntities.Description;
        return this;
    }
}
