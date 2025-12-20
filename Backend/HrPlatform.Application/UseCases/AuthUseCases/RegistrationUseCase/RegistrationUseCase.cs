using HrPlatform.Application.Abstractions;
using HrPlatform.Application.Models;
using HrPlatform.Domain.Entities;
using HrPlatform.Persistence.Postgre.Context;

namespace HrPlatform.Application.UseCases.AuthUseCases.RegistrationUseCase;

class RegistrationUseCase(HrPlatformDbContext context, IPasswordHashedService hashedService) : IRegistrationUseCase
{
    public async Task Execute(RegistrationModel model, CancellationToken cancellationToken)
    {
        model.Password = hashedService.Hash(model.Password);

        await context.Users.AddAsync((User)model, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
