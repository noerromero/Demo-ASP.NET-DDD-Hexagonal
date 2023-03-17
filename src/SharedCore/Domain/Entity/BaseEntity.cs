namespace SharedCore.Domain.Entity{
    public abstract class BaseEntity<TId>{
        public TId Id {get; set;}

        //todo: eventList
    }    
}
