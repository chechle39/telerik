using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E08T_AnalysisRequest_ItemRepository : Repository<E08T_AnalysisRequest_Item>, IE08T_AnalysisRequest_ItemRepository
    {
        public E08T_AnalysisRequest_ItemRepository(DbContext db): base(db)
        {

        }

        public async Task<bool> CreatAnalysisRequestItem(List<CreateCustomeRequest> request)
        {
            foreach(var item in request)
            {
                var e08T_AnalysisRequest_Item = new E08T_AnalysisRequest_Item()
                {
                    LVNCode = item.LVNCode,
                    detected = null,
                    remarkToLab = item.remarkToLab,
                    requestNo = item.requestNo,
                    sampleCode = item.sampleCode,
                    sampleDescription = item.sampleDescription,
                    sampleName = item.sampleName,
                    weight = item.weight
                };
                Entities.Add(e08T_AnalysisRequest_Item);
            }
            return await Task.FromResult(true);
        }
    }
}
