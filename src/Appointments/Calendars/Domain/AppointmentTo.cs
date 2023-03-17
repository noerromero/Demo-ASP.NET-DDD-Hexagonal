using SharedCore.Domain.Entity;

namespace Appointments.Calendars.Domain;

public class AppointmentTo : BaseEntity<Guid>
{
    public Guid ToUserId {get; private set;}

    public AppointmentTo(Guid id, Guid toUserId){
        Id = id;
        ToUserId = toUserId;
    }
}