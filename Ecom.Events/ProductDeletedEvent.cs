namespace Ecom.Events;

public class ProductDeletedEvent:ProductEventBase
{
    public bool IsDeleted { get; set; }
}
