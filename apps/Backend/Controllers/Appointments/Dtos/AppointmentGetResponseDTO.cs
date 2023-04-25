namespace Backend.Controllers.Appointments.Dtos;
public class AppointmentGetResponseDTO {
    public string AppointmentId { get; set; } = string.Empty;
    public string CalendarId { get; set; } = string.Empty;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int DurationInMinutes {get; set;}
    public string Subject { get; set; } = string.Empty;
    public string Message {get; set;} = string.Empty;
    public string FromUserId {get; set;} = string.Empty;
    public List<ReceiverDTO> Receivers {get; set;} = new List<ReceiverDTO>();
}