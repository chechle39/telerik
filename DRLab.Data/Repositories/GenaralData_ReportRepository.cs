using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class GenaralData_ReportRepository : Repository<GeneralData_Report>, IGenaralData_ReportRepository
    {
        private readonly IUnitOfWork _uow;
        public GenaralData_ReportRepository(DbContext db, IUnitOfWork uow) : base(db)
        {
            _uow = uow;
        }
        public async Task<bool> CreateDataRP(List<GeneralData_Report> request)
        {
            Entities.AddRange(request);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteDataRP(string request)
        {
            try
            {
                var dataRM = await Entities.AsNoTracking().Where(x => x.sampleCode == request).ToListAsync();
                foreach(var item in dataRM)
                {
                    Entities.Remove(item);
    
                }

            } catch (Exception ex)
            {

            }
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }
    }
}
