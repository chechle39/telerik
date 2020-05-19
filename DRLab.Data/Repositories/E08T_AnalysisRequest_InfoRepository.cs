using AutoMapper;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E08T_AnalysisRequest_InfoRepository : Repository<E08T_AnalysisRequest_Info>, IE08T_AnalysisRequest_InfoRepository
    {
        private readonly IE00T_CustomerRepository _e00T_CustomerRepository;
        public readonly IE00T_Customer_ItemRepository _e00T_Customer_ItemRepository;
        private readonly IE08T_AnalysisRequest_DataRepository _e08T_AnalysisRequest_DataRepository;
        public E08T_AnalysisRequest_InfoRepository(DbContext context, IE00T_CustomerRepository e00T_CustomerRepository, IE00T_Customer_ItemRepository e00T_Customer_ItemRepository, IE08T_AnalysisRequest_DataRepository e08T_AnalysisRequest_DataRepository) : base(context)
        {
            _e00T_CustomerRepository = e00T_CustomerRepository;
            _e00T_Customer_ItemRepository = e00T_Customer_ItemRepository;
            _e08T_AnalysisRequest_DataRepository = e08T_AnalysisRequest_DataRepository;
        }

        public async Task<List<GridManagementViewModel>> GetRequestInfoGrid(SerchGridManagement request)
        {
            var data = await Entities.ToListAsync();
            var listGridManagementViewModel = new List<GridManagementViewModel>();
            foreach (var item in data)
            {
                // var customerItem = await _e00T_Customer_ItemRepository.GetCustomerItemById(item.contactID);
                var cus = await _e00T_CustomerRepository.GetCustomerById(item.customerID);
                var objGridManagementViewModel = new GridManagementViewModel()
                {
                    companyName = cus[0].companyName,
                    contactName = cus[0].contactName,
                    dateOfSendingResult = item.dateOfSendingResult,
                    receivceDate = item.receivceDate,
                    requestNo = item.requestNo,
                    status = item.status,
                    customerCode = cus[0].customerCode
                };
                listGridManagementViewModel.Add(objGridManagementViewModel);
            }
            if (!string.IsNullOrEmpty(request.StartDate))
            {
                DateTime start = DateTime.Parse(request.StartDate, new CultureInfo("en-CA"));

                listGridManagementViewModel = listGridManagementViewModel.Where(x => x.receivceDate >= start).ToList();
            }
            if (!string.IsNullOrEmpty(request.EndDate))
            {
                DateTime end = DateTime.Parse(request.EndDate, new CultureInfo("en-CA"));

                listGridManagementViewModel = listGridManagementViewModel.Where(x => x.receivceDate <= end).ToList();
            }
            var rq = JsonConvert.DeserializeObject<string[]>(request.Customer[0]);
            if (rq.Count() > 0)
            {
                
                listGridManagementViewModel = listGridManagementViewModel.Where(t => rq.Contains(t.customerCode)).ToList();
            }
            return listGridManagementViewModel;
        }

        public async Task<bool> SaveAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest)
        {
            var saveAnalysisRequestInforequest = Mapper.Map<E08T_AnalysisRequest_InfoViewModel, E08T_AnalysisRequest_Info>(SaveAnalysisRequestInforequest);

            Entities.Add(saveAnalysisRequestInforequest);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAnalysisRequestInfo(E08T_AnalysisRequest_InfoViewModel SaveAnalysisRequestInforequest)
        {
            var saveAnalysisRequestInforequest = Mapper.Map<E08T_AnalysisRequest_InfoViewModel, E08T_AnalysisRequest_Info>(SaveAnalysisRequestInforequest);

            Entities.Update(saveAnalysisRequestInforequest);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAnalysisRequestInfo(string[] requestNo)
        {
            foreach (var item in requestNo)
            {
                var objDelete = await Entities.Where(x => x.requestNo == item).ToListAsync();
                if (objDelete.Count() > 0)
                {
                    Entities.Remove(objDelete[0]);
                }
            }
            await _e08T_AnalysisRequest_DataRepository.DeleteAnalysisRequestData(requestNo);
            return await Task.FromResult(true);
        }
    }
}
