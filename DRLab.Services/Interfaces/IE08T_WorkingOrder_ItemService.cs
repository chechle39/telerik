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
    }
}
