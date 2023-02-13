using Appointments.Calendars.Domain;
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
            throw new NotImplementedException();
            //await _context.Appointments.AddAsync(appointment);
            //await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> SearchAll()
        {
            throw new NotImplementedException();
            //return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment?> SearchByID(Guid appointmentID){
            
            throw new NotImplementedException();
            //var appointment = await _context.Appointments
            //                .FirstOrDefaultAsync(x => x.Id == appointmentID);
            
            //return appointment;
        }

        public async Task Update(Appointment appointment){
            throw new NotImplementedException();
            //_context.Entry(appointment).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }

        public async Task Delete(Appointment appointment){
            
            throw new NotImplementedException();
            //_context.Appointments.Remove(appointment);
            //await _context.SaveChangesAsync();
        }

        public async Task<bool> AppointmentExists(Guid appointmentID) {
            throw new NotImplementedException();
            //return await _context.Appointments.AnyAsync(x => x.Id == appointmentID);
        } 
        

        
    }
}