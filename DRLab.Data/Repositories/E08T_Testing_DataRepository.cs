using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E08T_Testing_DataRepository : Repository<E08T_Testing_Data>, IE08T_Testing_DataRepository
    {
        public E08T_Testing_DataRepository(DbContext db) : base(db)
        {

        }

        public async Task<List<E08T_Testing_DataViewModel>> GetDataTestTing(long id)
        {
            var data = await Entities.Include(x => x.E00T_SampleMatrix).Where(x => x.matrixID == id).ProjectTo<E08T_Testing_DataViewModel>().ToListAsync();
            return data;
        }
    }
}
