using SharedCore.Domain.Entity;

namespace HelperServices.Calendars.Domain;

public class Receiver : BaseEntity<Guid>
{
    public Guid ToUserId {get; private set;}

    public Guid AppointmentId {get; private set;}

    private Receiver(){}
    public Receiver(Guid id, Guid toUserId, Guid appointmentId){
        Id = id;
        ToUserId = toUserId;
        AppointmentId = appointmentId;
    }
}