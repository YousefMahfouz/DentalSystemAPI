using DentialSystem.Domain;
using DentialSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Application.Services.AppointmentService
{
    public interface IAppointmentServices
    {
       public Task<AppointmentDTO> CreateAppointment(AppointmentDTO appointmentDto);
        public Task<AppointmentDTO> UpdateAppointment(int id, AppointmentDTO appointment);
        public Task<AppointmentDTO> GetByIdAsync(string paitantId);
       public Task< bool> DeleteAppointment(int id);
        public Task<List<AppointmentDTO>> GetAll(string paitantId);

    }
}
