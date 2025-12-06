using HrPlatform.Application.Abstractions;

namespace HrPlatform.Infrastructure.Services;

class PasswordHashedService : IPasswordHashedService
{
    public string Hash(string password) => 
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string hashPassword, string currentPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(currentPassword, hashPassword);
}
