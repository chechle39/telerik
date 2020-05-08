using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class Testing_InfoService : ITesting_InfoService
    {
        private readonly IRepository<E08T_Testing_InfoViewModel> _test;
        private readonly IUnitOfWork _uow;
        public Testing_InfoService(IUnitOfWork uow)
        {
            _uow = uow;
            _test = _uow.GetRepository<IRepository<E08T_Testing_InfoViewModel>>();
        }
        public async Task<List<E08T_Testing_InfoViewModel>> GetAllTesting_Info()
        {
            var test = await _test.GetAll().ProjectTo<E08T_Testing_InfoViewModel>().ToListAsync();
            return test;
        }
    }
}
