using Theatre.Domain.Entities;

namespace Theatre.Application.Common.Interfaces;

public interface IUsersRepository
{
    Task<User?> GetByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(User user, CancellationToken cancellationToken);
    Task UpdateAsync(User user, CancellationToken cancellationToken);
    Task RemoveAsync(Guid userId, CancellationToken cancellationToken);
}