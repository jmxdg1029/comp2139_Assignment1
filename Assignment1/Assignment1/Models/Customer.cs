using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Assignment1.Models
{
    public class Customer 
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For First Name")]
        public String CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For Last Name")]
        public String CustomerLastName { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For Address")]
        public String CustomerAddress { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For City")]
        public String CustomerCity { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For State")]
        public String CustomerState { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For Postal Code")]
        public String CustomerPostalCode { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For Country")]
        public String CustomerCountry { get; set; }
        
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public String CustomerEmail { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        public int CustomerPhone { get; set; }

    }
}
