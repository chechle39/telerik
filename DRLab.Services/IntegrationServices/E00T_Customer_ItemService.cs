using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class E00T_Customer_ItemService : IE00T_Customer_ItemService
    {
        private readonly IE00T_Customer_ItemRepository _e00T_Customer_ItemRepository;
        private readonly IRepository<E00T_Customer_Item> _test;
        private readonly IUnitOfWork _uow;
        public E00T_Customer_ItemService(IUnitOfWork uow, IE00T_Customer_ItemRepository e00T_Customer_ItemRepository)
        {
            _e00T_Customer_ItemRepository = e00T_Customer_ItemRepository;
            _uow = uow;
            _test = _uow.GetRepository<IRepository<E00T_Customer_Item>>();
        }

        public async Task<bool> Create(E00T_Customer_ItemViewModel Data)
        {
            
                await _e00T_Customer_ItemRepository.SaveCustomerItem(Data);
                _uow.SaveChanges();
                return await Task.FromResult(true);         
            
           
        }

        public void Destroy(long id)
        {
            if (id != null)
            {
                _test.RemoveLong(id);
                _uow.SaveChanges();
            }
        }

        public async Task<List<E00T_Customer_ItemViewModel>> GetCustomerItem(string text)
        {
            return await _e00T_Customer_ItemRepository.GetCustomerItem(text);
        }

        public async Task<List<E00T_Customer_ItemViewModel>> GetE00T_Customer_ItemByCode(string code)
        {
            return await _e00T_Customer_ItemRepository.GetE00T_Customer_ItemByCode(code);
        }

        public async Task<IEnumerable<E00T_Customer_ItemViewModel>> GetListCustomerItem()
        {
            var test = _test.GetAll().ProjectTo<E00T_Customer_ItemViewModel>().AsEnumerable();
            return await Task.FromResult(test);
        }

        public async Task<bool> Update(E00T_Customer_ItemViewModel Data)
        {
            await _e00T_Customer_ItemRepository.UpdateCustomerItem(Data);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }
    }
}
