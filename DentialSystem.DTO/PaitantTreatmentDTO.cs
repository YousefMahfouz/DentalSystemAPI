using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.DTO
{
    public class PaitantTreatmentDTO
    {
        public int Id { get; set; }
        public string TreatmentName { get; set; }
        public int TreatmentPrice { get; set; }
        public decimal Cost { get; set; }
    }
}
