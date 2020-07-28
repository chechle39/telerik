using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IE08T_WorkingOrder_ItemService
    {
        Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAll(SearchRecordResult request);
        Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAllByAccept(SearchRecordResult request);
        Task<bool> UpdateWorkingOrderItem(List<RecordResultGridViewModel> request);
        Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAllDapper(SearchRecordResult request, long id);
    }
}
