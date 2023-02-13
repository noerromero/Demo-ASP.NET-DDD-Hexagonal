namespace SharedCore.Domain.Aggregate{
    public abstract class BaseEntity<TId>{
        public TId Id {get; set;}

        //todo: eventList
    }    
}
