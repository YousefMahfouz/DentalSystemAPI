using AutoMapper;
using DentialSystem.Application.Contract;
using DentialSystem.Domain;
using DentialSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Application.Services.AppointmentService
{
    public class AppointmentServices : IAppointmentServices
    {
        private readonly IAppointmentReposatory _appointmentReposatory;
        private readonly IMapper _mapper;

        public AppointmentServices(IAppointmentReposatory appointmentRepsatory, IMapper mapper)
        {
            _appointmentReposatory = appointmentRepsatory;
            _mapper = mapper;
        }

       

       
     

        public async Task<AppointmentDTO> UpdateAppointment(int id, AppointmentDTO appointmentDto)
        {
            {
                if (appointmentDto.Id == 0)
                {
                    await CreateAppointment(appointmentDto);
                    return appointmentDto;
                }
                else
                {
                    var model = _mapper.Map<Appointment>(appointmentDto);
                    await _appointmentReposatory.UpdateAsync(model, id);
                     await  _appointmentReposatory.SaveChanges();

                    return appointmentDto;
                }
            }


        }

        public async Task< bool> DeleteAppointment(int id)
        {
            await _appointmentReposatory.DeleteAsync(id);
            await _appointmentReposatory.SaveChanges();    
            return true;
        }

        public async Task<AppointmentDTO> GetByIdAsync(int id)
        {
            var appointment = await _appointmentReposatory.GetByIdAsync(id);
            var appointmentmapped = _mapper.Map<AppointmentDTO>(appointment);
            return appointmentmapped;
        }

        public async Task<AppointmentDTO> CreateAppointment(AppointmentDTO appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            if (_appointmentReposatory.HasAppointmentAtSameTime(appointment))
            {
                throw new Exception("Patient already has an appointment at this time.");
            }

            if (_appointmentReposatory.IsDayFull(appointment.date))
            {
                throw new Exception("The day is already full.");
            }

            if (_appointmentReposatory.HasPatientWithRank(appointment))
            {
                throw new Exception("Another patient has already booked with this rank.");
            }

            var createdAppointment = _appointmentReposatory.CreateAsync(appointment);
            await _appointmentReposatory.SaveChanges();

            var createdAppointmentDTO = _mapper.Map<AppointmentDTO>(createdAppointment);

            return createdAppointmentDTO;
        }
    }
}
