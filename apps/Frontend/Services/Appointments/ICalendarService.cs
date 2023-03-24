using Models.Appointments;

namespace Services.Appointments;
public interface ICalendarService{
    Task<IEnumerable<Calendar>> GetCalendarByUserId (Guid userId);
    Task<IList<Appointment>> GetAppointmentsByCalendarId(Guid calendarId);

}