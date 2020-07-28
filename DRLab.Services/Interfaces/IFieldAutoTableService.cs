using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IFieldAutoTableService
    {
        Task<bool> CreateTable(List<FieldAutoTableViewModel> request);
        Task<List<RubberClassification>> GetFieldTableByCode(string code);
    }
}
