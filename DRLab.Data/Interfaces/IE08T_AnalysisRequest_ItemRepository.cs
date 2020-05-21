using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE08T_AnalysisRequest_ItemRepository
    {
        public Task<bool> CreatAnalysisRequestItem(List<CreateCustomeRequest> request);
        public Task<bool> DeleteAnalysisRequestItem(string[] request);
        public Task<List<E08T_AnalysisRequest_ItemViewModel>> GetAnalysisRequest_ItemByRequestNo(string requestNo);
    }
}
