using Microsoft.EntityFrameworkCore;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Infrastructure.Data;

namespace Theatre.Infrastructure.Repositories;

public class UsersRepository(TheatreDbContext dbContext) : IUsersRepository
{
    private readonly TheatreDbContext _dbContext = dbContext;

    public async Task<User?> GetByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber, cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FindAsync([id], cancellationToken);
    }

    public async Task CreateAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await GetByIdAsync(userId, cancellationToken);
        if (user is not null)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}