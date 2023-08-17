using DentialSystem.Application.Contract;
using DentialSystem.Context;
using DentialSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Infrastracture
{
    public class AppointmentReposatory : Reposatory<Appointment, int>,IAppointmentReposatory
    {
        private readonly List<Appointment> _appointments = new List<Appointment>();
        public AppointmentReposatory(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<Appointment>> GetAppointmentsForDate(DateOnly date)
        {
            return  _appointments.Where(a => a.date == date).ToList();
        }
        public async Task< List<Ranking> >GetUsedRankingsForDate(DateOnly date)
        {
            return await Task.Run(() =>
            {
                return _appointments
                    .Where(a => a.date == date)
                    .Select(a => a.ranking)
                    .ToList();
            });
        }

       
    }
}
