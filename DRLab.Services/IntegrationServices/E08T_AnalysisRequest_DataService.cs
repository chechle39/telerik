using DRLab.Data.Base;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class E08T_AnalysisRequest_DataService : IE08T_AnalysisRequest_DataService
    {
        private readonly IE08T_AnalysisRequest_DataService _e08T_AnalysisRequest_DataService;
        private readonly IUnitOfWork _uow;
        public E08T_AnalysisRequest_DataService(IE08T_AnalysisRequest_DataService e08T_AnalysisRequest_DataService, IUnitOfWork uow)
        {
            _e08T_AnalysisRequest_DataService = e08T_AnalysisRequest_DataService;
            _uow = uow;
        }
        public async Task<bool> CreateAnalysisRequestData(List<CreateCustomeRequest> request)
        {
            var x = await _e08T_AnalysisRequest_DataService.CreateAnalysisRequestData(request);
            _uow.SaveChanges();
            return x;
        }

        public async Task<List<CreateCustomeRequest>> GetAnalysisByRequestNo(string requestNo)
        {
            return await _e08T_AnalysisRequest_DataService.GetAnalysisByRequestNo(requestNo);
        }
    }
}
