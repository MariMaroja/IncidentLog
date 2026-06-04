namespace IncidentLog.Models;

public class Evidence
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string FileUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid IncidentId { get; set; }
    public Incident Incident { get; set; } = null!;
}