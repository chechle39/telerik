using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE08T_WorkingOrder_ItemRepository
    {
        Task<bool> UpdateWorkingOrderItem(List<RecordResultGridViewModel> request);
        Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAll(SearchRecordResult request);
        Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAllByAccept(SearchRecordResult request);
        Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAllDapper(SearchRecordResult request, long id);

    }
}
