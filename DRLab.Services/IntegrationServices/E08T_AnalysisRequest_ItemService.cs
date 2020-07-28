using DRLab.Data.Base;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class E08T_AnalysisRequest_ItemService : IE08T_AnalysisRequest_ItemService
    {
        private readonly IE08T_AnalysisRequest_ItemRepository _iE08T_AnalysisRequest_ItemRepository;
        private readonly IUnitOfWork _uow;
        public E08T_AnalysisRequest_ItemService(IE08T_AnalysisRequest_ItemRepository iE08T_AnalysisRequest_ItemRepository, IUnitOfWork uow)
        {
            _iE08T_AnalysisRequest_ItemRepository = iE08T_AnalysisRequest_ItemRepository;
            _uow = uow;
        }
     

        public async Task<List<E08T_AnalysisRequest_ItemViewModel>> GetAnalysisByRequestNo(string requestNo)
        {
            return await _iE08T_AnalysisRequest_ItemRepository.GetAnalysisRequest_ItemByRequestNo(requestNo);
        }
    }
}
