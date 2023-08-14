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
        public AppointmentReposatory(ApplicationContext context) : base(context)
        {
        }
    }
}
