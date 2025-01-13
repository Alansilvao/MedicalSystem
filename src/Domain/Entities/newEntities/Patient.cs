namespace Domain.Entities.newEntities;
public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; } = false;
}

