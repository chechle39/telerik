using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IE00T_SampleMatrixService
    {
        public Task<List<E00T_SampleMatrixViewModel>> GetAllSampleMatrix(string text);
        Task<bool> Create(E00T_SampleMatrixViewModel Data);
    }
}   
