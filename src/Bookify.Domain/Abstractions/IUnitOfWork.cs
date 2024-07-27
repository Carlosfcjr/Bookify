namespace Bookify.Domain;

public interface IUnitOfWork
{
    Task<int> SaveChancesAsync(CancellationToken cancellationToken = default);
}
