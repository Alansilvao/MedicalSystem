using Application.Dtos.Requests.Patient;
using Application.UseCases.medical.Patient;
using Domain.Entities.newEntities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly CreatePatientUseCase _createPatientUseCase;
        private readonly GetPatientsUseCase _getPatientsUseCase;
        private readonly GetPatientByIdUseCase _getPatientByIdUseCase;
        private readonly UpdatePatientUseCase _updatePatientUseCase;
        private readonly DeletePatientUseCase _deletePatientUseCase;

        public PatientsController(CreatePatientUseCase createPatientUseCase, GetPatientsUseCase getPatientsUseCase,
                                  GetPatientByIdUseCase getPatientByIdUseCase, UpdatePatientUseCase updatePatientUseCase,
                                  DeletePatientUseCase deletePatientUseCase)
        {
            _createPatientUseCase = createPatientUseCase;
            _getPatientsUseCase = getPatientsUseCase;
            _getPatientByIdUseCase = getPatientByIdUseCase;
            _updatePatientUseCase = updatePatientUseCase;
            _deletePatientUseCase = deletePatientUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientDto dto)
        {
            await _createPatientUseCase.ExecuteAsync(new Patient { Email = dto.Email, Name = dto.Name });
            return Ok(dto);
        }


        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _getPatientsUseCase.ExecuteAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _getPatientByIdUseCase.ExecuteAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDto dto)
        {
            await _updatePatientUseCase.ExecuteAsync(new Patient { Id = id, Email = dto.Email, Name = dto.Name });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _deletePatientUseCase.ExecuteAsync(id);
            return NoContent();
        }
    }


}
