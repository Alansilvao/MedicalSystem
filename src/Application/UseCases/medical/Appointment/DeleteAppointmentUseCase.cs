using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Appointment
{
    public class DeleteAppointmentUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteAppointmentUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
        }
    }

}
