using FrontOffice.Calendars.Domain;

namespace FrontOffice.Calendars.Application{
    
    public class AppointmentUpdater
    {
        private ICalendarRepository _repository;

        public AppointmentUpdater(ICalendarRepository repository){
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Update(
                              Guid appointmentId, Guid calendarId, DateTime startDateTime
                            , DateTime endDateTime, string subject, string message, Guid fromUserId
                            , IEnumerable<Receiver> receivers){
            
            if (! await _repository.CalendarExists(calendarId))
                return false;

            if (! await _repository.AppointmentExists(appointmentId))
                return false;
            
            await _repository.UpdateAppointment(new Appointment(
                                                appointmentId,calendarId,startDateTime,endDateTime,
                                                subject,message,fromUserId,receivers));
            
            return true;
            
            /* This code works without value object (RangeOfDate) into Appointment Entity
            if (!await _repository.AppointmentExists(appointmentId))
                return false;
            
            await _repository.UpdateAppointment(new Appointment(
                appointmentId,calendarId, startDateTime,endDateTime, message, fromUserId
            ));
            return true;
            */

            /*This code works without transaction scope (appointment and receivers)
            var appointment = await _repository.SearchAppointmentByID(appointmentId, false);
            if (appointment == null)
                return false;

            appointment.RangeOfDates.SetNewRangeOfDate( startDateTime ?? appointment.RangeOfDates.StartDateTime
                                    , endDateTime ?? appointment.RangeOfDates.EndDateTime);
            appointment.SetMessage( message ?? appointment.Message);
            appointment.SetCalendarId(calendarId ?? appointment.CalendarId);
            appointment.SetFromUserId(fromUserId ?? appointment.FromUserId);

            await _repository.UpdateAppointment(appointment);

            return true;
            */

        }

        
        public async Task<bool> PartialUpdate(Guid appointmentId, Guid calendarId, DateTime? startDateTime
                                , DateTime? endDateTime, string? subject, string? message){
            
            if (! await _repository.CalendarExists(calendarId))
                return false;

            var appointment = await _repository.SearchAppointmentByID(appointmentId,false);
            
            if (appointment == null)
                return false;

            appointment.RangeOfDates.SetNewRangeOfDate(startDateTime ?? appointment.RangeOfDates.StartDateTime
                                    , endDateTime ?? appointment.RangeOfDates.EndDateTime
            );
                
            appointment.SetMessage(message ?? appointment.Message);
            appointment.SetSubject(subject ?? appointment.Subject);
                
            await _repository.PartialUpdateAppointment(appointment);

            return true;
        }
          
    }

}