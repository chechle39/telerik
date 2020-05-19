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
    public class E08T_AnalysisRequest_DataRepository: Repository<E08T_AnalysisRequest_Data>, IE08T_AnalysisRequest_DataRepository
    {
        private IE08T_AnalysisRequest_ItemRepository _e08T_AnalysisRequest_ItemRepository;
        public E08T_AnalysisRequest_DataRepository(DbContext db, IE08T_AnalysisRequest_ItemRepository e08T_AnalysisRequest_ItemRepository) : base(db)
        {
            _e08T_AnalysisRequest_ItemRepository = e08T_AnalysisRequest_ItemRepository;
        }

        public async Task<bool> CreateAnalysisRequestData(List<CreateCustomeRequest> request)
        {
            foreach(var item in request)
            {
                if (item.Data.Count() > 0)
                {
                    foreach (var iitem in item.Data)
                    {
                        var check = Entities.Where(x => x.LVNCode == item.LVNCode && x.requestNo == item.requestNo).AsNoTracking().ToList();
                        if (check.Count() == 0)
                        {
                            var e08T_AnalysisRequest_Data = new E08T_AnalysisRequest_Data()
                            {
                                analysisCode = iitem.analysisCode,
                                LOD = iitem.LOD,
                                LVNCode = item.LVNCode,
                                max = null,
                                method = iitem.method,
                                min = null,
                                precision = null,
                                price = iitem.Price,
                                requestNo = item.requestNo,
                                sampleMatrix = item.sampleMatrix,
                                specification = item.specification,
                                specMark = null,
                                turnAroundDay = null,
                                unit = iitem.unit,
                                urgentRate = iitem.Urgent
                            };
                            Entities.Add(e08T_AnalysisRequest_Data);
                        } else
                        {
                            var e08T_AnalysisRequest_Data = new E08T_AnalysisRequest_Data()
                            {
                                analysisCode = iitem.analysisCode,
                                LOD = iitem.LOD,
                                LVNCode = item.LVNCode,
                                max = null,
                                method = iitem.method,
                                min = null,
                                precision = null,
                                price = iitem.Price,
                                requestNo = item.requestNo,
                                sampleMatrix = item.sampleMatrix,
                                specification = item.specification,
                                specMark = null,
                                turnAroundDay = null,
                                unit = iitem.unit,
                                urgentRate = iitem.Urgent
                            };
                            Entities.Update(e08T_AnalysisRequest_Data);
                        }
                        
                    }
                }
            }
            await _e08T_AnalysisRequest_ItemRepository.CreatAnalysisRequestItem(request);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAnalysisRequestData(string[] request)
        {
            foreach (var item in request)
            {
                var objDelete = await Entities.Where(x => x.requestNo == item).ToListAsync();
                if (objDelete.Count() > 0)
                {
                    foreach(var iitem in objDelete)
                    {
                        Entities.Remove(iitem);
                    }
                    
                }
            }
            return await Task.FromResult(true);
        }
    }
}
