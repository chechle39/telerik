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
        public E08T_AnalysisRequest_DataRepository(DbContext db) : base(db)
        {
            
        }

        public Task<bool> CreateAnalysisRequestData(List<CreateCustomeRequest> request)
        {
            foreach(var item in request)
            {
               foreach(var iitem in item.Data)
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
                }
            }
           
            throw new NotImplementedException();
        }
    }
}
