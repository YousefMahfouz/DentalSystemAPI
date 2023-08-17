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

       

        public async Task<AppointmentDTO> CreateAppointment(AppointmentDTO appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            if (appointment.PaitantId == null)
            {
                throw new Exception("The patient ID cannot be null.");
            }

            if (await CanBookAppointment(appointment.date, appointment.time, appointment.PaitantId))
            {
                var createdAppointment = await _appointmentReposatory.CreateAsync(appointment);

                var createdAppointmentDto = _mapper.Map<AppointmentDTO>(createdAppointment);
                await _appointmentReposatory.SaveChanges();
                return createdAppointmentDto;
            }
            else
            {
                throw new Exception("The selected appointment day is already fully booked ");
            }
        }

        public async Task<bool> CanBookAppointment(DateOnly date, TimeOnly time, string patientId)
        {
            var existingAppointments = await _appointmentReposatory.GetAppointmentsForDate(date);

            bool slotsAvailable = existingAppointments.Count < 8;

            bool patientHasAppointment = existingAppointments.Any(a =>
                a.PaitantId == patientId &&
                a.date == date &&
                a.time == time
            );

            bool sameHourAndDay = existingAppointments.Any(a =>
                a.date == date &&
                a.time == time &&
                a.PaitantId != patientId 
            );

            return slotsAvailable && !patientHasAppointment && !sameHourAndDay;
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
    }
}
