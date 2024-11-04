namespace SB.Entity.Infrastructure.Cores;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        string conexion = configuration["ConnectionStrings:DefaultConnection"]!;

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySQL(conexion);
        });

        services.AddScoped<IEntityRepository, EntityRepository>();

        return services;
    }
}
