using System;
using System.Collections.Generic;
using System.Linq;

namespace DRLab.Data.Base
{
    public interface IRepository<TEntity> : IRepository
        where TEntity : class
    {
        IQueryable<TEntity> AsQueryable();

        void Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        TEntity GetById(object id);

        IQueryable<TEntity> GetAll();

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Remove(int id);
        void RemoveLong(long id);
        void RemoveStringID(string id);

    }

    public interface IRepository : IDisposable
    {
        int SaveChanges();
    }
}
