using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface ISampleManagementReportDapper
    {
        Task<IEnumerable<SampleManagementReportViewModel>> GetRequestManagementReport(string requestNo);
        Task<IEnumerable<SampleManagementPrintViewModel>> GetSampleManagementReport(string requestNo);
    }
}
