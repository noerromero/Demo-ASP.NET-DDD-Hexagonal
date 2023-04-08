namespace Frontend.Models.Calendars;
public class Appointment
{
    public Guid? AppointmentId { get; set; }
    public Guid CalendarId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int DurationInMinutes { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public Guid FromUserId { get; set; } 

    public IEnumerable<Receiver> receivers { get; set; } = new List<Receiver>();

    
}