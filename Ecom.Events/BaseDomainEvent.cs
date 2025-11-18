namespace Ecom.Events;

public class BaseDomainEvent
{    public DateTime OccurredOn { get; private set; } = DateTime.UtcNow;
}
