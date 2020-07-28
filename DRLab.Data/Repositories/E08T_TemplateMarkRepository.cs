using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E08T_TemplateMarkRepository : Repository<E08T_TemplateMark>, IE08T_TemplateMarkRepository
    {
        private readonly IUnitOfWork _uow;
        public E08T_TemplateMarkRepository(DbContext db, IUnitOfWork uow) : base(db)
        {
            _uow = uow;
        }

        public async Task<bool> InsertEntity(List<E08T_TemplateMarkViewModel> request)
        {
            foreach(var item in request)
            {
                var getOlData = await Entities.AsNoTracking().Where(x => x.TemLateName == item.TemLateName).ToListAsync();
                Entities.RemoveRange(getOlData);
                _uow.SaveChanges();
                foreach (var ii in item.Data)
                {
                    
                    var obj = new E08T_TemplateMark()
                    {
                        AnalysisCode = ii.AnalysisCode,
                        LOD = ii.LOD,
                        Mark = ii.Mark,
                        Method = ii.Method,
                        Price = ii.Price,
                        Specification = ii.Specification,
                        TurnAroundDay = ii.turnAroundDay,
                        TemLateName = item.TemLateName,
                        TenanId = item.TenanId,
                        Unit = ii.Unit,
                        Urgent = ii.Urgent,
                        Id = 0,
                    };
                    Entities.Add(obj);
                }
                
            }
            return await Task.FromResult(true);
        }

        public async Task<List<E00T_CustomerGridViewModel>> GetAllE08TTemplateMark(E08T_TemplateMarkSearch request)
        {
            var listE00T_CustomerGridViewModel = new List<E00T_CustomerGridViewModel>();
            var getlist = await Entities.Where(x => x.TenanId == request.TenanId && x.TemLateName == request.TemLateName).ToListAsync();

            foreach (var item in getlist)
            {
                var obj = new E00T_CustomerGridViewModel()
                {
                    analysisCode = item.AnalysisCode,
                    LOD = item.LOD,
                    Mark = item.Mark,
                    Urgent = item.Urgent,
                    method = item.Method,
                    specification = item.Specification,
                    TurnAroundDay = item.TurnAroundDay,
                    Price = item.Price,
                    unit = item.Unit,
                };
                listE00T_CustomerGridViewModel.Add(obj);
            }
            return await Task.FromResult(listE00T_CustomerGridViewModel);
        }
    }
}
