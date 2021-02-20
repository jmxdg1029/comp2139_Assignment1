using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Please enter the a value for the product name")]
        public int ProductCode { get; set; }

        [RegularExpression(@"\D"), Required(ErrorMessage = "Please enter the a value for the product name")]
        public String ProductName { get; set; }

        [Required(ErrorMessage = "Please enter a value for the product number")]
        [RegularExpression(@"\d", ErrorMessage = "Please enter only numbers")]
        [Range(2020, 2050, ErrorMessage ="Year must be between 2020,2050")]
        public int? ProuctReleaseDate { get; set; }

        public int? ProductYearlyPrice { get; set; }
    }
}
