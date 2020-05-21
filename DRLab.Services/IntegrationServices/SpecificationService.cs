using AutoMapper;
using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
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
        public readonly IE00T_SpecificationRepository _e00T_SpecificationRepository;      
        private readonly IRepository<E00T_Specification> _test;
        private readonly IUnitOfWork _uow;
        public SpecificationService(IE00T_SpecificationRepository e00T_SpecificationRepository, IUnitOfWork uow)
        {
            _e00T_SpecificationRepository = e00T_SpecificationRepository;
            _uow = uow;
            _test = _uow.GetRepository<IRepository<E00T_Specification>>();
        }

        public async Task<IEnumerable<E00T_SpecificationViewModel>> GetAll_IEnumerable()
        {
            var test = _test.GetAll().ProjectTo<E00T_SpecificationViewModel>().AsEnumerable();
            return await Task.FromResult(test);
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
        public async Task<List<E00T_SpecificationViewModel>> GetbyName(string text)
        {
            return await _test.GetAll().Where(x => x.specification == text).ProjectTo<E00T_SpecificationViewModel>().ToListAsync(); ;
        }

        public async Task<bool> Create(E00T_SpecificationViewModel Data)
        {          
                await _e00T_SpecificationRepository.SaveSpecification(Data);
                _uow.SaveChanges();
                return await Task.FromResult(true);     
        }
    }
    
}
