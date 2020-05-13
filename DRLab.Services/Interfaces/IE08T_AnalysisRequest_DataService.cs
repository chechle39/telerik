using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IE08T_AnalysisRequest_DataService
    {
        Task<bool> CreateAnalysisRequestData(List<CreateCustomeRequest> request);
    }
}
