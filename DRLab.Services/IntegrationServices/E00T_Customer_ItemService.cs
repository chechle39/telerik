using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class E00T_Customer_ItemService : IE00T_Customer_ItemService
    {
        private readonly IE00T_Customer_ItemRepository _e00T_Customer_ItemRepository;
        public E00T_Customer_ItemService(IE00T_Customer_ItemRepository e00T_Customer_ItemRepository)
        {
            _e00T_Customer_ItemRepository = e00T_Customer_ItemRepository;
        }

        public async Task<List<E00T_Customer_ItemViewModel>> GetCustomerItem(string text)
        {
            return await _e00T_Customer_ItemRepository.GetCustomerItem(text);
        }
    }
}
