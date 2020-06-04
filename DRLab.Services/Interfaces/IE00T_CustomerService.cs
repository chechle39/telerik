using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IE00T_CustomerService
    {
        Task<List<E00T_CustomerViewModel>> GetCustomer(string text);
        Task<List<E00T_CustomerViewModel>> GetAll();
        Task<IEnumerable<E00T_CustomerViewModel>> GetListCustomer();
        Task<bool> Create(E00T_CustomerViewModel Data);
        Task<bool> Update(E00T_CustomerViewModel Data);
        public void Destroy(string id);
        public Task<bool> CreateAnalysisRequestData(List<CreateCustomeRequest> request);
        Task<List<E00T_CustomerViewModel>> GetCustomerById(string id);
        public Task<List<CreateCustomeRequest>> GetAnalysisByRequestNo(string requestNo);
        public Task<bool> DeleteAnalysisRequestDataGrid(List<CreateCustomeRequest> request);
    }
}
