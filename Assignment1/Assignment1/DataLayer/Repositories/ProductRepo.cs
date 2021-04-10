using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.DataLayer.Interface;
using Assignment1.Models;

namespace Assignment1.DataLayer.Repositories
{
    public class ProductRepo : Repository<Product>, IProduct
    {
        public ProductRepo(IncidentContext ctx)
            : base(ctx)
        {

        }
    }
}
