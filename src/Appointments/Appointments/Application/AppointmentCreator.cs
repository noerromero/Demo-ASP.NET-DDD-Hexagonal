using Appointments.Domain;

namespace Appointments.Application{
    
    public class AppointmentCreator{
        
        private IAppointmentRepository _repository;
        public AppointmentCreator(IAppointmentRepository repository){
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Create(Guid appointmentID, DateTime startDateTime, DateTime endDateTime, int duration, string message){
            await _repository.Create(new Appointment(appointmentID, startDateTime,endDateTime,duration,message));
        }


    }
}

