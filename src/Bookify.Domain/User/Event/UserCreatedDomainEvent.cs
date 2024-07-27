namespace Bookify.Domain.User.Event;

public record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;



