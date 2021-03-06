﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Product    
    {

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the a value for the product code")]
        public String ProductCode { get; set; }

        [Required(ErrorMessage = "Please enter the a value for the product name")]
        public String ProductName { get; set; }

        [Required(ErrorMessage = "Please enter a value for the product time")]
        public DateTime ProductReleaseDate { get; set; }
        
        [Required(ErrorMessage = "Please enter a value for the product yearly price")]
        public float ProductYearlyPrice { get; set; }
    }
}
