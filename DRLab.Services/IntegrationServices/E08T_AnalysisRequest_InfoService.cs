using DRLab.Data.Base;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class E08T_AnalysisRequest_InfoService : IE08T_AnalysisRequest_InfoService
    {
        public readonly IE08T_AnalysisRequest_InfoRepository _e08T_AnalysisRequest_InfoRepository;
        private readonly IUnitOfWork _uow;
        public E08T_AnalysisRequest_InfoService(IE08T_AnalysisRequest_InfoRepository e08T_AnalysisRequest_InfoRepository, IUnitOfWork uow)
        {
            _e08T_AnalysisRequest_InfoRepository = e08T_AnalysisRequest_InfoRepository;
            _uow = uow;
        }

        public async Task<bool> DeleteAnalysisRequestInfo(string[] requestNo)
        {
            var delete = await _e08T_AnalysisRequest_InfoRepository.DeleteAnalysisRequestInfo(requestNo);
            _uow.SaveChanges();
            return delete;
        }

        public async Task<AnalysisRequest_Info> GetRequestInfoByRequestNo(string request)
        {
            return await _e08T_AnalysisRequest_InfoRepository.GetRequestInfoByRequestNo(request);
        }

        public async Task<List<GridManagementViewModel>> GetRequestInfoGrid(SerchGridManagement request)
        {
            return await _e08T_AnalysisRequest_InfoRepository.GetRequestInfoGrid(request);
        }

        public async Task<List<GridManagementViewModel>> GetRequestInfoSample(SerchSampleManagement request)
        {
            return await _e08T_AnalysisRequest_InfoRepository.GetRequestInfoSample(request);
        }

        public async Task<bool> SaveAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest)
        {
            await _e08T_AnalysisRequest_InfoRepository.SaveAnalysisRequestInfo(SaveAnalysisRequestInforequest);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest)
        {
            await _e08T_AnalysisRequest_InfoRepository.UpdateAnalysisRequestInfo(SaveAnalysisRequestInforequest);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }
    }
}
