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
    public class Testing_DataService : ITesting_DataService
    {
        private readonly IRepository<E08T_Testing_DataViewModel> _test;
        private readonly IUnitOfWork _uow;
        public Testing_DataService(IUnitOfWork uow)
        {
            _uow = uow;
            _test = _uow.GetRepository<IRepository<E08T_Testing_DataViewModel>>();
        }
        public async Task<List<E08T_Testing_DataViewModel>> GetAllTesting_Data()
        {
            var test = await _test.GetAll().ProjectTo<E08T_Testing_DataViewModel>().ToListAsync();
            return test;
        }
    }
}
