using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IFieldAutoTableRepository
    {
        Task<bool> CreateTable(List<FieldAutoTableViewModel> request);
        Task<List<RubberClassification>> GetFieldTableByCode(string code);
    }
}
