using SharedCore.Domain.ValueObject;

namespace Appointments.Calendars.Domain;

public class RangeOfDate : ValueObject
{

    public DateTime StartDateTime {get; private set;}
    public DateTime EndDateTime {get; private set;}

    public RangeOfDate(DateTime startDateTime, DateTime endDateTime){
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

    public void SetNewRangeOfDate(DateTime startDateTime, DateTime endDateTime ){
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;

        }

}