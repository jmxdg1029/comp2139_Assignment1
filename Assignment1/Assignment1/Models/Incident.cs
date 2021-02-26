using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }
        
        [ForeignKey("Customer")]
        [Range(1, 1000, ErrorMessage = "Please enter the customers name.")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
     

        [Range(1, 1000, ErrorMessage = "Enter a product name")]

        public int ProductId { get; set; }
        
      

        [Required(ErrorMessage = "Please enter the title of the incident.")]
        public string Title { get; set; }


        [Range(1, 1000, ErrorMessage = "Please enter the technicians name")]

        public int TechnicianId { get; set; }
       

        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter in a date.")]
        public DateTime DateOpened { get; set; }

        [Required(ErrorMessage ="Please enter in a date.")]
        public DateTime DateClosed { get; set; }
    }
}
