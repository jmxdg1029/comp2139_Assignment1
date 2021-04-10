using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class IncidentViewModel
    {
        public Incident Incident { get; set; }
        public List<Incident> IncidentList { get; set; }
        public string pageVerify { get; set; }
        public Customer Customer { get; set; }
        public List<Customer> CustomerList { get; set; }
        public Product Product { get; set; }
        public List<Product> ProductList { get; set; }
        public Technician Technician { get; set; }
        public List<Technician> TechnicianList { get; set; }
        public int IncidentId { get; set; }
        public string currPage { get; set; }
    }
}
