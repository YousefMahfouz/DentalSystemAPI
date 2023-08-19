
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.DTO
{
    public class AppointmentDTO
    {

        public int Id { get; set; } 
        public DateOnly date { get; set; }
        public TimeOnly time { get; set; }
      //  public int ranking { get; set; }
        public decimal cost { get; set; }

        public string? PaitantId { get; set; }
    }
}
