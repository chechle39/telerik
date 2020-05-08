using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DRLab.Web.Controllers
{
    public class CustomerRequestController : Controller
    {
        private readonly IE00T_CustomerService _e00T_CustomerService;
        private readonly IE00T_Customer_ItemService _e00T_Customer_ItemService;
        private readonly IE08T_AnalysisRequest_InfoService _e08T_AnalysisRequest_InfoService;
        public CustomerRequestController(IE00T_CustomerService e00T_CustomerService, 
            IE00T_Customer_ItemService e00T_Customer_ItemService, 
            IE08T_AnalysisRequest_InfoService e08T_AnalysisRequest_InfoService)
        {
            _e00T_CustomerService = e00T_CustomerService;
            _e00T_Customer_ItemService = e00T_Customer_ItemService;
            _e08T_AnalysisRequest_InfoService = e08T_AnalysisRequest_InfoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveEntity(E08T_AnalysisRequest_InfoViewModel req)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            await _e08T_AnalysisRequest_InfoService.SaveAnalysisRequestInfo(req);
            return new OkObjectResult(req);
        }
        public async Task<List<E00T_CustomerViewModel>> GetCustomers(string text)
        {
            return await _e00T_CustomerService.GetCustomer(text);
        }
        public async Task<List<E00T_Customer_ItemViewModel>> GetCustomersItem(string text)
        {
            return await _e00T_Customer_ItemService.GetCustomerItem(text);
        }
    }
}