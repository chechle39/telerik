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
    public class E08T_WorkingOrder_ItemRepository : Repository<E08T_WorkingOrder_Item>,IE08T_WorkingOrder_ItemRepository
    {
        private IE08T_AnalysisRequest_ItemRepository _e08T_AnalysisRequest_ItemRepository;
        public E08T_WorkingOrder_ItemRepository(DbContext db, IE08T_AnalysisRequest_ItemRepository e08T_AnalysisRequest_ItemRepository) : base(db)
        {
            _e08T_AnalysisRequest_ItemRepository = e08T_AnalysisRequest_ItemRepository;
        }
        public async Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAll(SearchRecordResult request)
        {
            var dataList = new List<GetRecordResult>();
            var analysisRequest_Info = await _e08T_AnalysisRequest_ItemRepository.GetAnalysisRequest_ItemByRequestNo(request.requestNo);
            analysisRequest_Info.OrderBy(x => x.LVNCode);
            
            foreach (var item in analysisRequest_Info)
            {
                var recordResultGridViewModel = new List<RecordResultGridViewModel>();
                var workingOrderItem = await Entities.Where(x => x.LVNCode == item.LVNCode && x.RequestNo == item.requestNo).ToListAsync();
                foreach (var iii in workingOrderItem)
                {
                    var RecordResult = new RecordResultGridViewModel()
                    {
                        ExpectationDate = iii.ExpectationDate,
                        LOD = iii.LOD,
                        Mark = null,
                        method = iii.Method,
                        Result = Convert.ToInt32(iii.Result),
                        ResultText = iii.ResultText,
                        ReviewResult = iii.ReviewResult,
                        specification = iii.Specification,
                        unit = iii.Unit,
                    };
                    recordResultGridViewModel.Add(RecordResult);
                }
                var getRecordResult = new GetRecordResult()
                {
                    Data = recordResultGridViewModel,
                    LVNCode = item.LVNCode,
                    remarkToLab = item.remarkToLab,
                    requestNo = item.requestNo,
                    sampleCode = item.sampleCode,
                    sampleDescription = item.sampleDescription,
                    sampleName = item.sampleName,
                    weight = item.weight
                };
                dataList.Add(getRecordResult);
            }
          
            return dataList;
        }
    }
}
