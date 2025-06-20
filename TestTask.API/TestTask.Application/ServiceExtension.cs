using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Application.Mapping;
using TestTask.Application.Mapping.Abstraction;
using TestTask.Application.RepositoriesImplementation;
using TestTask.Application.Services;
using TestTask.Application.ServicesAbstraction;
using TestTask.DataAccess;
using TestTask.DataAccess.RepositoriesAbstraction;

namespace TestTask.Application;

public static class ServiceExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<UsersContext>(o=>o.UseNpgsql(config.GetConnectionString("TestTaskDB")));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserTypeRepository, UserTypeRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserTypeRepositoryValidationService, UserTypeRepositoryValidationService>();
        services.AddScoped<IUserRepositoryValidationService, UserRepositoryValidationService>();
        services.AddScoped<IExcelExportService, ExcelExportService>();
        return services;
    }

    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        services.AddSingleton<IUserMapper, UserMapper>();
        services.AddSingleton<IUserTypeMapper, UserTypeMapper>();
        return services;
    }
}