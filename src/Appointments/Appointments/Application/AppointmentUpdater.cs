using Appointments.Domain;

namespace Appointments.Application{
    
    public class AppointmentUpdater
    {
        private IAppointmentRepository _repository;

        public AppointmentUpdater(IAppointmentRepository repository){
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Update(Guid appointmentID, DateTime startDateTime, DateTime endDateTime, int duration, string message, Guid fromUserID){
            
            //var appointment = _repository.SearchByID(appointmentID);
            //if (appointment == null)
            //    return false;
            
            await _repository.Update(new Appointment(
                appointmentID,startDateTime,endDateTime, duration, message, fromUserID
            ));
            return true;
        }
    }

}