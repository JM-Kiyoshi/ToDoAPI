using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Mappings;
using ToDoList.Application.Services;
using ToDoList.Application.Services.Interfaces;
using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Data.Context;
using ToDoList.Infra.Data.Repositories;

namespace ToDoList.Infra.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"])), ServiceLifetime.Transient);
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<IAssignmentListRepository, AssignmentListRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DomainToDtoMapping));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAssignmentService, AssignmentService>();
        services.AddScoped<IAssignmentListService, AssignmentListService>();
        return services;
    }
}