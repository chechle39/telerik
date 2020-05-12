using DRLab.Data.ViewModels;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE08T_AnalysisRequest_InfoRepository
    {
        Task<bool> SaveAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest);
        Task<bool> UpdateAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest);
    }
}
