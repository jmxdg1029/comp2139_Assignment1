using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.DataLayer.Interface;
using Assignment1.Models;

namespace Assignment1.DataLayer.Repositories
{
    public class CustomerRepo : Repository<Customer>, ICustomer
    {

        public CustomerRepo(IncidentContext ctx)
            :base(ctx)
        {

        }
    }
}
