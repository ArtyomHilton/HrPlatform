namespace HrPlatform.Persistence.Postgre.Models;

public record LoginResponseModel
{
    public required Guid Id { get; init; }
    public required string Username { get; init; }
    public required string Email { get; init; }
    public required string PasswordHash { get; init; }
}
