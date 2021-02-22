using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }
        [Required(ErrorMessage = "Please enter a valid Name")]
        public string TechnicianName { get; set; }
        [Required(ErrorMessage = "Please enter a valid Email Address")]
        public string TechnicianEmail { get; set; }
        [Required(ErrorMessage = "Please enter a valid Phone Number")]
        public string TechnicianPhone { get; set; }
       
    }
}
