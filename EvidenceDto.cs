namespace IncidentLog.DTOs.Evidence;

public class EvidenceDto
{
    public Guid Id { get; set; }
    public string FileUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}