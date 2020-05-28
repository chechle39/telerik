using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IE08T_WorkingOrder_InfoService
    {
        Task<List<E08T_WorkingOrder_InfoCbbViewModel>> E08T_WorkingOrder_InfoCbb(string start, string end);

    }
}
