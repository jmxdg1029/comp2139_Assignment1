using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Assignment1.Models
{
    public class Country
    {
        [Range(1,5)]
        public string CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
