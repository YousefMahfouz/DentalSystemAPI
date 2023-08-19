using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.DTO
{
    public class DentalHistoryDTO
    {
        public int Id { get; set; }
        public string? Prescription { get; set; }
        public string? Notes { get; set; }
     
        public string? PaitantId { get; set; }
    }
}
