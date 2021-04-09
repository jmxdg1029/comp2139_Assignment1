using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class IncidentViewModel
    {
        public List<Incident> Incident { get; set; }
        public string pageVerify { get; set; }
        public List<Customer> Customer { get; set; }
        public List<Product> Product { get; set; }
        public List<Technician> Technician { get; set; }
    }
}
