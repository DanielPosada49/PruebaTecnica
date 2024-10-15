using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;
using PruebaTecnica.Infrastructure;
using PruebaTecnica.Infrastructure.Respository;
using PruebaTecnica.Infrastructure.Respository.Base;

namespace PruebaTecnica.WebApi.DI.Infrastructure;
public static class DependencyInjection{

    public static IServiceCollection AddMySql(this IServiceCollection services){

        //Server=localhost; database=PruebaTecnica; user=root; pwd=;
        var ConnectionString = "Server=localhost; database=PruebaTecnica; user=root; pwd=S1d10squ13r3$.";

        services.AddDbContext<PruebaTecnicaContext>(options => 
            options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));

        services.AddScoped<IRepository<TblEmployee>, BaseRespository<TblEmployee>>();
        services.AddScoped<IRepository<TblDepartment>, BaseRespository<TblDepartment>>();
        services.AddScoped<IRepository<TblPositionHistory>, BaseRespository<TblPositionHistory>>();
        services.AddScoped<IRepository<TblProject>, BaseRespository<TblProject>>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}