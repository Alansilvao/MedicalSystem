using Domain.Entities.newEntities;

namespace Application.Interfaces.Repositories;

public interface IPatientRepository
{
    Task<Patient> GetByIdAsync(int id);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task AddAsync(Patient patient);
    Task UpdateAsync(Patient patient);
    Task DeleteAsync(int id);
    Task<IEnumerable<Patient>> GetPatientsWithAppointmentsInNext24HoursAsync();
}