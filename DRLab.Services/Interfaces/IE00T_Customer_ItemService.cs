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
    }
}
