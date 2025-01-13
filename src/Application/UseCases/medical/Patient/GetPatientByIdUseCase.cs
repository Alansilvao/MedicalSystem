using Application.Interfaces.Repositories;

namespace Application.UseCases.medical.Patient
{
    public class GetPatientByIdUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByIdUseCase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Domain.Entities.newEntities.Patient> ExecuteAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }
    }
}
