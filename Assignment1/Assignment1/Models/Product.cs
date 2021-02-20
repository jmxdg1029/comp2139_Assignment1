using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Product
    {

        public int ProductNumber { get; set; }

        [RegularExpression(@"\D"), Required(ErrorMessage = "Please enter the a value for the product name")]
        public String ProductName { get; set; }

        [RegularExpression(@"\d"), Required(ErrorMessage = "Please enter a value for the product number")]
        public int? ProductPrice { get; set; }
    }
}
