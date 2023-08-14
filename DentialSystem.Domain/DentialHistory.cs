using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Domain
{
    public class DentialHistory
    {
        public int Id { get; set; }
        public  string? Prescription { get; set; }
        public  string? Notes { get; set; }
        [ForeignKey("Paitant")]
        public String? PaitantId { get; set; }

        public Paitant? Paitant { get; set; }
    }
}
