namespace Backend.Appointments.Models;

public class AppointmentGetResponseDTO{
    public string AppointmentId {get; set;} = string.Empty;
    public string CalendarId {get; set;} = string.Empty;
    public DateTimeOffset StartDateTime {get; set;}
    public DateTimeOffset EndDateTime {get; set;}
    public int DurationInMinutes {get; set;}
    public string Message {get; set;} = string.Empty;
    public string FromUserId {get; set;} = string.Empty;
}