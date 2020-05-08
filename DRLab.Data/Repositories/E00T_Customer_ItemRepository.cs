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
                try
                {
                    return await Entities.ProjectTo<E00T_Customer_ItemViewModel>().ToListAsync();

                } catch (Exception e)
                {

                }
                return null;
            }
        }
    }
}
