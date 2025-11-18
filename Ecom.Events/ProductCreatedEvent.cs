namespace Ecom.Events;

public class ProductCreatedEvent:BaseDomainEvent
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
