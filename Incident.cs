using IncidentLog.Enums;

namespace IncidentLog.Models
{
    public class Incident
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IncidentCategory Category { get; set; } = IncidentCategory.Unknown;
        public IncidentSeverity Severity { get; set; } = IncidentSeverity.Low;
        public IncidentStatus Status { get; set; } = IncidentStatus.Open;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public List<Comment> Comments { get; set; } = new();
        public List<Evidence> Evidence { get; set; } = new();
    }
}