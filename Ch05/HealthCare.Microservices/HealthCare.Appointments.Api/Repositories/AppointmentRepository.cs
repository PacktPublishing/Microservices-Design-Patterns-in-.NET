using HealthCare.Appointments.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Appointments.Api.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentsDbContext _context;

        public AppointmentRepository(AppointmentsDbContext context)
        {
            this._context = context;
        }
        public async Task<Appointment> Add(Appointment appointment)
        {
            await _context.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task Delete(string id)
        {
            var appointment = await Get(id);
            _context.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public Task<bool> Exists(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Appointment> Get(string id)
        {
            var appointment = await _context.FindAsync<Appointment>(id);
            return appointment;
        }

        public Task<List<Appointment>> GetAll()
        {
            var appointments = _context.Appointments.ToListAsync();
            return appointments;
        }

        public async Task Update(Appointment appointment)
        {
            _context.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }

}