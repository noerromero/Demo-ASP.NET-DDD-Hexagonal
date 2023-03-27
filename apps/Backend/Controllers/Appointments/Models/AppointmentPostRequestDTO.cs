namespace Backend.Controllers.Appointments.Models;

public class AppointmentPostRequestDTO{
    public Guid AppointmentId {get; set;}
    public DateTime StartDateTime {get; set;}
    public DateTime EndDateTime {get; set;}
    public string Subject { get; set; } = string.Empty;
    public string Message {get; set;} = string.Empty;
    public string FromUserId {get; set;} = string.Empty;
    public List<ReceiverDTO> Receivers {get; set;} = new List<ReceiverDTO>();

}

