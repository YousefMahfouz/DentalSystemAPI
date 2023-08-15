using AutoMapper;
using DentialSystem.Application.Contract;
using DentialSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Application.Services
{
    public class TreatmentServices : ITreatmentServices
    {
        private readonly ITreatmentReposatory treatmentReposatory;
        private readonly IMapper mapper;

        public TreatmentServices(ITreatmentReposatory treatmentReposatory ,IMapper mapper)
        {
            this.treatmentReposatory = treatmentReposatory;
            this.mapper = mapper;
        }
        public async Task<List<GetTreatmentDTO>> GetAllTreatment()
        {
            var res= await treatmentReposatory.GetAllAsync();
            return mapper.Map<List<GetTreatmentDTO>>(res);
        }
    }
}
