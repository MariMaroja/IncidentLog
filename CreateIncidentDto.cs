using IncidentLog.Enums;

namespace IncidentLog.DTOs.Incident
{
    public class CreateIncidentDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IncidentCategory Category { get; set; } = IncidentCategory.Unknown;
        public IncidentSeverity Severity { get; set; } = IncidentSeverity.Low;
    }
}