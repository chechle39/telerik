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
        public E08T_WorkingOrder_ItemService(IE08T_WorkingOrder_ItemRepository e08T_WorkingOrder_ItemRepository)
        {
            _e08T_WorkingOrder_ItemRepository = e08T_WorkingOrder_ItemRepository;
        }
        public async Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAll(SearchRecordResult request)
        {
            return await _e08T_WorkingOrder_ItemRepository.GetE08TWorkingOrderItemByFkAll(request);
        }
    }
}
