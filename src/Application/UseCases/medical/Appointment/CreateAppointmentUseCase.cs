using Application.Interfaces.Repositories;
using Application.Interfaces.Service;

namespace Application.UseCases.medical.Appointment
{
    public class CreateAppointmentUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEmailService _emailService;
        public CreateAppointmentUseCase(IAppointmentRepository appointmentRepository, IEmailService emailService)
        {
            _appointmentRepository = appointmentRepository;
            _emailService = emailService;
        }

        public async Task ExecuteAsync(Domain.Entities.newEntities.Appointment appointment)
        {
            await _appointmentRepository.AddAsync(appointment);

            var subject = "Lembrete de Consulta Médica"; 
            var body = $"Olá {appointment.Patient.Name}, você tem uma consulta agendada com o Dr(a). {appointment.Doctor.Name} no dia {appointment.Date}."; 
            await _emailService.SendEmailAsync(appointment.Patient.Email, subject, body);
        }
    }

}
