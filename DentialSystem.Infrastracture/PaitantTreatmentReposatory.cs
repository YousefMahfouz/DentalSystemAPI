using DentialSystem.Application.Contract;
using DentialSystem.Context;
using DentialSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Infrastracture
{
    public class PaitantTreatmentReposatory : Reposatory<PaitantTreatment, int>,IPaitantTreatmentReposatory
    {
        public PaitantTreatmentReposatory(ApplicationContext context) : base(context)
        {
        }
    }
}
