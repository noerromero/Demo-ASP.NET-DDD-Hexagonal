namespace Appointments.Calendars.Domain;

public interface ICalendarRepository 
{
    Task Create(Appointment appointment);
    Task<IEnumerable<Calendar>> SearchByUserId(Guid userId);
    Task<Calendar?> SearchById(Guid id);
    Task Delete(Appointment appointment);
    Task<bool> CalendarExists(Guid appointmentID);
}