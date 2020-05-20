using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E08T_Testing_InfoRepository : Repository<E08T_Testing_Info>, IE08T_Testing_InfoRepository
    {
        public E08T_Testing_InfoRepository(DbContext db):base(db)
        {

        }

        public async Task<List<E00T_CustomerGridViewModel>> GetE08TTestingInfoBySpecId(string analysisCode)
        {
            var analysisCodeData = await Entities.Where(x => x.analysisCode == analysisCode).ToListAsync();
           // var data = analysisCodeData.Where(x => x.method == x.specification);
            var lisE00T_CustomerGrid = new List<E00T_CustomerGridViewModel>();
            foreach(var item in analysisCodeData)
            {
                var obj = new E00T_CustomerGridViewModel()
                {
                    analysisCode = item.analysisCode,
                    LOD = "",
                    Mark = "",
                    method = item.method,   
                    Price = 0,
                    specification = item.specification,
                    TAT = "",
                    unit = item.unit,
                    Urgent = 0
                };
                lisE00T_CustomerGrid.Add(obj);
            }
            return lisE00T_CustomerGrid;
        }

        public async Task<List<E08T_Testing_InfoViewModel>> GetE08TTestingInfoCombobox(string text)
        {

            if (!string.IsNullOrEmpty(text))
            {
                return await Entities.Where(x => x.specification.Contains(text) || x.method.Contains(text)).ProjectTo<E08T_Testing_InfoViewModel>().ToListAsync();
            }
            else
            {
                return await Entities.ProjectTo<E08T_Testing_InfoViewModel>().ToListAsync();
            }
        }
    }
}
