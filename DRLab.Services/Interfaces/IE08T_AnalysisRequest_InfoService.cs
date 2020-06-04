using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IE08T_AnalysisRequest_InfoService
    {
        Task<bool> SaveAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest);
        Task<bool> UpdateAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest);
        Task<List<GridManagementViewModel>> GetRequestInfoGrid(SerchGridManagement request);
        Task<List<SampleManagementViewModel>> GetRequestInfoSample(SerchSampleManagement request);
        Task<bool> DeleteAnalysisRequestInfo(string[] requestNo);
        Task<AnalysisRequest_Info> GetRequestInfoByRequestNo(string request);
    }
}
