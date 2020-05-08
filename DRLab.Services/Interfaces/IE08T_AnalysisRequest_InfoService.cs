using DRLab.Data.ViewModels;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IE08T_AnalysisRequest_InfoService
    {
        Task<bool> SaveAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest);
    }
}
