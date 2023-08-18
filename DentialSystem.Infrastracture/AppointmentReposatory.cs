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
    public class AppointmentReposatory : Reposatory<Appointment,int>,IAppointmentReposatory
    {
        public AppointmentReposatory(ApplicationContext context) : base(context)
        {
        }
        private readonly List<Appointment> _appointments = new List<Appointment>();

        public bool HasAppointmentAtSameTime(Appointment appointment)
        {
            return _appointments.Any(a =>
                a.date == appointment.date && a.time == appointment.time && a.Id != appointment.Id);
        }

        public bool IsDayFull(DateOnly date)
        {
            int maxAppointmentsPerDay = 8;

            return _appointments.Count(a => a.date == date) >= maxAppointmentsPerDay;
        }

        public bool HasPatientWithRank(Appointment appointment)
        {
            return _appointments.Any(a =>
                a.PaitantId == appointment.PaitantId && a.date == appointment.date && a.Id != appointment.Id);
        }

       

    } 
}
