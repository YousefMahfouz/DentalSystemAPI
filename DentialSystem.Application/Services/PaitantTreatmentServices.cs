using DentialSystem.Application.Contract;
using DentialSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Application.Services
{
    public class PaitantTreatmentServices:IPaitantTreatmentServices
    {
        private readonly IPaitantTreatmentReposatory paitantTreatmentReposatory;

        public PaitantTreatmentServices(IPaitantTreatmentReposatory paitantTreatmentReposatory)
        {
            this.paitantTreatmentReposatory = paitantTreatmentReposatory;
        }

        public async Task<List<PaitantTreatmentDTO>> GetPaitantTreatments(string paitantId)
        {
            PaitantTreatmentDTO paitantTreatmentDTO = new PaitantTreatmentDTO();
            List<PaitantTreatmentDTO> paitantTreatments = new List<PaitantTreatmentDTO>();
            var res = await paitantTreatmentReposatory.GetPaitantTreatments(paitantId);
            foreach(var item in res) 
            {
                paitantTreatmentDTO.TreatmentName = item.Treatment.Name;
                paitantTreatmentDTO.TreatmentPrice = item.Treatment.Price;
                paitantTreatmentDTO.Cost = item.Cost;
                paitantTreatmentDTO.Id = item.Id;
                paitantTreatments.Add(paitantTreatmentDTO);

            }
            return paitantTreatments;

        }
    }
}
