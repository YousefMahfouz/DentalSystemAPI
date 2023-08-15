using DentialSystem.Application.Contract;
using DentialSystem.Context;
using DentialSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Infrastracture
{
    public class PaitantTreatmentReposatory : Reposatory<PaitantTreatment, int>,IPaitantTreatmentReposatory
    {
        private readonly ApplicationContext context;
        private DbSet<PaitantTreatment> dbset;

        public PaitantTreatmentReposatory(ApplicationContext context) : base(context)
        {
            this.context = context;
            dbset = this.context.Set<PaitantTreatment>();
        }

        public async Task<List<PaitantTreatment>> GetPaitantTreatments(string paitantid)
        {
            return await dbset.Include(t => t.Treatment)
                              .Where(p => p.PaitantId == paitantid)
                              .ToListAsync();
        }
    }
}
