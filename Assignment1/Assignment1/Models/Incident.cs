using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }
        
        [Required (ErrorMessage = "Please enter the customers name.")]
        public string CustomerName { get; set; }
        
        [Required(ErrorMessage = "Please enter the products name.")]
        public string Product { get; set; }
        
        [Required(ErrorMessage ="Please enter in a date.")]
        public DateTime DateOpened { get; set; }
        

    }
}
