using Application.Interfaces.Repositories;
using Domain.Entities.newEntities;
using Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.Where(a => !a.IsCanceled).ToListAsync();
        }

        public async Task<Appointment> GetAppointmentByDoctorAndDateAsync(int doctorId, DateTime date)
        {
            return await _context.Appointments.FirstOrDefaultAsync(a => !a.IsCanceled && a.DoctorId == doctorId &&
                                  a.Date >= date.AddHours(-1) &&
                                  a.Date <= date.AddHours(1));
        }

        public async Task AddAsync(Appointment appointment)
        {
            var existingAppointment = await GetAppointmentByDoctorAndDateAsync(appointment.DoctorId, appointment.Date);
            if (existingAppointment != null)
            {
                throw new InvalidOperationException("Já existe uma consulta agendada para esse doutor nesse horário.");
            }

            _context.Appointments.Add(appointment); await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                appointment.IsCanceled = true;
                _context.Appointments.Update(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }

}
