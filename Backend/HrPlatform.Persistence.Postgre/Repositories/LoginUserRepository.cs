using HrPlatform.Persistence.Postgre.Abstractions;
using HrPlatform.Persistence.Postgre.Context;
using HrPlatform.Persistence.Postgre.Models;
using Microsoft.EntityFrameworkCore;

namespace HrPlatform.Persistence.Postgre.Repositories;

class LoginUserRepository(HrPlatformDbContext context) : ILoginUserRepository
{
    public async Task<LoginResponseModel?> GetUserByEmailAsync(string email, CancellationToken cancellationToken) =>
        await context.Users.Select(x => new LoginResponseModel
        {
            Id = x.Id,
            Username = x.Username,
            Email = email,
            PasswordHash = x.PasswordHash,
        }).FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
}