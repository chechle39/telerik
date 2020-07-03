using DRLab.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE00T_SampleMatrixRepository
    {
        public Task<List<E00T_SampleMatrixViewModel>> GetAllSampleMatrix(string text);
        Task<bool> SaveSampleMatrix(E00T_SampleMatrixViewModel SaveSampleMatrixrequest);
        Task<bool> UpdateSampleMatrix(E00T_SampleMatrixViewModel SaveSampleMatrixrequest);
    }
}