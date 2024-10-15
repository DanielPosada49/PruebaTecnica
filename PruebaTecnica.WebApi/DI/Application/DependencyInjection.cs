using PruebaTecnica.Application.Contracts;
using PruebaTecnica.Application.UseCase;

namespace PruebaTecnica.WebApi.DI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services){
        
        services.AddTransient<IEmployeeUseCase, EmployeeUseCase>();
        services.AddTransient<IPositionHistoryUseCase, PositionHistoryUseCase>();

        return services;
    }
}
