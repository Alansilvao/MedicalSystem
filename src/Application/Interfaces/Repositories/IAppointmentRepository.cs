using Domain.Entities.newEntities;

namespace Application.Interfaces.Repositories;

public interface IAppointmentRepository
{
    Task<Appointment> GetByIdAsync(int id);
    Task<IEnumerable<Appointment>> GetAllAsync();
    Task AddAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task DeleteAsync(int id);
}