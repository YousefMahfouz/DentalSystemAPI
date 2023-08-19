using DentialSystem.Application.Contract;
using DentialSystem.Context;
using DentialSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Infrastracture
{
    public class AppointmentReposatory : Reposatory<Appointment,int>,IAppointmentReposatory
    {
        private readonly ApplicationContext _context;

        public AppointmentReposatory(ApplicationContext context) : base(context)
        {
            _context = context;
        }
          
        public async Task< bool> HasAppointmentAtSameTime( DateOnly date,TimeOnly time )
        {
            var sametime = await _context.Appointments.FirstOrDefaultAsync(a =>
                 a.date == date && a.time == time);
            if (sametime != null)
            {
                return  true;
            }
            return false;
        }

        public async Task< bool> IsDayFull(DateOnly date)
        {
            int maxAppointmentsPerDay = 8;

           // var count = await  _context.Appointments.CountAsync(a => a.date == date);
            
                if ((await GetRanking( date) >= maxAppointmentsPerDay))
                {
                   return true;
                }
                return false; 
            
           
        }

        public async Task< bool> HasPatientWithRank(string patiantId, DateOnly day)
        {
            var withrank= await _context.Appointments.FirstOrDefaultAsync(a =>
                a.PaitantId == patiantId && a.date==day);
            if (withrank != null) { 
                return true;
            }
            return false;
        }

        public async Task<int> GetRanking(DateOnly date)
        {
            var lastAppointment = await _context.Appointments
           .Where(a => a.date == date) // Replace with your condition
           .OrderByDescending(a => a.Id) // Assuming you have a DateTime property for the appointment date
           .FirstOrDefaultAsync();
            if(lastAppointment != null) { 
            return (int)lastAppointment.ranking;}
            else { return 0; }  
        }

        public async Task<Appointment> GetByIdAsync(string paitantId)
        {
            return await _context.Appointments.FirstOrDefaultAsync(p => p.PaitantId == paitantId && p.IsCompleted==false);
        }

        public async Task<List<Appointment>> GetALLAppointmentAsync(string paitantId)
        {
           return  await( _context.Appointments.Where(p => p.PaitantId == paitantId).ToListAsync());
            
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                    int ranking = (int)appointment.ranking;
                    var appointments = await (_context.Appointments.Where(a => a.date == appointment.date && a.ranking > (Ranking)ranking).ToListAsync());
                    foreach (var item in appointments)
                    {
                        int rankingItem = (int)item.ranking - 1;
                        item.ranking = (Ranking)rankingItem;
                        _context.Appointments.Update(item);
                        await _context.SaveChangesAsync();
                    }
                    return true;
               
            }
            return false;
        }
    } 
}
