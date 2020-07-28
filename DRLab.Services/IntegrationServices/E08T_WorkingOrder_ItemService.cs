using DRLab.Data.Base;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class E08T_WorkingOrder_ItemService : IE08T_WorkingOrder_ItemService
    {
        private readonly IE08T_WorkingOrder_ItemRepository _e08T_WorkingOrder_ItemRepository;
        private readonly IUnitOfWork _uow;
        public E08T_WorkingOrder_ItemService(IE08T_WorkingOrder_ItemRepository e08T_WorkingOrder_ItemRepository, IUnitOfWork uow)
        {
            _e08T_WorkingOrder_ItemRepository = e08T_WorkingOrder_ItemRepository;
            _uow = uow;
        }
        public async Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAll(SearchRecordResult request)
        {
            return await _e08T_WorkingOrder_ItemRepository.GetE08TWorkingOrderItemByFkAll(request);
        }

        public async Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAllByAccept(SearchRecordResult request)
        {
            return await _e08T_WorkingOrder_ItemRepository.GetE08TWorkingOrderItemByFkAllByAccept(request);
        }

        public async Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAllDapper(SearchRecordResult request, long id)
        {
            return await _e08T_WorkingOrder_ItemRepository.GetE08TWorkingOrderItemByFkAllDapper(request,id);
        }

        public async Task<bool> UpdateWorkingOrderItem(List<RecordResultGridViewModel> request)
        {
            var save = await _e08T_WorkingOrder_ItemRepository.UpdateWorkingOrderItem(request);
          //  _uow.SaveChanges();
            return save;
        }
    }
}
