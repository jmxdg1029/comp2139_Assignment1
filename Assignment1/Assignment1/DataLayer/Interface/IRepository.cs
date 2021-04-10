using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.DataLayer.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(String includeProperties);
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Manage(TEntity entity);
        void Add(TEntity entity);
        void Delete (TEntity entity);
        void Update(TEntity entity);
        void Save();

    }
}
