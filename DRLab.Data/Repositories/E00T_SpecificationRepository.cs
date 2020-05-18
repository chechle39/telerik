using AutoMapper;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E00T_SpecificationRepository : Repository<E00T_Specification>, IE00T_SpecificationRepository
    {
        public E00T_SpecificationRepository(DbContext context) : base(context)
        {
        }
        public async Task<bool> SaveSpecification(E00T_SpecificationViewModel SaveSpecificationrequest)
        {
            var saveSpecificationrequest = Mapper.Map<E00T_SpecificationViewModel, E00T_Specification>(SaveSpecificationrequest);

            Entities.Add(saveSpecificationrequest);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateSpecification(E00T_SpecificationViewModel SaveAnalysisRequestInforequest)
        {
            var saveAnalysisRequestInforequest = Mapper.Map<E00T_SpecificationViewModel, E00T_Specification>(SaveAnalysisRequestInforequest);

            Entities.Update(saveAnalysisRequestInforequest);
            return await Task.FromResult(true);
        }
    }
}
