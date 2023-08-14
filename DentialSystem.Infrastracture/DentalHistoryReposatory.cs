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
    internal class DentalHistoryReposatory : Reposatory<DentialHistory, int>, IDentialHistoryReposatory
    {
        public DentalHistoryReposatory(ApplicationContext context) : base(context)
        {
        }
    }
}
