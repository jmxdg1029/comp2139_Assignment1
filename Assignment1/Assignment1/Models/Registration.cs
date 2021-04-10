using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }

        [Required(ErrorMessage = "Please Choose the customers name.")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Choose a product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        
    }
}
