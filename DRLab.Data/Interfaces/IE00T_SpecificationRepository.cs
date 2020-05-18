using DRLab.Data.ViewModels;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE00T_SpecificationRepository
    {
        Task<bool> SaveSpecification(E00T_SpecificationViewModel SaveSpecificationrequest);
        Task<bool> UpdateSpecification(E00T_SpecificationViewModel SaveSpecificationrequest);
    }
}
