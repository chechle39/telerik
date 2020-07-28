using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface ISampleManagementDapperService
    {
        Task<IEnumerable<SampleManagementViewModel>> GetSampleManagement(SerchSampleManagement rq);
        Task<IEnumerable<SampleManagementExportViewModel>> GetSampleManagementExport(SerchSampleManagement rq); 
    }
}
