namespace HrPlatform.Application.Abstractions;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool Verify(string password, string hashPassword);
}
