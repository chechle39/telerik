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
    }
}
