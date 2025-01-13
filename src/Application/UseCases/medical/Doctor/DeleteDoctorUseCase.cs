using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Doctor
{
    public class DeleteDoctorUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DeleteDoctorUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);
        }
    }

}
