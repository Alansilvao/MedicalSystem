using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Patient
{

    public class GetPatientsUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientsUseCase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Domain.Entities.newEntities.Patient>> ExecuteAsync()
        {
            return await _patientRepository.GetAllAsync();
        }
    }
}
