namespace SB.TOKEN.APPLICATION.Cores;
public static class DependencyInjection
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration) {

        services.AddScoped<ISecurityApplication, SecurityApplication>();

        services.Configure<JwtConfigurationDto>(opt => configuration.GetSection(JwtConfigurationDto.KEY).Bind(opt));

        return services;
    }
}
