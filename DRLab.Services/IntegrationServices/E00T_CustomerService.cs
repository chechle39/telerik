using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class E00T_CustomerService : IE00T_CustomerService
    {
        private readonly IE00T_CustomerRepository _e00T_CustomerRepository;
        public E00T_CustomerService(IE00T_CustomerRepository e00T_CustomerRepository)
        {
            _e00T_CustomerRepository = e00T_CustomerRepository;
        }

        public async Task<List<E00T_CustomerViewModel>> GetCustomer(string text)
        {
            return await _e00T_CustomerRepository.GetCustomer(text);
        }
    }
}
