using SharedCore.Domain.Entity;
using SharedCore.Domain.Aggregate;

namespace Appointments.Calendars.Domain{
    public class Calendar : BaseEntity<Guid> , IAggregateRoot
    {
        public Guid UserId {get; private set;}

        public string Name {get; private set;}

        private Calendar(){}

        public Calendar(Guid id, Guid userId, string name){
            Id = id;
            UserId = userId;
            Name = name;
            
        }


    }
}

