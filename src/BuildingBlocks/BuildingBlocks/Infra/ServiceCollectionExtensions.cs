using BuildingBlocks.Infra.Options;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Infra;
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registra un DbContext con SQL Server leyendo ConnectionStrings:Default,
    /// o la clave que pases por parámetro.
    /// </summary>
    public static IServiceCollection AddSqlServerDbContext<TContext>(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionStringKey = "ConnectionStrings:Default")
        where TContext : DbContext
    {
        var cs = configuration[connectionStringKey];
        if (string.IsNullOrWhiteSpace(cs))
            throw new InvalidOperationException($"Connection string '{connectionStringKey}' no configurada.");

        services.Configure<SqlOptions>(o => o.ConnectionString = cs);

        services.AddDbContext<TContext>(opt =>
        {
            opt.UseSqlServer(cs);
        });

        return services;
    }
    /// <summary>
    /// Aplica migraciones pendientes al arrancar la app.
    /// </summary>
    public static async Task ApplyMigrationsAsync<TContext>(this IServiceProvider sp)
        where TContext : DbContext
    {
        using var scope = sp.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<TContext>();
        await db.Database.MigrateAsync();
    }
}

public static class MassTransitExtensions
{
    /// <summary>
    /// Configura MassTransit con RabbitMQ y nombra endpoints con un prefijo por servicio.
    /// </summary>
    public static IServiceCollection AddRabbitMqMassTransit(
        this IServiceCollection services,
        IConfiguration configuration,
        string endpointPrefix,
        Action<IBusRegistrationConfigurator>? registerConsumers = null)
    {
        services.Configure<RabbitMqOptions>(opts =>
        {
            configuration.GetSection("RabbitMq").Bind(opts);

        });

        services.Configure<RabbitMqOptions>(opts =>
        {
            configuration.GetSection("RabbitMq").Bind(opts);
        });

        services.AddMassTransit(x =>
        {
            registerConsumers?.Invoke(x);

            x.UsingRabbitMq((ctx, cfg) =>
            {
                var opts = configuration.GetSection("RabbitMq").Get<RabbitMqOptions>() ?? new();
                cfg.Host(opts.Host, opts.VirtualHost, h =>
                {
                    h.Username(opts.Username);
                    h.Password(opts.Password);
                });

                cfg.ConfigureEndpoints(
                    ctx,
                    new KebabCaseEndpointNameFormatter(prefix: endpointPrefix, includeNamespace: false));
            });
        });

        return services;
    }
}

