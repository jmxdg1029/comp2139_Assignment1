using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.DataLayer.Interface;
using Assignment1.Models;


namespace Assignment1.DataLayer.Repositories
{
    public class CountryRepo : Repository<Country>, ICountry
    {
        public CountryRepo(IncidentContext ctx)
            :base(ctx)
        {

        }
    }
}
