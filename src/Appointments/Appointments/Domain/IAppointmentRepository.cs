namespace Appointments.Domain
{
    public interface IAppointmentRepository
    {
        Task Create(Appointment appointment);
        Task<IEnumerable<Appointment>> SearchAll();
        //Task<IEnumerable<BackofficeCourse>> Matching(Criteria criteria);
    }
}