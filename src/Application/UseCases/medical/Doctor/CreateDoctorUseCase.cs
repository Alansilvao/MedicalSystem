using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Doctor
{
    public class CreateDoctorUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public CreateDoctorUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task ExecuteAsync(Domain.Entities.newEntities.Doctor doctor)
        {
            await _doctorRepository.AddAsync(doctor);
        }
    }

}
