using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE08T_WorkingOrder_ItemRepository
    {
        Task<List<GetRecordResult>> GetE08TWorkingOrderItemByFkAll(SearchRecordResult request);
    }
}
