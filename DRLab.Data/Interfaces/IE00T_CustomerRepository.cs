using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE00T_CustomerRepository
    {
        Task<List<E00T_CustomerViewModel>> GetCustomer(string text);
        Task<List<E00T_CustomerViewModel>> GetCustomerById(string id);
     
    }
}
