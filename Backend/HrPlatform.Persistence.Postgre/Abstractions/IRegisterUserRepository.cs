using HrPlatform.Domain.Entities;

namespace HrPlatform.Persistence.Postgre.Abstractions;

public interface IRegisterUserRepository
{
    Task<User?> AddUserAsync(User user, CancellationToken cancellationToken);
    Task<bool> IsExistEmailAsync(string email, CancellationToken cancellationToken);
    Task<bool> IsExistUsernameAsync(string username, CancellationToken cancellationToken);
}