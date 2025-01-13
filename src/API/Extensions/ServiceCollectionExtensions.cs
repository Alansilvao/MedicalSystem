using System.Diagnostics.CodeAnalysis;
using Application.UseCases.medical.Appointment;
using Application.UseCases.medical.Doctor;
using Application.UseCases.medical.Patient;

namespace API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
	public static void AddUseCases(this IServiceCollection services)
	{
        services.AddScoped<CreatePatientUseCase>();
        services.AddScoped<GetPatientsUseCase>();
        services.AddScoped<GetPatientByIdUseCase>();
        services.AddScoped<UpdatePatientUseCase>();
        services.AddScoped<DeletePatientUseCase>();

        services.AddScoped<CreateDoctorUseCase>();
        services.AddScoped<GetDoctorsUseCase>();
        services.AddScoped<GetDoctorByIdUseCase>();
        services.AddScoped<UpdateDoctorUseCase>();
        services.AddScoped<DeleteDoctorUseCase>();

        services.AddScoped<CreateAppointmentUseCase>();
        services.AddScoped<GetAppointmentsUseCase>();
        services.AddScoped<GetAppointmentByIdUseCase>();
        services.AddScoped<UpdateAppointmentUseCase>();
        services.AddScoped<DeleteAppointmentUseCase>();
    }
}
