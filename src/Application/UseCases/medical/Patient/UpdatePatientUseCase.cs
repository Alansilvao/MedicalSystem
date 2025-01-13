using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Patient
{
    public class UpdatePatientUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public UpdatePatientUseCase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task ExecuteAsync(Domain.Entities.newEntities.Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
        }
    }
}
