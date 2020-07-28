using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IE08T_AnalysisRequest_ItemService   {
       
        public Task<List<E08T_AnalysisRequest_ItemViewModel>> GetAnalysisByRequestNo(string requestNo);
    }
}
