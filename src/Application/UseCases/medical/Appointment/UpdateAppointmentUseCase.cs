using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Appointment
{
    public class UpdateAppointmentUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public UpdateAppointmentUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task ExecuteAsync(Domain.Entities.newEntities.Appointment appointment)
        {
            await _appointmentRepository.UpdateAsync(appointment);
        }
    }

}
