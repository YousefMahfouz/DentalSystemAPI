using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.DTO
{
    public class paitantRegisterDTO
    {
        
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Name Length Must Be Between 6 to 50 char")]

        public string? Name { get; set; }
       public bool Gender { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name Length Must Be Between 3 to 50 char")]
        public string? userName { get; set; }
        [DataType(DataType.Password)]
        public string  Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        public string? Phone { get; set; }
        public string? EmailAddress { get; set; }
        public string? Address { get; set; }
        public string? MedicialHistory { get; set; }

    }
}
