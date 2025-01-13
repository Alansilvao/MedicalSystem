using System.Diagnostics.CodeAnalysis;
using Application.Interfaces.Repositories;
using Application.Interfaces.Service;
using Infra.Database.Context;
using Infra.Database.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

[ExcludeFromCodeCoverage]
public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepositories();
        services.AddServices();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServer");

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IAppointmentRepository, AppointmentRepository>()
            .AddScoped<IDoctorRepository, DoctorRepository>()
            .AddScoped<IPatientRepository, PatientRepository>();
    }
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
    }
}
