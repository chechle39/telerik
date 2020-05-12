using AutoMapper;
using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class SpecificationService : ISpecificationService
    {
      
        private readonly IRepository<E00T_Specification> _test;
        private readonly IUnitOfWork _uow;
        public SpecificationService(IUnitOfWork uow)
        {
            _uow = uow;
            _test = _uow.GetRepository<IRepository<E00T_Specification>>();
        }



        public async Task<List<E00T_SpecificationViewModel>> GetAll()
        {

           
                var data =  await _test.GetAll().ProjectTo<E00T_SpecificationViewModel>().ToListAsync();
                return data;
           
          
        }

        public async Task<List<E00T_SpecificationViewModel>> GetbyId(long? id)
        {
            return await _test.GetAll().Where(x => x.specID==id).ProjectTo<E00T_SpecificationViewModel>().ToListAsync(); ;
        }
    }
    
}
