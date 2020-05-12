using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE08T_Testing_InfoRepository
    {
        public Task<List<E08T_Testing_InfoViewModel>> GetE08TTestingInfoCombobox(string text);
        public Task<List<E00T_CustomerGridViewModel>> GetE08TTestingInfoBySpecId(long specId);
    }
}
