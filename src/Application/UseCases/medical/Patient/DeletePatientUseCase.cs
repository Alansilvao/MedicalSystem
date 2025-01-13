using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Patient
{
    public class DeletePatientUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public DeletePatientUseCase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
        }
    }
}
