using Appointments.Domain;

namespace Appointments.Application{
    
    public class AppointmentUpdater
    {
        private IAppointmentRepository _repository;

        public AppointmentUpdater(IAppointmentRepository repository){
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Update(Guid appointmentID, DateTime startDateTime, DateTime endDateTime, int duration, string message, Guid fromUserID){
            
            if (!await _repository.AppointmentExists(appointmentID))
                return false;
            
            await _repository.Update(new Appointment(
                appointmentID,startDateTime,endDateTime, duration, message, fromUserID
            ));
            return true;
        }

        public async Task<bool> PartialUpdate(Guid appointmentID, DateTime? startDateTime, DateTime? endDateTime, int? duration, string? message, Guid? fromUserID){
            
            var appointment = await _repository.SearchByID(appointmentID);
            
            if (appointment == null)
                return false;

            appointment.StartDateTime = startDateTime ?? appointment.StartDateTime;
            appointment.EndDateTime = endDateTime ?? appointment.EndDateTime;
            appointment.DurationInMinutes = duration ?? appointment.DurationInMinutes;
            appointment.Message = message ?? appointment.Message;
            appointment.FromUserId = fromUserID ?? appointment.FromUserId;

            await _repository.Update(appointment);

            return true;
        }

    }

}