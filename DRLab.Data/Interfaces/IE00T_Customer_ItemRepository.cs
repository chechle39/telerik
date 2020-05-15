using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE00T_Customer_ItemRepository
    {
        Task<List<E00T_Customer_ItemViewModel>> GetCustomerItem(string text);
        Task<List<E00T_Customer_ItemViewModel>> GetE00T_Customer_ItemByCode(string code);
        Task<List<E00T_Customer_ItemViewModel>> GetCustomerItemById(long? id);

    }
}
