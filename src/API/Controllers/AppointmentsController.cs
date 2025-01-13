using Application.Dtos.Requests.Appointment;
using Application.Dtos.Requests.Doctor;
using Application.UseCases.medical.Appointment;
using Application.UseCases.medical.Doctor;
using Application.UseCases.medical.Patient;
using Domain.Entities.newEntities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly CreateAppointmentUseCase _createAppointmentUseCase;
        private readonly GetAppointmentsUseCase _getAppointmentsUseCase;
        private readonly GetAppointmentByIdUseCase _getAppointmentByIdUseCase;
        private readonly UpdateAppointmentUseCase _updateAppointmentUseCase;
        private readonly DeleteAppointmentUseCase _deleteAppointmentUseCase;
        private readonly GetDoctorByIdUseCase _getDoctorByIdUseCase;
        private readonly GetPatientByIdUseCase _getPatientByIdUseCase;


        public AppointmentsController(CreateAppointmentUseCase createAppointmentUseCase, GetAppointmentsUseCase getAppointmentsUseCase,
                                      GetAppointmentByIdUseCase getAppointmentByIdUseCase, UpdateAppointmentUseCase updateAppointmentUseCase,
                                      DeleteAppointmentUseCase deleteAppointmentUseCase, GetDoctorByIdUseCase getDoctorByIdUseCase, GetPatientByIdUseCase getPatientByIdUseCase)
        {
            _createAppointmentUseCase = createAppointmentUseCase;
            _getAppointmentsUseCase = getAppointmentsUseCase;
            _getAppointmentByIdUseCase = getAppointmentByIdUseCase;
            _updateAppointmentUseCase = updateAppointmentUseCase;
            _deleteAppointmentUseCase = deleteAppointmentUseCase;
            _getDoctorByIdUseCase = getDoctorByIdUseCase;
            _getPatientByIdUseCase = getPatientByIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto dto)
        {
            var patient = await _getPatientByIdUseCase.ExecuteAsync(dto.PatientId);
            var doctor = await _getDoctorByIdUseCase.ExecuteAsync(dto.DoctorId);

            if (patient == null || doctor == null)
            {
                return BadRequest("Paciente ou médico não encontrado.");
            }

            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                Date = dto.Date
            };

            await _createAppointmentUseCase.ExecuteAsync(appointment);
            return Ok(appointment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _getAppointmentsUseCase.ExecuteAsync();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var appointment = await _getAppointmentByIdUseCase.ExecuteAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] CreateAppointmentDto dto)
        {

        await _updateAppointmentUseCase.ExecuteAsync(new Appointment { Id = id , PatientId  = dto.PatientId, Date = dto.Date});
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _deleteAppointmentUseCase.ExecuteAsync(id);
            return NoContent();
        }
    }
}
