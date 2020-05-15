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
    public class E00T_CustomerService : IE00T_CustomerService
    {
        private readonly IE00T_CustomerRepository _e00T_CustomerRepository;
        private readonly IRepository<E00T_Customer> _test;
        private readonly IUnitOfWork _uow;
        private readonly IE08T_AnalysisRequest_DataRepository _e08T_AnalysisRequest_DataRepository;
        public E00T_CustomerService(IUnitOfWork uow,IE00T_CustomerRepository e00T_CustomerRepository, IE08T_AnalysisRequest_DataRepository e08T_AnalysisRequest_DataRepository)
        {
            _e00T_CustomerRepository = e00T_CustomerRepository;           
            _uow = uow;
            _e08T_AnalysisRequest_DataRepository = e08T_AnalysisRequest_DataRepository;
        }

        public async Task<bool> Create(E00T_CustomerViewModel Data)
        {
            
            var customer = new E00T_Customer()
            {
                customerCode = Data.customerCode,
                companyName = Data.companyName,
                companyAddress = Data.companyAddress,
                contactName = Data.contactName,
                contactEmail = Data.contactEmail,
                city = Data.city,
                note = Data.note,
            };
             _test.Add(customer);
             _uow.SaveChanges();



            return true;
        }
       
        public async Task<List<E00T_CustomerViewModel>> GetCustomer(string text)
        {
            return await _e00T_CustomerRepository.GetCustomer(text);
        }
        public async Task<IEnumerable<E00T_CustomerViewModel>> GetListCustomer()
        {           
            var test = _test.GetAll().ProjectTo<E00T_CustomerViewModel>().AsEnumerable();
            return await Task.FromResult(test);
        }

        public async Task<bool> Update(E00T_CustomerViewModel Data)
        {
            var customer = new E00T_Customer()
            {
                customerCode = Data.customerCode,
                companyName = Data.companyName,
                companyAddress = Data.companyAddress,
                contactName = Data.contactName,
                contactEmail = Data.contactEmail,
                city = Data.city,
                note = Data.note,
            };
            _test.Update(customer);
            _uow.SaveChanges();
            return true;
        }
        public void Destroy(string id)
        {
            if (id != null)
            {
                _test.RemoveStringID(id);
                _uow.SaveChanges();
            }
        }

        public async Task<bool> CreateAnalysisRequestData(List<CreateCustomeRequest> request)
        {
            var save = await _e08T_AnalysisRequest_DataRepository.CreateAnalysisRequestData(request);
            _uow.SaveChanges();
             return save;
        }
    }
}
