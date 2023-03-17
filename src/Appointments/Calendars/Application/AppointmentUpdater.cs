using Appointments.Calendars.Domain;

namespace Appointments.Calendars.Application{
    
    public class AppointmentUpdater
    {
        private ICalendarRepository _repository;

        public AppointmentUpdater(ICalendarRepository repository){
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Update(
                              Guid appointmentId
                            , Guid calendarId
                            , DateTimeOffset startDateTime
                            , DateTimeOffset endDateTime
                            , string message
                            , Guid fromUserID){
            
            if (!await _repository.AppointmentExists(appointmentId))
                return false;
            
            await _repository.UpdateAppointment(new Appointment(
                appointmentId,calendarId, startDateTime,endDateTime, message, fromUserID
            ));
            return true;
        }

        
        public async Task<bool> PartialUpdate(Guid appointmentID, DateTime? startDateTime, DateTime? endDateTime, string? message){
            
            var appointment = await _repository.SearchAppointmentByID(appointmentID);
            
            if (appointment == null)
                return false;

            appointment.RangeOfDates.SetNewRangeOfDate( startDateTime ?? appointment.RangeOfDates.StartDateTime
                                    , endDateTime ?? appointment.RangeOfDates.EndDateTime);
            
            appointment.SetMessage( message ?? appointment.Message);
            
            await _repository.UpdateAppointment(appointment);

            return true;
        }
          
    }

}