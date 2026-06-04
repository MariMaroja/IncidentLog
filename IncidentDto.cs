using IncidentLog.Enums;

namespace IncidentLog.DTOs.Incident
{
    public class IncidentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IncidentCategory Category { get; set; } = IncidentCategory.Unknown;
        public IncidentSeverity Severity { get; set; } = IncidentSeverity.Low;
        public IncidentStatus Status { get; set; } = IncidentStatus.Open;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
    }
}