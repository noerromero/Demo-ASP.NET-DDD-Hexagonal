using SharedCore.Domain.Entity;

namespace Appointments.Calendars.Domain;

public class Receiver : BaseEntity<Guid>
{
    public Guid ToUserId {get; private set;}

    public Receiver(Guid id, Guid toUserId){
        Id = id;
        ToUserId = toUserId;
    }
}