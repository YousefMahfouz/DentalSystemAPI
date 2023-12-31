﻿using AutoMapper;
using DentialSystem.Domain;
using DentialSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Application.Mapper
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Treatment, GetTreatmentDTO>().ReverseMap();

            CreateMap<Appointment, AppointmentDTO>().ReverseMap();

            CreateMap<Paitant, paitantRegisterDTO>().ReverseMap();
            CreateMap<Paitant, PaitantLoginDTO>().ReverseMap();
            CreateMap<DentialHistory, DentalHistoryDTO>().ReverseMap();




        }

    }
}
