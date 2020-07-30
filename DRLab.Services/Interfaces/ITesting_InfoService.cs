using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface ITesting_InfoService
    {
       Task<IEnumerable<E08T_Testing_InfoViewModel>> GetAllTesting_Info();
        public Task<E08T_Testing_InfoViewModel> Create(E08T_Testing_InfoViewModel Data);
        public Task<E08T_Testing_PopupViewModel> CreatePopup(E08T_Testing_PopupViewModel Data);
        public Task<E08T_Testing_InfoViewModel> Update(E08T_Testing_InfoViewModel Data);
        public void Destroy(string id);
        Task<List<E08T_Testing_InfoViewModel>> GetE08TTestingInfoCombobox(string text);
        Task<List<E00T_CustomerGridViewModel>> GetE08TTestingInfoBySpecId(string analysisCode);
        public Task<List<E08T_Testing_InfoViewModel>> GetE08TTestingInfoComboboxByMatrix(long id);
        public Task<List<E00T_CustomerGridViewModel>> GetE08TTestingInfoByMtID(long id);

    }
}
