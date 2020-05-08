using AutoMapper;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E08T_AnalysisRequest_InfoRepository : Repository<E08T_AnalysisRequest_Info>, IE08T_AnalysisRequest_InfoRepository
    {
        public E08T_AnalysisRequest_InfoRepository(DbContext context) : base(context)
        {
        }
        public async Task<bool> SaveAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest)
        {
            var saveAnalysisRequestInforequest = Mapper.Map<E08T_AnalysisRequest_InfoViewModel, E08T_AnalysisRequest_Info>(SaveAnalysisRequestInforequest);

            Entities.Add(saveAnalysisRequestInforequest);
            return await Task.FromResult(true);
        }
    }
}
