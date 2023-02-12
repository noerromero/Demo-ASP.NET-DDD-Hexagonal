
namespace Appointments.Calendars.Domain
{
    public interface IAppointmentRepository
    {
        Task Create(Appointment appointment);
        Task<IEnumerable<Appointment>> SearchAll();
        //Task<IEnumerable<BackofficeCourse>> Matching(Criteria criteria);
        Task<Appointment?> SearchByID(Guid appointmentID);
        Task Update(Appointment appointment);
        Task Delete(Appointment appointment);
        Task<bool> AppointmentExists(Guid appointmentID);
    }
}