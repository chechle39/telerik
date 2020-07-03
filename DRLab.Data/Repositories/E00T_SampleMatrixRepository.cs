using AutoMapper;
using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E00T_SampleMatrixRepository: Repository<E00T_SampleMatrix>, IE00T_SampleMatrixRepository
    {
        public E00T_SampleMatrixRepository(DbContext context): base(context)
        {

        }

        public async Task<List<E00T_SampleMatrixViewModel>> GetAllSampleMatrix(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return await Entities.Where(x => x.sampleMatrix.Contains(text)).ProjectTo<E00T_SampleMatrixViewModel>().ToListAsync();
            }
            else
            {
                try
                {
                    return await Entities.ProjectTo<E00T_SampleMatrixViewModel>().ToListAsync();

                }
                catch (Exception e)
                {

                }
                return null;
            }
        }

        public async Task<bool> SaveSampleMatrix(E00T_SampleMatrixViewModel SaveSampleMatrixrequest)
        {
            var saveSampleMatrixrequest = Mapper.Map<E00T_SampleMatrixViewModel, E00T_SampleMatrix>(SaveSampleMatrixrequest);

            Entities.Add(saveSampleMatrixrequest);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateSampleMatrix(E00T_SampleMatrixViewModel SaveSampleMatrixrequest)
        {
            var saveSampleMatrixrequest = Mapper.Map<E00T_SampleMatrixViewModel, E00T_SampleMatrix>(SaveSampleMatrixrequest);

            Entities.Update(saveSampleMatrixrequest);
            return await Task.FromResult(true);
        }
    }
}
