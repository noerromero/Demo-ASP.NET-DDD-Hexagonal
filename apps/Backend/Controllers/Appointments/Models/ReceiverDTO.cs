namespace Backend.Controllers.Appointments.Models;

public class ReceiverDTO{
    public string ReceiverId {get; set;} = string.Empty;
    public string AppointmentId {get; set;} = string.Empty;
    public string ToUserId {get; set;} =string.Empty;
}