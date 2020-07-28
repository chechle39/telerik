using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace DRLab.Data.Repositories
{
    public class E08T_WorkingOrder_ItemRepository : Repository<E08T_WorkingOrder_Item>,IE08T_WorkingOrder_ItemRepository
    {
        private IE08T_AnalysisRequest_ItemRepository _e08T_AnalysisRequest_ItemRepository;
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;

        public E08T_WorkingOrder_ItemRepository(DbContext db, IE08T_AnalysisRequest_ItemRepository e08T_AnalysisRequest_ItemRepository, IUnitOfWork uow, IConfiguration configuration) : base(db)
        {
            _e08T_AnalysisRequest_ItemRepository = e08T_AnalysisRequest_ItemRepository;
            _uow = uow;
            _configuration = configuration;
        }
        public async Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAll(SearchRecordResult request)
        {
            var dataList = new List<GetRecordResult>();
            var analysisRequest_Info = await _e08T_AnalysisRequest_ItemRepository.GetAnalysisRequest_ItemByRequestNo(request.requestNo);
            analysisRequest_Info.OrderBy(x => x.LVNCode);
            
            foreach (var item in analysisRequest_Info)
            {
                List<E08T_WorkingOrder_Item> workingOrderItem;
                var recordResultGridViewModel = new List<RecordResultGridViewModel>();
                workingOrderItem = await Entities.Where(x => x.RequestNo == item.requestNo && x.LVNCode == item.LVNCode).AsNoTracking().ToListAsync();
                if (workingOrderItem.Count()>0)
                {
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
                            WOID = iii.WOID,
                            LVNCode = iii.LVNCode,
                            AnalysisCode = iii.AnalysisCode,
                            ValidationResult = iii.ValidationResult
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
                        weight = item.weight,
                        SampleMatrix = workingOrderItem[0].SampleMatrix
                    };
                    dataList.Add(getRecordResult);
                }    
            }
          
            return dataList;
        }

        public async Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAllByAccept(SearchRecordResult request)
        {
            var dataList = new List<GetRecordResult>();
            var analysisRequest_Info = await _e08T_AnalysisRequest_ItemRepository.GetAnalysisRequest_ItemByRequestNo(request.requestNo);
            analysisRequest_Info.OrderBy(x => x.LVNCode);

            foreach (var item in analysisRequest_Info)
            {
                List<E08T_WorkingOrder_Item> workingOrderItem;
                var recordResultGridViewModel = new List<RecordResultGridViewModel>();
                workingOrderItem = await Entities.Where(x => x.RequestNo == item.requestNo && x.LVNCode == item.LVNCode).AsNoTracking().ToListAsync();
                if (workingOrderItem.Count() > 0)
                {
                    foreach (var iii in workingOrderItem)
                    {
                        if (iii.ReviewResult == 1)
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
                                WOID = iii.WOID,
                                LVNCode = iii.LVNCode,
                                AnalysisCode = iii.AnalysisCode,
                                ValidationResult = iii.ValidationResult
                            };
                            recordResultGridViewModel.Add(RecordResult);
                        }
                       
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
                        weight = item.weight,
                        SampleMatrix = workingOrderItem[0].SampleMatrix
                    };
                    dataList.Add(getRecordResult);
                }
            }

            return dataList;
        }

        public async Task<bool> UpdateWorkingOrderItem(List<RecordResultGridViewModel> request)
        {
            
            foreach (var item in request)
            {
                var checkExits = await Entities.Where(x => x.AnalysisCode == item.AnalysisCode && x.LVNCode == item.LVNCode).AsNoTracking().ToListAsync();
                if (checkExits.Count() > 0)
                {
                    var obj = checkExits[0];
                    obj.Result = item.Result;
                    obj.ResultText = item.ResultText;
                    obj.ReviewResult = item.ReviewResult;
                    obj.ValidationResult = item.ValidationResult;
                    Entities.Update(obj);
                }
                _uow.SaveChanges();
            }
            return await Task.FromResult(true);
        }

        public async Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAllDapper(SearchRecordResult request, long id)
        {
            var dataList = new List<GetRecordResult>();
            var analysisRequest_Info = await _e08T_AnalysisRequest_ItemRepository.GetAnalysisRequest_ItemByRequestNo(request.requestNo);
            analysisRequest_Info.OrderBy(x => x.LVNCode);
            foreach (var item in analysisRequest_Info)
            {
                List<E08T_WorkingOrder_Item> workingOrderItem;
                var recordResultGridViewModel = new List<RecordResultGridViewModel>();
                workingOrderItem = await Entities.Where(x => x.RequestNo == item.requestNo && x.LVNCode == item.LVNCode).AsNoTracking().ToListAsync();
                using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@requestNo", request.requestNo);
                    dynamicParameters.Add("@userId", id);
                    dynamicParameters.Add("@lVNCode", item.LVNCode);
                    var data = await sqlConnection.QueryAsync<RecordResultGridViewModel>(
                             "GetWorkingOderItemByUserId", dynamicParameters, commandType: CommandType.StoredProcedure);
                    var getRecordResult = new GetRecordResult()
                    {
                        Data = data.ToList(),
                        LVNCode = item.LVNCode,
                        remarkToLab = item.remarkToLab,
                        requestNo = item.requestNo,
                        sampleCode = item.sampleCode,
                        sampleDescription = item.sampleDescription,
                        sampleName = item.sampleName,
                        weight = item.weight,
                        SampleMatrix = workingOrderItem[0].SampleMatrix,
                    };
                    dataList.Add(getRecordResult);
                }
                
            }

            return dataList;
        }
    }
}
