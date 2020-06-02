using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface ILabManagmentDapperService
    {
        Task<IEnumerable<LabManagmentViewModel>> GetLabManagment(SerchGridManagement rq);
    }
}
