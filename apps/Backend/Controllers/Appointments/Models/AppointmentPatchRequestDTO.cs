namespace Backend.Controllers.Appointments.Models;

public class AppointmentPatchRequestDTO{
    public DateTime? StartDateTime {get; set;} = null;
    public DateTime? EndDateTime {get; set;} = null;
    public string? Subject { get; set; } = null;
    public string? Message {get; set;} = null;
    
}