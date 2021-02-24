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
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For Last Name")]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For Address")]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For City")]
        public string CustomerCity { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For State")]
        public string CustomerState { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For Postal Code")]
        public string CustomerPostalCode { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For Country")]
        public string CountryId { get; set; }
        public Country Country { get; set; }
        
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }

    }
}
