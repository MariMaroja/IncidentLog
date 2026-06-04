using IncidentLog.Enums;

namespace IncidentLog.DTOs.Incident;

public class IncidentFilterDto
{
    public IncidentStatus? Status { get; set; }
    public IncidentSeverity? Severity { get; set; }
    public IncidentCategory? Category { get; set; }
}