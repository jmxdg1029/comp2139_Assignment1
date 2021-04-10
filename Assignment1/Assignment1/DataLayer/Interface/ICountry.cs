using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.DataLayer.Repositories;
using Assignment1.Models;

namespace Assignment1.DataLayer.Interface
{
    public interface ICountry : IRepository<Country>
    {
    }
}
