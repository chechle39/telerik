using DRLab.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DRLab.Data.Base
{
    public class Repository<TEntity> : IRepository<TEntity>
         where TEntity : class
    {
        private readonly DbContext _dbContext;

        public DbSet<TEntity> Entities { get; }

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            Entities = _dbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return Entities.AsQueryable();
        }

        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Entities.AddRange(entities);
        }

        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Entities;
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Update(entity);
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Entities.UpdateRange(entities);
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new ItemNotFoundException();

            Entities.Remove(entity);
        }

        

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
