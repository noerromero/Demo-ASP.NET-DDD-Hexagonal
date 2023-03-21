namespace Backend.Controllers.Appointments.Models;

public class AppointmentPostRequestDTO{
    public string AppointmentId {get; set;} = string.Empty;
    public DateTimeOffset StartDateTime {get; set;}
    public DateTimeOffset EndDateTime {get; set;}
    public string Message {get; set;} = string.Empty;
    public string FromUserId {get; set;} = string.Empty;
    public List<ReceiverDTO> Receivers {get; set;} = new List<ReceiverDTO>();

}

