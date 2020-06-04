using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.Base
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        void CommitTransaction();
        void BeginTransaction();
        TRepository GetRepository<TRepository>()
            where TRepository : IRepository;
    }
}
