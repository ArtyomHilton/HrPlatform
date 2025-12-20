using HrPlatform.Application.Models;

namespace HrPlatform.Application.UseCases.AuthUseCases.RegistrationUseCase;

/// <summary>
/// Регистрация пользователя
/// </summary>
public interface IRegistrationUseCase
{
    public Task Execute(RegistrationModel model, CancellationToken cancellationToken);
}
