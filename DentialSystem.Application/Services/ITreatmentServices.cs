using DentialSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Application.Services
{
    public interface ITreatmentServices
    {
        Task<List<GetTreatmentDTO>>GetAllTreatment();
    }
}
