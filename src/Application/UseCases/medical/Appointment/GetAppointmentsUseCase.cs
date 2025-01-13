using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Appointment
{
    public class GetAppointmentsUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentsUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Domain.Entities.newEntities.Appointment>> ExecuteAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }
    }

}
