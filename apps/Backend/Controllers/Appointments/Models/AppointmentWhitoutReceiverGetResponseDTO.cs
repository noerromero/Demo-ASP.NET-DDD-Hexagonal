namespace Backend.Controllers.Appointments.Models;
public class AppointmentWhitoutReceiverGetResponseDTO{
    public string AppointmentId {get; set;} = string.Empty;
    public string CalendarId {get; set;} = string.Empty;
    public DateTime StartDateTime {get; set;}
    public DateTime EndDateTime {get; set;}
    public int DurationInMinutes {get; set;}
    public string Subject { get; set; } = string.Empty;
    public string Message {get; set;} = string.Empty;
    public string FromUserId {get; set;} = string.Empty;
    
}