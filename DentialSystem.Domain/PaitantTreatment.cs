using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Domain
{
    public class PaitantTreatment
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        [ForeignKey("Treatment")]
        public int TreatmentId { get; set; }
        [ForeignKey("Paitant")]
        public String? PaitantId { get; set; }
        public  Treatment? Treatment { get; set;}
        public Paitant? Paitant { get; set; }
    }
}
