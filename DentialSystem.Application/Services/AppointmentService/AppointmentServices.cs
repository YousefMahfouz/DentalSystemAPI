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


                //var model = _mapper.Map<Appointment>(appointmentDto);

                //await _appointmentReposatory.UpdateAsync(model, id);
                //await _appointmentReposatory.SaveChanges();

                //return appointmentDto;
                var appointment = _mapper.Map<Appointment>(appointmentDto);
                if (await _appointmentReposatory.HasAppointmentAtSameTime(appointment.date, appointment.time) ||
                await _appointmentReposatory.IsDayFull(appointment.date) ||
                 await _appointmentReposatory.HasPatientWithRank(appointment.PaitantId, appointment.date))
                {
                    throw new Exception("An appointment is already booked at the same time.");
                }
                else
                {
                    {
                        int rankingValue = await _appointmentReposatory.GetRanking(appointment.date) + 1;
                        appointment.ranking = (Ranking)rankingValue;
                          _appointmentReposatory.DeleteAppointment(id);
                        var createdAppointment = await _appointmentReposatory.CreateAsync(appointment);
                        await _appointmentReposatory.SaveChanges();

                        return _mapper.Map<AppointmentDTO>(createdAppointment);
                    }
                }

            }


        }

        public async Task<bool> DeleteAppointment(int id)
        {
            await _appointmentReposatory.DeleteAppointment(id);
            return true;
        }

        //public async Task<AppointmentDTO> GetByIdAsync(int id)
        //{
        //    var appointment = await _appointmentReposatory.GetByIdAsync(id);
        //    var appointmentmapped = _mapper.Map<AppointmentDTO>(appointment);
        //    return appointmentmapped;
        //}

        public async Task<AppointmentDTO> CreateAppointment(AppointmentDTO appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            if (await _appointmentReposatory.HasAppointmentAtSameTime(appointment.date, appointment.time) ||
            await _appointmentReposatory.IsDayFull(appointment.date) ||
             await _appointmentReposatory.HasPatientWithRank(appointment.PaitantId, appointment.date))
            {
                throw new Exception("An appointment is already booked at the same time.");
            }
            //if (_appointmentReposatory.HasAppointmentAtSameTime(appointment))
            //{
            //    throw new Exception("An appointment is already booked at the same time.");
            //}
            //else if (_appointmentReposatory.IsDayFull(appointment.date))
            //{
            //    throw new Exception("The day is already full.");
            //}
            //else if (_appointmentReposatory.HasPatientWithRank(appointment.PaitantId, appointment.date))
            //{
            //    throw new Exception("Another patient has already booked with this rank.");
            //}
            else
            {
                {
                    int rankingValue = await _appointmentReposatory.GetRanking(appointment.date) +1;
                    appointment.ranking = (Ranking)rankingValue; 
                    var createdAppointment = await _appointmentReposatory.CreateAsync(appointment);
                    
                    await _appointmentReposatory.SaveChanges();

                    return _mapper.Map<AppointmentDTO>(createdAppointment);
                }
            }

            

        }

        public async Task<AppointmentDTO> GetByIdAsync(string paitantId)
        {
            var appointment = await _appointmentReposatory.GetByIdAsync(paitantId);
            var appointmentmapped = _mapper.Map<AppointmentDTO>(appointment);
            return appointmentmapped;
        }

        public async Task<List<AppointmentDTO> >GetAll(string paitantId)
        {
            var appointment = await _appointmentReposatory.GetALLAppointmentAsync(paitantId);
            var appointmentmapped = _mapper.Map<List<AppointmentDTO>>(appointment);
            return appointmentmapped;
        }
    }
}
