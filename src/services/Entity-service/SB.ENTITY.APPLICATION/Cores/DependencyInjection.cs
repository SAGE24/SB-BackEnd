namespace SB.Entity.Application.Cores;
public static class DependencyInjection
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IEntityApplication, EntityApplication>();

        services.AddInfrastructureService(configuration);

        return services;
    }
}
