using SharedCore.Domain.Entity;
using SharedCore.Domain.Aggregate;

namespace Appointments.Calendars.Domain{
    public class Calendar : BaseEntity<Guid> , IAggregateRoot
    {
        public Guid UserId {get; private set;}

        //public List<Appointment> AppointmentList {get; private set;}

        public Calendar(Guid id, Guid userId){
            Id = id;
            UserId = userId;
            //AppointmentList = new List<Appointment>();
        }

        public Calendar(Guid id, Guid userId, IEnumerable<Appointment> appointments){
            Id = id;
            UserId = userId;
            //AppointmentList = appointments !=null ? appointments.ToList() : throw new ArgumentNullException(nameof(appointments));
        }

        public void AddAppointments(Appointment appointment){
            //AppointmentList.Add(appointment);
        }

        public void AddRangeAppointments(IEnumerable<Appointment> rangeAppointments)
        {
            //AppointmentList.AddRange(rangeAppointments);
        }


    }
}

