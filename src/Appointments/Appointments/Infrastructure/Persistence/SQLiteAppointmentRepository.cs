using Appointments.Domain;
using Appointments.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Infrastructure.Persistence
{
    public class SQLiteAppointmentRepository: IAppointmentRepository 
    {
        private AppointmentsContext _context;

        public SQLiteAppointmentRepository(AppointmentsContext context){
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> SearchAll()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment?> SearchByID(Guid appointmentID){
            //return await _context.Appointments.FindAsync(appointmentID.ToString());
            var appointment = await _context.Appointments
                            .FirstOrDefaultAsync(x => x.AppointmentID == appointmentID);
            
            return appointment;
        }

        public async Task Update(Appointment appointment){
            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Appointment appointment){
            //var appointment = await _context.Appointments.FirstAsync(x => x.AppointmentID == appointmentID);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AppointmentExists(Guid appointmentID) {
            return await _context.Appointments.AnyAsync(x => x.AppointmentID == appointmentID);
        } 
        

        
    }
}