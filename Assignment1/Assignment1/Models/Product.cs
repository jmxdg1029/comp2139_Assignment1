using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Assignment1.Models
{
    public class Product
    {

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the a value for the product code")]
        public String ProductCode { get; set; }

        [Required(ErrorMessage = "Please enter the a value for the product name")]
        public String ProductName { get; set; }

        public DateTime? ProuctReleaseDate { get; set; }

        [Required(ErrorMessage = "Please enter a value for the product price")]

        public int? ProductYearlyPrice { get; set; }
    }
}
