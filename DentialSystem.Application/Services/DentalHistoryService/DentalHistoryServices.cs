using AutoMapper;
using DentialSystem.Application.Contract;
using DentialSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Application.Services.DentalService
{
    public class DentalHistoryServices : IDentalHistoryServices
    {
        private readonly IDentialHistoryReposatory _dentialHistoryReposatory;
        private readonly IMapper _mapper;

        public DentalHistoryServices(IDentialHistoryReposatory dentialHistoryReposatory, IMapper mapper)
        {
            _dentialHistoryReposatory = dentialHistoryReposatory;
            _mapper = mapper;
        }

        public async Task<DentalHistoryDTO> GetByIdAsync(int id)
        {
            var dental = await _dentialHistoryReposatory.GetByIdAsync(id);
            var Dentaltmapped = _mapper.Map<DentalHistoryDTO>(dental);
            return Dentaltmapped;
        }
    }
}
