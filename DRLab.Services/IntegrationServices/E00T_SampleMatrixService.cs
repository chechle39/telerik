using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class E00T_SampleMatrixService : IE00T_SampleMatrixService
    {
        private readonly IE00T_SampleMatrixRepository _e00T_SampleMatrixRepository;
        public E00T_SampleMatrixService(IE00T_SampleMatrixRepository e00T_SampleMatrixRepository)
        {
            _e00T_SampleMatrixRepository = e00T_SampleMatrixRepository;
        }

        public async Task<List<E00T_SampleMatrixViewModel>> GetAllSampleMatrix(string text)
        {
            return await _e00T_SampleMatrixRepository.GetAllSampleMatrix(text);
        }
    }
}
