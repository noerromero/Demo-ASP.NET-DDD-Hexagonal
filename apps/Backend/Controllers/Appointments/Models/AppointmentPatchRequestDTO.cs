namespace Backend.Appointments.Models;

public class AppointmentPatchRequestDTO{
    public DateTimeOffset? StartDateTime {get; set;} = null;
    public DateTimeOffset? EndDateTime {get; set;} = null;
    public string? Message {get; set;} = null;
    
}