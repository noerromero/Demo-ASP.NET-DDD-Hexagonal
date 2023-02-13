using SharedCore.Domain.ValueObject;

namespace Appointments.Calendars.Domain;

public class RangeOfDate : ValueObject
{

    public DateTimeOffset StartDateTime {get; private set;}
    public DateTimeOffset EndDateTime {get; private set;}

    public RangeOfDate(DateTimeOffset startDateTime, DateTimeOffset endDateTime){
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
    }
    public int GetDurationInMinutes() {
        return (int)Math.Round((EndDateTime - StartDateTime).TotalMinutes,0);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
            yield return this;
    }

}