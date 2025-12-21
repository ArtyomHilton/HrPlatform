using HrPlatform.Persistence.Postgre.Models;

namespace HrPlatform.Persistence.Postgre.Abstractions;

public interface ILoginUserRepository
{
    Task<LoginResponseModel?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
}
