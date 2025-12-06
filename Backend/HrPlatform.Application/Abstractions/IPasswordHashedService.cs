namespace HrPlatform.Application.Abstractions;

public interface IPasswordHashedService
{
    string Hash(string password);
    bool Verify(string hashPassword, string currentPassword);
}
