using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.DataLayer.Interface;
using Assignment1.Models;

namespace Assignment1.DataLayer.Repositories
{
    public class RegistrationRepo : Repository<Registration>, IRegistration
    {
        public RegistrationRepo(IncidentContext ctx)
           : base(ctx)
        {

        }
    }
}
