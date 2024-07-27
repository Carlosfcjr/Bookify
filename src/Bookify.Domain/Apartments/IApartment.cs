namespace Bookify.Domain.Apartments;

public interface IApartment
{
    Task<Apartment?> GetByAsync(Guid id, CancellationToken cancellationToken = default);
}
