namespace Backend.Appointments.Models;

public class AppointmentGetResponseDTO{
    public string AppointmentID {get; set;} = string.Empty;
    public DateTime StartDateTime {get; set;}
    public DateTime EndDateTime {get; set;}
    public int DurationInMinutes {get; set;}
    public string Message {get; set;} = string.Empty;
    public string FromUserId {get; set;} = string.Empty;
}