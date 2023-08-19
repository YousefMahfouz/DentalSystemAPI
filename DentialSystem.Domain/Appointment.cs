using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Domain
{
    public enum Ranking
    {
        first=1,
        second,
        third,
        fourth,
        fifth,
        sixth,
        seventh,
        eight,

    }
    public class Appointment
    {
        public int Id { get; set; }
        public DateOnly date {get; set; }
        public TimeOnly time { get; set; }
        public Ranking ranking { get; set; }
        public decimal cost { get; set; }
        [ForeignKey("Paitant")]
        public string? PaitantId { get; set; }

        public Paitant? Paitant { get; set; }

        public Boolean IsCompleted { get; set; }    


    }
}
