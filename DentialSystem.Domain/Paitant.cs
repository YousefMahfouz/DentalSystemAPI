using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Domain
{
    public class Paitant:IdentityUser
    {
        public  string Name { get; set; }
        public int Age { get; set; }
        public  bool Gender { get; set; }
        public  string Address { get; set; }
        public string MedicialHistory { get; set; }
        public  bool Isdeleted { get; set; }
        public ICollection<PaitantTreatment> PaitantTreatments { get; set; } =new HashSet<PaitantTreatment>();  

    }
}
