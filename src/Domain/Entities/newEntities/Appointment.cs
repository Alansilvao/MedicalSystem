namespace Domain.Entities.newEntities;
public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
    public bool IsCanceled { get; set; } = false;
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}
