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
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E00T_Customer_ItemRepository : Repository<E00T_Customer_Item>, IE00T_Customer_ItemRepository
    {
        public E00T_Customer_ItemRepository(DbContext context) : base(context)
        {
        }

        public async Task<List<E00T_Customer_ItemViewModel>> GetCustomerItem(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return await Entities.Where(x => x.email.Contains(text) || x.contactName.Contains(text)).ProjectTo<E00T_Customer_ItemViewModel>().ToListAsync();
            }
            else
            {

                return await Entities.ProjectTo<E00T_Customer_ItemViewModel>().ToListAsync();

            }
        }

        public async Task<List<E00T_Customer_ItemViewModel>> GetCustomerItemById(long? id)
        {
            var data = await Entities.ProjectTo<E00T_Customer_ItemViewModel>().Where(x => x.contactID == id).ToListAsync();
            return data;
        }

        public async Task<List<E00T_Customer_ItemViewModel>> GetE00T_Customer_ItemByCode(string code)
        {
            var data = await Entities.ProjectTo<E00T_Customer_ItemViewModel>().Where(x => x.customerCode == code).ToListAsync();
            return data;
        }

        public async Task<bool> SaveCustomerItem(E00T_Customer_ItemViewModel SaveCustomerItemrequest)
        {
            var saveCustomerItemrequest = Mapper.Map<E00T_Customer_ItemViewModel, E00T_Customer_Item>(SaveCustomerItemrequest);

            Entities.Add(saveCustomerItemrequest);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateCustomerItem(E00T_Customer_ItemViewModel UpdateCustomerItemrequest)
        {
            var updateCustomerItemrequest = Mapper.Map<E00T_Customer_ItemViewModel, E00T_Customer_Item>(UpdateCustomerItemrequest);

            Entities.Update(updateCustomerItemrequest);
            return await Task.FromResult(true);
        }
    }
}
