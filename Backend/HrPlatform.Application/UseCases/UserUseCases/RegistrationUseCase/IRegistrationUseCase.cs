namespace HrPlatform.Application.UseCases.UserUseCases.RegistrationUseCase;

/// <summary>
/// Регистрация пользователя
/// </summary>
public interface IRegistrationUseCase
{
    public Task Execute(RegistrationModel model, CancellationToken cancellationToken);
}
