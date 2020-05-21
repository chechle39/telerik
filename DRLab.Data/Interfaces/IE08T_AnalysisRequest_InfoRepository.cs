using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE08T_AnalysisRequest_InfoRepository
    {
        Task<bool> SaveAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest);
        Task<bool> UpdateAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest);
        Task<List<GridManagementViewModel>> GetRequestInfoGrid(SerchGridManagement request);
        Task<AnalysisRequest_Info> GetRequestInfoByRequestNo(string request);

        Task<bool> DeleteAnalysisRequestInfo(string[] requestNo);

    }
}
