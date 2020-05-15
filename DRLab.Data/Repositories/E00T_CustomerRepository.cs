using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E00T_CustomerRepository : Repository<E00T_Customer>, IE00T_CustomerRepository
    {
        public E00T_CustomerRepository(DbContext context) : base(context)
        {
        }

        public async Task<List<E00T_CustomerViewModel>> GetCustomer(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                 return await Entities.Where(x=>x.companyName.Contains(text) || x.contactEmail.Contains(text) || x.contactName.Contains(text)).ProjectTo<E00T_CustomerViewModel>().ToListAsync();
            } else
            {
                return await Entities.ProjectTo<E00T_CustomerViewModel>().ToListAsync();
            }

        }

        public async Task<List<E00T_CustomerViewModel>> GetCustomerById(string id)
        {
            return await Entities.Where(x => x.customerCode == id).ProjectTo<E00T_CustomerViewModel>().ToListAsync();
        }
    }
}
