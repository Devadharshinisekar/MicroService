using AutoMapper;
using Ecom.Events;
using EcomDomain.Enities;

namespace EcomDomain.Aggregate;

public class Product : AggregateRoot<Product>
{
    public Product()
    {
    }
    public Product(ProductEntities productEntities)
    {
        ProductEntity = productEntities;
    }
    public ProductEntities? ProductEntity { get; set; }
    public static Product AddProduct(ProductEntities productEntities, IMapper _mapper)
    {
        var product = new Product(productEntities);

        // Map ProductEntities to ProductCreatedEvent
        var productCreatedEvent = _mapper.Map<ProductCreatedEvent>(productEntities);

        // Raise domain event
        product.AddDomainEvent(productCreatedEvent);

        return product;
    }
    public Product UpdateProduct(ProductEntities productEntities, IMapper _mapper)
    {
        var product = new Product(productEntities);
        if (ProductEntity == null)
            throw new Exception("Product cannot be null when updating.");

        // Apply updates
        ProductEntity.ProductName = productEntities.ProductName;
        ProductEntity.Quantity = productEntities.Quantity;
        ProductEntity.Description = productEntities.Description;
        ProductEntity.Price = productEntities.Price;

        // Map updated entity to an event
        var productUpdatedEvent = _mapper.Map<ProductUpdatedEvent>(ProductEntity);

        // Raise domain event
        product.AddDomainEvent(productUpdatedEvent);

        return this;
    }

    // public Product Restock(int quantity)
    // {
    //     if (quantity <= 0)
    //         throw new Exception("Invalid restock quantity");

    //     ProductEntity.Quantity += quantity;
    //     return this;
    // }
}
