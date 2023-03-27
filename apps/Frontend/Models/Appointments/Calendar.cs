namespace Frontend.Models.Appointments;

public class Calendar{
    public Guid CalendarId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}