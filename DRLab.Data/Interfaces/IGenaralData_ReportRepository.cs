using DRLab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IGenaralData_ReportRepository
    {
        Task<bool> CreateDataRP(List<GeneralData_Report> request);
        Task<bool> DeleteDataRP(string request);
    }
}
