using Application.Dtos.Requests.Doctor;
using Application.UseCases.medical.Doctor;
using Domain.Entities.newEntities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly CreateDoctorUseCase _createDoctorUseCase;
        private readonly GetDoctorsUseCase _getDoctorsUseCase;
        private readonly GetDoctorByIdUseCase _getDoctorByIdUseCase;
        private readonly UpdateDoctorUseCase _updateDoctorUseCase;
        private readonly DeleteDoctorUseCase _deleteDoctorUseCase;

        public DoctorsController(CreateDoctorUseCase createDoctorUseCase, GetDoctorsUseCase getDoctorsUseCase,
                                 GetDoctorByIdUseCase getDoctorByIdUseCase, UpdateDoctorUseCase updateDoctorUseCase,
                                 DeleteDoctorUseCase deleteDoctorUseCase)
        {
            _createDoctorUseCase = createDoctorUseCase;
            _getDoctorsUseCase = getDoctorsUseCase;
            _getDoctorByIdUseCase = getDoctorByIdUseCase;
            _updateDoctorUseCase = updateDoctorUseCase;
            _deleteDoctorUseCase = deleteDoctorUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] Doctor doctor)
        {
            await _createDoctorUseCase.ExecuteAsync(doctor);
            return Ok(doctor);
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _getDoctorsUseCase.ExecuteAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _getDoctorByIdUseCase.ExecuteAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorDto dto)
        {
            await _updateDoctorUseCase.ExecuteAsync(new Doctor {Id = id, Name = dto.Name, Specialty = dto.Specialty });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _deleteDoctorUseCase.ExecuteAsync(id);
            return NoContent();
        }
    }

}
