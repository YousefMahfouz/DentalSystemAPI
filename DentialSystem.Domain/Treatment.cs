using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Domain
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public  int Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<PaitantTreatment> PaitantTreatments { get; set; } = new HashSet<PaitantTreatment>();

    }
}
