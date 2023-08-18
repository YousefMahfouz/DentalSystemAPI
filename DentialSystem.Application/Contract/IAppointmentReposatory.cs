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
        bool HasAppointmentAtSameTime(Appointment appointment);
        bool IsDayFull(DateOnly date);
        bool HasPatientWithRank(Appointment appointment);
       

    }
}
