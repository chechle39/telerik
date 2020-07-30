using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E08T_Testing_InfoRepository : Repository<E08T_Testing_Info>, IE08T_Testing_InfoRepository
    {
        private readonly IE08T_Testing_DataRepository _e08T_Testing_DataRepository;
        public E08T_Testing_InfoRepository(DbContext db, IE08T_Testing_DataRepository e08T_Testing_DataRepository) :base(db)
        {
            _e08T_Testing_DataRepository = e08T_Testing_DataRepository;
        }

        public async Task<List<E08T_Testing_InfoViewModel>> Getdata()
        {
            return await Entities.ProjectTo<E08T_Testing_InfoViewModel>().ToListAsync();
        }

        public async Task<List<E00T_CustomerGridViewModel>> GetE08TTestingInfoByMtID(long id)
        {
            var data = await GetE08TTestingInfoComboboxByMatrix(id);
            var lisE00T_CustomerGrid = new List<E00T_CustomerGridViewModel>();
            foreach (var item in data)
            {
                var obj = new E00T_CustomerGridViewModel()
                {
                    analysisCode = item.analysisCode,
                    LOD = "",
                    Mark = "",
                    method = item.method,
                    Price = 0,
                    specification = item.specification,
                    TurnAroundDay = 0,
                    unit = item.unit,
                    Urgent = 0
                };
                lisE00T_CustomerGrid.Add(obj);
            }
            return lisE00T_CustomerGrid;
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
                    TurnAroundDay = 0,
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

        public async Task<List<E08T_Testing_InfoViewModel>> GetE08TTestingInfoComboboxByMatrix(long id)
        {
            var data = await _e08T_Testing_DataRepository.GetDataTestTing(id);
            var testIF = await Entities.ProjectTo<E08T_Testing_InfoViewModel>().ToListAsync();
            var result = from s in data
                         join o in testIF on s.specID equals o.specID
                         select o;
            return result.ToList();
        }
    }
}
