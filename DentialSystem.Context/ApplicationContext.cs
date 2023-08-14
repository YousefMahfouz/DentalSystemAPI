using DentialSystem.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Context
{
    public class ApplicationContext: IdentityDbContext<Paitant>
    {
        public ApplicationContext():base()
        {
            
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<PaitantTreatment> paitantTreatments { get; set; }
        public DbSet<DentialHistory> DentialHistory { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DentialSystemDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True",x=>x.UseDateOnlyTimeOnly()); 
            base.OnConfiguring(optionsBuilder);
        }

    }
}
