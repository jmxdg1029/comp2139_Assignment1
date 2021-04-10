using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.DataLayer
{
    public interface IHome<T> where T : class
    {
        IEnumerable<T> List(IHome<T> options);
        void Index(T entity);
        void About(T entity);
        void AddIncident(T entity);
        void AddProduct(T entity);
        void Privacy(T entity);

        void Save();
    }
}
