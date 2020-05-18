using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IE00T_Customer_ItemService
    {
        Task<List<E00T_Customer_ItemViewModel>> GetCustomerItem(string text);       
        Task<IEnumerable<E00T_Customer_ItemViewModel>> GetListCustomerItem();
        Task<bool> Create(E00T_Customer_ItemViewModel Data);
        Task<bool> Update(E00T_Customer_ItemViewModel Data);
        public void Destroy(long id);
        Task<List<E00T_Customer_ItemViewModel>> GetE00T_Customer_ItemByCode(string code);
    }
}
