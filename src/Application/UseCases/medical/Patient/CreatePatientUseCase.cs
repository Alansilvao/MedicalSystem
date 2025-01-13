using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Patient
{
    public class CreatePatientUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public CreatePatientUseCase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task ExecuteAsync(Domain.Entities.newEntities.Patient patient)
        {
            await _patientRepository.AddAsync(patient);
        }
    }
}
