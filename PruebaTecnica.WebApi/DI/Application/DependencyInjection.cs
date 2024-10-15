using PruebaTecnica.Application.Contracts;
using PruebaTecnica.Application.UseCase;
using PruebaTecnica.WebApi.Extensions;

namespace PruebaTecnica.WebApi.DI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services){
        
        services.AddTransient<IEmployeeUseCase, EmployeeUseCase>();
        services.AddTransient<IPositionHistoryUseCase, PositionHistoryUseCase>();

        //Middleware
        services.AddTransient<ConsoleLogMiddleware>();
        return services;
    }
}
