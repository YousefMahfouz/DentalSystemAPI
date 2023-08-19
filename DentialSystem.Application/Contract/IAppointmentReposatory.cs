using DentialSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Application.Contract
{
    public interface IAppointmentReposatory:IRepository<Appointment,int>
    {
        public Task< List<Appointment>> GetAppointmentsForDate(DateOnly date);
        public Task<List<Ranking> >GetUsedRankingsForDate(DateOnly date);

    }
}
