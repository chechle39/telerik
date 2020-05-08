using DRLab.Data.Base;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System;
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
        public async Task<bool> SaveAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest)
        {
            await _e08T_AnalysisRequest_InfoRepository.SaveAnalysisRequestInfo(SaveAnalysisRequestInforequest);
            try
            {
                _uow.SaveChanges();

            } catch (Exception ex)
            {

            }
            return await Task.FromResult(true);
        }
    }
}
