using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE08T_Testing_DataRepository
    {
        Task<List<E08T_Testing_DataViewModel>> GetDataTestTing(long id);
    }
}
