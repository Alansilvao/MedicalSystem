using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Doctor
{
    public class GetDoctorsUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorsUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Domain.Entities.newEntities.Doctor>> ExecuteAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }
    }

}
