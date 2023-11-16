using CQRS_MediatR_Demo.Data;
using CQRS_MediatR_Demo.Repositories.CommandRepo.Implementations.EntityRepo;
using CQRS_MediatR_Demo.Repositories.CommandRepo.Interface.IEntityRepo;
using CQRS_MediatR_Demo.Repositories.QueryRepo.Implementations.EntityRepo;
using CQRS_MediatR_Demo.Repositories.QueryRepo.Interface.IEntityRepo;
using MediatR;
using System.Reflection;

namespace CQRS_MediatR_Demo.Extensions;

public static class ServiceExtension
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>();
        services.AddScoped<IProductQueryRepo, ProductQueryRepo>();
        services.AddScoped<IProductRepoCommand, ProductCommandRepo>();
    }
}
