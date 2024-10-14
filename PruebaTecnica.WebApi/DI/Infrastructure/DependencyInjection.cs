using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Infrastructure;

namespace PruebaTecnica.WebApi.DI.Infrastructure;
public static class DependencyInjection{

    public static IServiceCollection AddMySql(this IServiceCollection services){

        var ConnectionString = "Server=localhost; database=PruebaTecnica; user=root; pwd=S1d10squ13r3$.;";

        services.AddDbContext<PruebaTecnicaContext>(options => 
            options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));

        return services;
    }
}