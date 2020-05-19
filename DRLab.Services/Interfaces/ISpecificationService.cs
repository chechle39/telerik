using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface ISpecificationService
    {
        Task<List<E00T_SpecificationViewModel>> GetAll();
        Task<List<E00T_SpecificationViewModel>> GetbyId(long? id);
        Task<List<E00T_SpecificationViewModel>> GetbyName(string text);
        Task<bool> Create(E00T_SpecificationViewModel Data);
        Task<IEnumerable<E00T_SpecificationViewModel>> GetAll_IEnumerable();
    }
}
