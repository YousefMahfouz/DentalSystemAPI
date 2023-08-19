using DentialSystem.Domain;
using DentialSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Application.Contract
{
    public interface IAppointmentReposatory:IRepository<Appointment,int>
    {
       public Task<  bool> HasAppointmentAtSameTime(DateOnly date, TimeOnly time);

        public Task<bool> IsDayFull(DateOnly date);
        public Task<bool> HasPatientWithRank(string patiantId, DateOnly day);
       
        public Task<int> GetRanking(DateOnly date);
        public Task<Appointment> GetByIdAsync(string paitantId);
        public Task<List<Appointment>> GetALLAppointmentAsync(string paitantId);
        public Task<bool> DeleteAppointment(int id);


    }
}
