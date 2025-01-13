using Application.Interfaces.Repositories;
using Domain.Entities.newEntities;
using Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Database.Repositories;

[ExcludeFromCodeCoverage]
public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Patient> GetByIdAsync(int id)
    {
        return await _context.Patients.FindAsync(id);
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _context.Patients.Where(p => !p.IsDeleted).ToListAsync();
    }

    public async Task AddAsync(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient != null)
        {
            patient.IsDeleted = true;
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<Patient>> GetPatientsWithAppointmentsInNext24HoursAsync()
    {
        return await _context.Patients
            .Join(_context.Appointments,
                  p => p.Id,
                  a => a.PatientId,
                  (p, a) => new { Patient = p, Appointment = a })
            .Where(pa => pa.Appointment.Date >= DateTime.Now && pa.Appointment.Date <= DateTime.Now.AddHours(24) && !pa.Appointment.IsCanceled)
            .Select(pa => pa.Patient)
            .ToListAsync();
    }

}
