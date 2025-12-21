using HrPlatform.Domain.Entities;
using HrPlatform.Persistence.Postgre.Abstractions;
using HrPlatform.Persistence.Postgre.Context;
using Microsoft.EntityFrameworkCore;

namespace HrPlatform.Persistence.Postgre.Repositories;

class RegisterUserRepository(HrPlatformDbContext context) : IRegisterUserRepository
{
    public async Task<User?> AddUserAsync(User user, CancellationToken cancellationToken)
    {
        var entry = await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return entry?.Entity;
    }

    public async Task<bool> IsExistEmailAsync(string email, CancellationToken cancellationToken) => 
        await context.Users.AnyAsync(x=> x.Email == email, cancellationToken);

    public async Task<bool> IsExistUsernameAsync(string username, CancellationToken cancellationToken) =>
        await context.Users.AnyAsync(x=> x.Username == username, cancellationToken);
}
