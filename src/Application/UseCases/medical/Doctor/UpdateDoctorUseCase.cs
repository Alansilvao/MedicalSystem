using Application.Interfaces.Repositories;
using Domain.Entities.newEntities;

namespace Application.UseCases.medical.Doctor
{
    public class UpdateDoctorUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public UpdateDoctorUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task ExecuteAsync(Domain.Entities.newEntities.Doctor doctor)
        {
            await _doctorRepository.UpdateAsync(doctor);
        }
    }

}
