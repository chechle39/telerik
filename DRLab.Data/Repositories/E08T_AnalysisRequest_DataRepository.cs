using AutoMapper.QueryableExtensions;
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
               
                if (item.Data.Count() > 0 && item.sampleName != "")
                {
                    foreach (var iitem in item.Data)
                    {
                        var check = Entities.Where(x => x.analysisCode == iitem.analysisCode && x.requestNo == item.requestNo && x.LVNCode == item.LVNCode).AsNoTracking().ToList();
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
                                sampleMatrix = item.sampleMatrix != null ? item.sampleMatrix : check[0].sampleMatrix, 
                                specification = item.specification != null ? item.specification : check[0].specification,
                                specMark = null,
                                turnAroundDay = null,
                                unit = iitem.unit,
                                urgentRate = iitem.Urgent
                            };
                            Entities.Update(e08T_AnalysisRequest_Data);
                        }
                        
                    }
                }
                if (item.Deleted.Count > 0)
                {
                    foreach (var iii in item.Deleted)
                    {
                        var checkDelete = Entities.Where(x => x.analysisCode == iii.analysisCode && x.requestNo == item.requestNo && x.LVNCode == item.LVNCode).AsNoTracking().ToList();

                        if (checkDelete.Count() > 0)
                        {
                            var e08T_AnalysisRequest_Data = new E08T_AnalysisRequest_Data()
                            {
                                analysisCode = iii.analysisCode,
                                LOD = iii.LOD,
                                LVNCode = item.LVNCode,
                                max = null,
                                method = iii.method,
                                min = null,
                                precision = null,
                                price = iii.Price,
                                requestNo = item.requestNo,
                                sampleMatrix = item.sampleMatrix != null ? iii.sampleMatrix : checkDelete[0].sampleMatrix,
                                specification = item.specification != null ? iii.specification : checkDelete[0].specification,
                                specMark = null,
                                turnAroundDay = null,
                                unit = iii.unit,
                                urgentRate = iii.Urgent
                            };
                            Entities.Remove(e08T_AnalysisRequest_Data);
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

        public async Task<List<CreateCustomeRequest>> GetAnalysisByRequestNo(string requestNo)
        {
            var dataList = new List<CreateCustomeRequest>();
            var data = await _e08T_AnalysisRequest_ItemRepository.GetAnalysisRequest_ItemByRequestNo(requestNo);
            foreach(var item in data)
            {
                var listGridManagementViewModel = new List<GridManagementViewModel>();
                var e00T_CustomerGridViewModel = new List<E00T_CustomerGridViewModel>();
                var analysisData = await Entities.Where(x => x.LVNCode == item.LVNCode).ToListAsync();
                foreach (var iitem in analysisData)
                {
                    var dataCustomerGridViewModel = new E00T_CustomerGridViewModel()
                    {
                        analysisCode = iitem.analysisCode,
                        LOD = iitem.LOD,
                        Mark = null,
                        max = iitem.max,
                        method = iitem.method,
                        min = iitem.min,
                        Price = Convert.ToInt32(iitem.price),
                        sampleMatrix = iitem.sampleMatrix,
                        specification = iitem.specification,
                        TAT = null,
                        unit = iitem.unit,
                        Urgent = iitem.urgentRate,

                    };
                    e00T_CustomerGridViewModel.Add(dataCustomerGridViewModel);
                }
                var createCustomeRequest = new CreateCustomeRequest()
                {
                    Data = e00T_CustomerGridViewModel.Count() > 0 ? e00T_CustomerGridViewModel : null,
                    specification = analysisData.Count() > 0 ? analysisData[0].specification : null,
                    LVNCode = item.LVNCode,
                    remarkToLab = item.remarkToLab,
                    requestNo = item.requestNo,
                    sampleCode = item.sampleCode,
                    sampleDescription = item.sampleDescription,
                    sampleMatrix = analysisData.Count() > 0 ? analysisData[0].sampleMatrix : null,
                    sampleName = item.sampleName,
                    weight = item.weight,
                };
                dataList.Add(createCustomeRequest);
            }
            return dataList;
        }
    }
}
