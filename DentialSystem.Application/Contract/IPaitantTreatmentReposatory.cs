using DentialSystem.Domain;
using DentialSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Application.Contract
{
    public interface IPaitantTreatmentReposatory:IRepository<PaitantTreatment,int>
    {
        public Task<List<PaitantTreatment>> GetPaitantTreatments(string paitantid);
    }
}
