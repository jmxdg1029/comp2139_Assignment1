using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.DataLayer.Interface;
using Assignment1.Models;

namespace Assignment1.DataLayer.Repositories
{
    public class TechnicianRepo : Repository<Technician>, ITechnician
    {

        public TechnicianRepo(IncidentContext ctx)
            : base(ctx)
        {

        }
    }
}
