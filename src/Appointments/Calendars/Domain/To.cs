using SharedCore.Domain.Aggregate;

namespace Appointments.Calendars.Domain;

public class To : BaseEntity<Guid>
{
    public Guid ToUserId {get; private set;}

    public To(Guid id, Guid toUserId){
        Id = id;
        ToUserId = toUserId;
    }
}