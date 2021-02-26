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
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        [Required(ErrorMessage = "Enter a product name")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please enter the title of the incident.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter a technician name")]
        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter in a date.")]
        public DateTime DateOpened { get; set; }

        [Required(ErrorMessage ="Please enter in a date.")]
        public DateTime DateClosed { get; set; }
    }
}
