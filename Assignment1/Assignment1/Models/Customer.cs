using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment1.Models
{
    public class Customer 
    {
        public int CustomerId { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(51, ErrorMessage = "The First Name value cannot exceed 51 characters. ")]
        [Required(ErrorMessage = "Please Enter A Value for First Name")]
        public string CustomerFirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(51, ErrorMessage = "The Last Name value cannot exceed 51 characters. ")]
        [Required(ErrorMessage = "Please Enter A Value for Last Name")]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For Address")]
        [StringLength(51, ErrorMessage = "The Address value cannot exceed 51 characters. ")]
        public string CustomerAddress { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(51, ErrorMessage = "The City value cannot exceed 51 characters. ")]
        [Required(ErrorMessage = "Please Enter A Value For City")]
        public string CustomerCity { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(51, ErrorMessage = "The State value cannot exceed 51 characters. ")]
        [Required(ErrorMessage = "Please Enter A Value For State")]
        public string CustomerState { get; set; }

        [StringLength(21, ErrorMessage = "The Postal Code value cannot exceed 21 characters. ")]
        [Required(ErrorMessage = "Please Enter A Value For Postal Code")]
        public string CustomerPostalCode { get; set; }

        [Required(ErrorMessage = "Please Enter A Value For Country")]
        public string CountryId { get; set; }
        public Country Country { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(51, ErrorMessage = "The City value cannot exceed 51 characters. ")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please enter valid email, e.g email@address.com")]
        public string CustomerEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)[ ]([0-9]{3})[-]([0-9]{4})$", ErrorMessage = "Not a valid phone number, e.g (222) 222-2222")]
        public string CustomerPhone { get; set; }


        

        
    }
}
