using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Doctor
{
    public class GetDoctorByIdUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorByIdUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Domain.Entities.newEntities.Doctor> ExecuteAsync(int id)
        {
            return await _doctorRepository.GetByIdAsync(id);
        }
    }

}
