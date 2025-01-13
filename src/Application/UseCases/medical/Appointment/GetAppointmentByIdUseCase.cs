using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Appointment
{
    public class GetAppointmentByIdUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentByIdUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Domain.Entities.newEntities.Appointment> ExecuteAsync(int id)
        {
            return await _appointmentRepository.GetByIdAsync(id);
        }
    }

}
