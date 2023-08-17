using AutoMapper;
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
<<<<<<< HEAD
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
=======
            CreateMap<Paitant, paitantRegisterDTO>().ReverseMap();
            CreateMap<Paitant, PaitantLoginDTO>().ReverseMap();


>>>>>>> 6663d09e898dfc72bb86ffc46a3db57430a36c9b

        }

    }
}
