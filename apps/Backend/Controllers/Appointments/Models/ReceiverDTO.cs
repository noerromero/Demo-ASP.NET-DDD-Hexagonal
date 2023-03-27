namespace Backend.Controllers.Appointments.Models;

public class ReceiverDTO{
    public Guid ReceiverId {get; set;} 
    public Guid AppointmentId {get; set;} 
    public Guid ToUserId {get; set;} 
}